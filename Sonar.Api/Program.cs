

using Sonar.Infra;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Sonar.Application.UseCases.User.GetUserQuery>());

builder.Services.AddInfraServices(); // Register infrastructure services

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();
app.MapControllers();
app.MapGet("/", () => "Welcome to the Web API!");
app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

// dotnet watch run 
// dotnet watch run --verbosity detailed


// | Comando                              | Descrição                                    |
// | ------------------------------------ | -------------------------------------------- |
// | `dotnet new xunit -n MinhaApi.Tests` | Cria projeto de testes xUnit.                |
// | `dotnet test`                        | Roda todos os testes.                        |
// | `dotnet watch test`                  | Roda os testes em tempo real com hot reload. |


// | Comando                              | Descrição                    |
// | ------------------------------------ | ---------------------------- |
// | `dotnet add package NomeDoPacote`    | Instala um pacote NuGet.     |
// | `dotnet list package`                | Lista pacotes instalados.    |
// | `dotnet remove package NomeDoPacote` | Remove um pacote.            |
// | `dotnet restore`                     | Restaura pacotes do projeto. |


// | Comando                  | Descrição                          |
// | ------------------------ | ---------------------------------- |
// | `dotnet --info`          | Mostra info sobre SDKs e ambiente. |
// | `dotnet --list-sdks`     | Lista SDKs instalados.             |
// | `dotnet --list-runtimes` | Lista runtimes disponíveis.        |


// | Comando                            | Descrição                             |
// | ---------------------------------- | ------------------------------------- |
// | `dotnet new --list`                | Lista todos os templates disponíveis. |
// | `dotnet tool install -g dotnet-ef` | Instala Entity Framework globalmente. |
// | `dotnet ef migrations add Initial` | Cria uma migration.                   |
// | `dotnet ef database update`        | Aplica a migration no banco.          |
