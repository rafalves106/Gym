using Application.UseCases;
using Domain.Repositories;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<GymDbContext>(options =>
    options.UseSqlite("Data Source = gym.db"));

builder.Services.AddScoped<ITreinoRepository, TreinoRepository>();

builder.Services.AddScoped<ICriarTreinoUseCase, CriarTreinoUseCase>();
builder.Services.AddScoped<IEditarTreinoUseCase, EditarTreinoUseCase>();
builder.Services.AddScoped<IRemoverTreinoUseCase, RemoverTreinoUseCase>();
builder.Services.AddScoped<IListarTreinosUseCase, ListarTreinosUseCase>();
builder.Services.AddScoped<IBuscarTreinoUseCase, BuscarTreinoUseCase>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "Swagger"));
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();