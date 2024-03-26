using Microsoft.EntityFrameworkCore;
using webapi;
using webapi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Conexion con la bd
builder.Services.AddSqlServer<TareasContext>("Data Source=DESKTOP-VR6TNQT\\SQLEXPRESS;Initial Catalog=TareasDb;user id=sa;password=contrasena;TrustServerCertificate=true");


// Dependencias con servicios e interfaces
builder.Services.AddScoped<IHelloWorldService,HelloWorldService>();           //1era manera
// builder.Services.AddScoped<IHelloWorldService>(p=> new HelloWorldService());    //2da manera

builder.Services.AddScoped<ICategoriaService,CategoriaService>();
builder.Services.AddScoped<ITareaService,TareaService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseCors()

app.UseAuthorization();

//app.UseWelcomePage();
//app.UseTimeMiddleware();             //middleware creado por nosotros

app.MapControllers();

app.Run();
