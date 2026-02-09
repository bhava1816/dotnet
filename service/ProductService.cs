using System.Text;
using System.Text.Json;
using MyFirstProject.Models;

namespace MyFirstProject.Services;

public class ProductService
{
    private readonly HttpClient _client;

    public ProductService()
    {
        _client = new HttpClient
        {
            BaseAddress = new Uri("http://localhost:3333/")
        };
    }

    // GET
    public async Task<List<Product>> GetProducts()
    {
        var response = await _client.GetAsync("products");
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();

        var result =
            JsonSerializer.Deserialize<ApiResponse<List<Product>>>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        return result?.Data ?? new List<Product>();
    }

    // POST
    public async Task<Product?> CreateProduct(ProductCreate product)
    {
        var json = JsonSerializer.Serialize(product);

        var content = new StringContent(
            json,
            Encoding.UTF8,
            "application/json"
        );

        var response = await _client.PostAsync("products", content);
        response.EnsureSuccessStatusCode();

        var responseJson = await response.Content.ReadAsStringAsync();

        var result =
            JsonSerializer.Deserialize<ApiResponse<Product>>(responseJson,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        return result?.Data;
    }
}
