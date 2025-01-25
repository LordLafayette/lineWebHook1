var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapPost("/line/webhook",async (HttpRequest req)=>{
    // create StreamReader to read the request body
    using var reader = new StreamReader(req.Body);
    
    var body = await reader.ReadToEndAsync();
    
    return Results.Ok(body);
});

app.Run();