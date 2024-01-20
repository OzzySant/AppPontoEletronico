using Core.Entidades.App;
using Infra.IOC;

var builder = WebApplication.CreateBuilder(args);
var configuracao = new ConfiguracaoAmbiente();
builder.Configuration.GetSection("ConfiguracaoAmbiente").Bind(configuracao);
builder.Services.AddSingleton(configuracao);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "default",
                      policy =>
                      {
                          policy.AllowAnyHeader();
                          policy.AllowAnyMethod();
                          policy.AllowAnyOrigin();
                      });
});



builder.Services.InjetarDependencias();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseCors("default");

app.Run();
