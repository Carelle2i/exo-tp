using MongoDB.Driver;
using ProductService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ProductService
{
    private readonly IMongoCollection<Product> _products;

    public ProductService(IMongoClient mongoClient)
    {
        var database = mongoClient.GetDatabase("productdb");
        _products = database.GetCollection<Product>("products");
    }

    public async Task<List<Product>> GetProductsAsync() => await _products.Find(_ => true).ToListAsync();
    public async Task<Product> GetProductByIdAsync(string id) => await _products.Find(p => p.Id == id).FirstOrDefaultAsync();
    public async Task CreateProductAsync(Product product) => await _products.InsertOneAsync(product);
    public async Task<bool> UpdateProductAsync(string id, Product product) => (await _products.ReplaceOneAsync(p => p.Id == id, product)).IsAcknowledged;
    public async Task<bool> DeleteProductAsync(string id) => (await _products.DeleteOneAsync(p => p.Id == id)).IsAcknowledged;
}
