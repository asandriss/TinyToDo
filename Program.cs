using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TinyToDo.Data;
using TinyToDo.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//  DbContext
builder.Services.AddDbContext<ToDoContext>(o => o.UseInMemoryDatabase("todo"));

//  Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Minimal API Demo - Simple ToDo",
        Description = "Demo of Minimal API",
        Version = "v1"
    }));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Simple ToDo"));
}

app.MapGet("/todo", async (ToDoContext db) => await db.Items.ToListAsync());

app.MapPost("/todo", async (ToDoContext db, ToDoItem item) =>
{
    await db.Items.AddAsync(item);
    await db.SaveChangesAsync();
    return Results.Created($"/todo/{item.Id}", item);
});

app.Run();
