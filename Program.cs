using MyFirstProject.Services;
using MyFirstProject.Models;

Console.WriteLine("Program started");

// create service
var service = new ProductService();

// GET products
var products = await service.GetProducts();
Console.WriteLine($"Total products: {products.Count}");

foreach (var p in products)
{
    Console.WriteLine($"{p.Name} | {p.Brand} | ₹{p.Price}");
}

// POST product
var newProduct = new ProductCreate
{
    Name = "Speed Runner",
    Brand = "Nike",
    Price = 1999
};

var created = await service.CreateProduct(newProduct);

if (created != null)
{
    Console.WriteLine("Product created:");
    Console.WriteLine($"{created.Name} | {created.Brand} | ₹{created.Price}");
}

Console.WriteLine("Program finished");
