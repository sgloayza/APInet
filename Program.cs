var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//dependencia
builder.Services.AddScoped<IHelloWorldService,HelloWorldService>();

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
