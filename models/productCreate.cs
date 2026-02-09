namespace MyFirstProject.Models;

public class ProductCreate
{
    public string Name { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public decimal Price { get; set; }
}
