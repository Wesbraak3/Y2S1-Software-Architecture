using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using MongoDB.Bson.Serialization;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var client = new MongoClient("mongodb://localhost:27017");

app.MapPost("/query/{db}/{collection}", async (string db, string collection, HttpRequest req) =>
{
    using var reader = new StreamReader(req.Body);
    var body = await reader.ReadToEndAsync();

    // Body is the raw Mongo filter, e.g. { "age": { "$gt": 30 } }
    var filter = string.IsNullOrWhiteSpace(body) ? new BsonDocument() : BsonDocument.Parse(body);

    var docs = await client.GetDatabase(db)
        .GetCollection<BsonDocument>(collection)
        .Find(filter)
        .ToListAsync();

    var json = new BsonArray(docs).ToJson(new JsonWriterSettings { OutputMode = JsonOutputMode.RelaxedExtendedJson });
    return Results.Content(json, "application/json");
});

app.MapPost("/insert/{db}/{collection}", async (string db, string collection, HttpRequest req) =>
{
    using var reader = new StreamReader(req.Body);
    var body = (await reader.ReadToEndAsync()).Trim();

    var col = client.GetDatabase(db).GetCollection<BsonDocument>(collection);

    // Accepts a single document { ... } or an array [ {...}, {...} ]
    if (body.StartsWith("["))
    {
        var docs = BsonSerializer.Deserialize<BsonArray>(body).Select(d => d.AsBsonDocument).ToList();
        await col.InsertManyAsync(docs);
        return Results.Ok(new { inserted = docs.Count });
    }

    await col.InsertOneAsync(BsonDocument.Parse(body));
    return Results.Ok(new { inserted = 1 });
});

app.Run();