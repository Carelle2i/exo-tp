public class UserService
{
    private readonly MySqlConnection _connection;

    public UserService(IConfiguration configuration)
    {
        _connection = new MySqlConnection(configuration.GetValue<string>("ConnectionStrings__MySQL"));
    }

    public User CreateUser(User user)
    {
        var query = "INSERT INTO users (name, email) VALUES (@Name, @Email)";
        _connection.Execute(query, user);
        return user;
    }

    public User GetUser(int id)
    {
        var query = "SELECT * FROM users WHERE id = @Id";
        return _connection.QueryFirstOrDefault<User>(query, new { Id = id });
    }

    public List<User> GetAllUsers()
    {
        var query = "SELECT * FROM users";
        return _connection.Query<User>(query).ToList();
    }

    public void UpdateUser(int id, User user)
    {
        var query = "UPDATE users SET name = @Name, email = @Email WHERE id = @Id";
        _connection.Execute(query, new { Id = id, user.Name, user.Email });
    }

    public void DeleteUser(int id)
    {
        var query = "DELETE FROM users WHERE id = @Id";
        _connection.Execute(query, new { Id = id });
    }
}
