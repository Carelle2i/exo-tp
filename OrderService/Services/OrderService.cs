using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

public class OrderService
{
    private readonly HttpClient _httpClient;
    public OrderService(HttpClient httpClient) => _httpClient = httpClient;

    public async Task<UserDto> GetUserAsync(int userId)
    {
        var response = await _httpClient.GetStringAsync($"http://user-service:5002/api/users/{userId}");
        return JsonSerializer.Deserialize<UserDto>(response);
    }

    public async Task<ProductDto> GetProductAsync(string productId)
    {
        var response = await _httpClient.GetStringAsync($"http://product-service:5001/api/products/{productId}");
        return JsonSerializer.Deserialize<ProductDto>(response);
    }
}
