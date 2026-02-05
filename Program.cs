using System;
using System.Net.Http;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;

// ---------- TOP-LEVEL CODE FIRST ----------
Console.WriteLine("Hello, World!");

using var client = new HttpClient();
client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");

var response = await client.GetAsync("posts");

if (response.IsSuccessStatusCode)
{
    var json = await response.Content.ReadAsStringAsync();//itis used to covert response body  into cshap string

    var posts = JsonSerializer.Deserialize<List<Post>>(json)//it is used to convert the json to object and nullish value is happen when the json is null it crashed to improve it we are using it
                ?? new List<Post>();//data type of the list must be the class name 

//     foreach (var p in posts)//to retriview all the data from the lst or array
// {
//     string jsonObject = JsonSerializer.Serialize(//it is used to to change the object in to json
//         p,
//         new JsonSerializerOptions { WriteIndented = true }//this line is used to put json in a formate and cleanable way
//     );

//     Console.WriteLine(jsonObject);
// }


//     var result = posts//linq it is used to filter the id =5 and make id in decsending order and after select particular field title and take first three object result
//         .Where(p => p.userId == 5)
//         .OrderByDescending(p => p.id)
//         .Select(p => p.title)
//         .Take(3);
// var results=posts.Where(p=>p.userId==1);//it is used to filter where the id=1 using forloop we are retriew the data
// foreach(var i in results)
//     {
//         Console.WriteLine(
//         $"UserId: {i.userId}, Id: {i.id}, Title: {i.title}"
//     );
//     }
//     Console.WriteLine(
//     JsonSerializer.Serialize(posts[9],
//     new JsonSerializerOptions { WriteIndented = true })
// );
var titledetails=posts.Select(p=>p.title);//retriew the all title from the object
foreach(var i in titledetails)
    {
        Console.WriteLine(i);
    }
var iddetailsdescending=posts.Select(p=>p.id).OrderByDescending(id=>id);//retreview the dat from the object with descending order
foreach(var i in iddetailsdescending)
    {
        Console.WriteLine(i);
    }

var groupedPosts = posts.GroupBy(p => p.userId);

foreach (var group in groupedPosts)
{
    Console.WriteLine($"UserId: {group.Key}");

    foreach (var post in group)
    {
        Console.WriteLine($"  - {post.title}");
    }

    Console.WriteLine();
}
var existvalue=posts.Exists(p=>p.title=="LINQ");//checking wheather the title present in the object
Console.WriteLine(existvalue);
var postvalue=posts.Where(p=>p.id==3);//getting specific id details
foreach(var i in postvalue)
    {
        Console.WriteLine(JsonSerializer.Serialize(i,new JsonSerializerOptions {WriteIndented=true})//json formate
        );
        Console.WriteLine($"userId:{i.userId} id:{i.id} title:{i.title} body:{i.body}");//getting individual formate
    }
var maximunpost=posts.Select(p=>p.userId).Max();
  
        Console.WriteLine(maximunpost);
    
var covertobject=posts.Where(p=>p.userId==2);//coverting an praticular element object into 
foreach(var i in covertobject)
    {
        Console.WriteLine(JsonSerializer.Serialize(i,new JsonSerializerOptions{WriteIndented=true}));
    }
var fulldetails=posts.Where(p=>p.userId==10);//retriview the data by using the id change into the json formate output
foreach(var i in fulldetails)
    {
        Console.WriteLine(JsonSerializer.Serialize(i,new JsonSerializerOptions {WriteIndented=true})
        );
    }


}


Console.ReadLine();

// ---------- TYPE DECLARATIONS LAST ----------
public class Post
{
    public int userId { get; set; }
    public int id { get; set; }
    public string ? title { get; set; }
    public string ? body { get; set; }
}
