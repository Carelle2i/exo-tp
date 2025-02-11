public class OrderService
{
    private readonly MySqlConnection _connection;
    private readonly HttpClient _httpClient;

    public OrderService(IConfiguration configuration)
    {
        _connection = new MySqlConnection(configuration.GetValue<string>("ConnectionStrings__MySQL"));
        _httpClient = new HttpClient();
    }

    public async Task<OrderDTO> CreateOrder(OrderDTO orderDTO)
    {
        // Call ProductService

        var product = JsonConvert.DeserializeObject<Product>(productResponse);

        // Call UserService
        var userResponse = await _httpClient.GetStringAsync($"http://user-service:5002/users/{orderDTO.UserId}");
        var user = JsonConvert.DeserializeObject<User>(userResponse);

        if (product != null && user != null)
        {
            var query = "INSERT INTO orders (user_id, product_id, quantity) VALUES (@UserId, @ProductId, @Quantity)";
            var order = new Order { UserId = user.Id, ProductId = product.Id, Quantity = orderDTO.Quantity };
            _connection.Execute(query, order);

            return MapToOrderDTO(order, product, user);
        }
        return null;
    }

    public async Task<OrderDTO> GetOrder(int id)
    {
        var query = "SELECT * FROM orders WHERE id = @Id";
        var order = _connection.QueryFirstOrDefault<Order>(query, new { Id = id });

        if (order != null)
        {
            // Call ProductService
            var productResponse = await _httpClient.GetStringAsync($"http://product-service:5001/products/{order.ProductId}");
            var product = JsonConvert.DeserializeObject<Product>(productResponse);

            // Call UserService
            var userResponse = await _httpClient.GetStringAsync($"http://user-service:5002/users/{order.UserId}");
            var user = JsonConvert.DeserializeObject<User>(userResponse);

            return MapToOrderDTO(order, product, user);
        }
        return null;
    }

    private OrderDTO MapToOrderDTO(Order order, Product product, User user)
    {
        return new OrderDTO
        {
            OrderId = order.Id,
            ProductId = product.Id,
            ProductName = product.Name,
            ProductPrice = product.Price,
            UserId = user.Id,
            UserName = user.Name,
            Quantity = order.Quantity,
            OrderDate = order.OrderDate
        };
    }
}

internal class MySqlConnection
{
    public MySqlConnection(string? v)
    {
    }
}