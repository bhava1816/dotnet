using System.Collections.Generic;
using System.Text.Json.Serialization;

public class Product
{
    [JsonPropertyName("_id")]
    public string Id { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public double Rating { get; set; }
    public List<int> Sizes { get; set; } = new();
    public int Stock { get; set; }
}
