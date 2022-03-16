using System.Reflection;
using FactoryWithDI.Math.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.RegisterMathOperations(Assembly.GetExecutingAssembly());

var app = builder.Build();

app.UseRouting();
app.MapControllers();

app.Run();