var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddOpenApi("v1"); // Customize the document name

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Customize the endpoint route if needed
    app.MapOpenApi("/openapi/{documentName}.json");
}

app.UseHttpsRedirection();
app.Run();