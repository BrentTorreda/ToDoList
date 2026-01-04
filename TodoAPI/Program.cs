using TodoAPI.Core.Interfaces;
using TodoAPI.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ITodoRepository, InMemoryTodoRepository>();
builder.Services.AddCors();

var app = builder.Build();

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.MapGet("/api/todos", (ITodoRepository repo) => Results.Ok(repo.GetAll()));

app.MapPost("/api/todos", (string title, ITodoRepository repo) =>
    string.IsNullOrWhiteSpace(title) ? Results.BadRequest() : Results.Ok(repo.Add(title)));

app.MapDelete("/api/todos/{id}", (int id, ITodoRepository repo) =>
    repo.Delete(id) ? Results.NoContent() : Results.NotFound());

app.Run();