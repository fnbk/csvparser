// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Linq;

Console.WriteLine("Hello, World!");



Console.WriteLine();
Console.WriteLine("######################################");
Console.WriteLine("# v1 - Ursprüngliche Idee");
Console.WriteLine("######################################");
Console.WriteLine();

{
    // read json into objects
    StreamReader file = File.OpenText(@"products.json");
    JsonTextReader reader = new JsonTextReader(file);
    JArray arr = (JArray)JToken.ReadFrom(reader);

    // reduce list by filtering by max price
    var maxElem = arr.Aggregate(new JObject(), (acc, x) =>
    {
        if ((float)Convert.ToDecimal((acc["price"])) > (float)Convert.ToDecimal(x["price"]))
        {
            return acc;
        }
        else
        {
            return (JObject)x;
        }
    });

    // output
    Console.WriteLine($"price: {maxElem["price"]}");
    Console.WriteLine($"title: {maxElem["title"]}");
}




Console.WriteLine();
Console.WriteLine("######################################");
Console.WriteLine("# v2 - direkteste Art und Weise");
Console.WriteLine("######################################");
Console.WriteLine();

{
    // read file into Newtonsoft json representation
    JToken jToken = JToken.ReadFrom(new JsonTextReader(File.OpenText(@"products.json")));

    // filter
    var max = jToken.MaxBy(p => p["price"]);

    // output
    Console.WriteLine($"price: {max["price"]}");
    Console.WriteLine($"title: {max["title"]}");
}
