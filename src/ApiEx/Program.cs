var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSingleton<IList<string>>(_ => summaries.ToList());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/weatherforecast", ([AsParameters] FiltreTemperatures filtre, IList<string> data) =>
{
  var forecast = Enumerable.Range(1, filtre.Nombre).Select(index =>
      new WeatherForecast
      (
          DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
          Random.Shared.Next(filtre.Min, filtre.Max),
          data[Random.Shared.Next(data.Count)]
      ))
      .ToArray();
  return forecast;
})
.WithName("GetWeatherForecast")
.Produces<WeatherForecast[]>(StatusCodes.Status200OK)
.ProducesProblem(StatusCodes.Status400BadRequest)
.WithOpenApi(op =>
{
  op.Parameters[0].Description = "Température minimale";
  op.Parameters[1].Description = "Température maximale";
  op.Parameters[2].Description = "Nombre de températures";
  return op;
});

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
  public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
