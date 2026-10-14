using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using PontoDesperta.Api.Repositories.Interfaces;
using PontoDesperta.Api.Repositories;
using PontoDesperta.Api.Models;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IRotaRepository, RotaRepository>();
builder.Services.AddCors();

var app = builder.Build();

app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

// ENDPOINT 1: Buscar Rota 
app.MapGet("/api/rotas/{codigo}", async (string codigo, IRotaRepository repository) =>
{
    var rota = await repository.ObterRotaPorCodigoAsync(codigo);
    if (rota is null) return Results.NotFound(new { Mensagem = "Linha de autocarro não encontrada." });
    return Results.Ok(new { Mensagem = "Rota descarregada com sucesso.", Dados = rota });
});

// ENDPOINT 2: CADASTRAR NOVA ROTA 
app.MapPost("/api/rotas", async (Rota novaRota, IRotaRepository repository) =>
{
    await repository.AdicionarRotaAsync(novaRota);
    return Results.Created($"/api/rotas/{novaRota.Codigo}", new { Mensagem = "Rota criada com sucesso!", Dados = novaRota });
});

app.Run();