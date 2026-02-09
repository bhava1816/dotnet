using System;
using System.Net.Http;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class NodeFile //logical container for apli logic
{
    public async Task RunAsync() //as async method allows non-blocking operations (network calling)
    {
        using var client = new HttpClient();//make http calls

        var url = "http://localhost:3333/products";
        Console.WriteLine("Calling API: " + url);

        var response = await client.GetAsync(url);//sends http get await pauses execution until response arrives

        Console.WriteLine("HTTP Status: " + response.StatusCode);//confirms server response

        var json = await response.Content.ReadAsStringAsync();//converts response body to string this raw json test

        Console.WriteLine("RAW JSON ↓↓↓");
        Console.WriteLine(json);//debugging
        Console.WriteLine("RAW JSON ↑↑↑");

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var apiResponse =
            JsonSerializer.Deserialize<ApiResponse<List<Product>>>(json, options);//Reads JSON Matches keys → properties Builds object graph in memory If shape mismatches → exception.

        if (apiResponse == null || apiResponse.Data == null)
        {
            Console.WriteLine("❌ Deserialization failed");
            return;
        }

        Console.WriteLine($"Total products: {apiResponse.Data.Count}");

        var bhavaProducts = apiResponse.Data
            .Where(p => p.Brand.Equals("BHAVA", StringComparison.OrdinalIgnoreCase));

        Console.WriteLine("Filtered (BHAVA):");

        foreach (var p in bhavaProducts)
        {
            Console.WriteLine($"{p.Name} | ₹{p.Price}");
        }
        var selctmethod=apiResponse.Data.Where(p=>!string.IsNullOrWhiteSpace(p.Id)).ToList();
        foreach (var p in selctmethod)
        {
            Console.WriteLine(p.Brand);
        }

        Console.WriteLine("linq and property methods are using for the output");
        //problem 1
        var productsid=apiResponse.Data.Where(p=>p.Id!=null);
        foreach(var i in productsid)
        {
            Console.WriteLine($"{i.Brand}-{i.Price}-{i.Stock}");
        }
        //problem 2
        var productstock=apiResponse.Data.Where(p=>p.Stock>0).OrderBy(p=>p.Stock);
        foreach(var i in productstock)
        {
            Console.WriteLine($"{i.Stock}-{i.Brand}");
        }
        //problem 3
         var nikeProducts =
    apiResponse.Data
        .Where(p =>
            p.Brand != null &&
            p.Brand.Equals("Nike", StringComparison.OrdinalIgnoreCase) &&
            p.Price < 2500)
        .OrderBy(p => p.Price);

foreach (var i in nikeProducts)
{
    Console.WriteLine($"{i.Brand} - {i.Price}");
}
Console.WriteLine("secound level");
        //level-2
        var returnonly=apiResponse.Data.Where(p=>p.Id!=null).Select(g=>new{Name=g.Brand,price=g.Price});
        foreach(var i in returnonly)
        {
            Console.WriteLine(i);
        }
        //level-3
        Console.WriteLine("third level");
        var groupingproducts=apiResponse.Data.Where(p=>p.Brand!=null).GroupBy(p=>p.Brand).Select(g=>new{key=g.Key,value=g.Count()});
        foreach(var i in groupingproducts)
        {
            Console.WriteLine(i);
        }
    }
}
