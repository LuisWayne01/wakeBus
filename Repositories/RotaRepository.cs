using PontoDesperta.Api.Models;
using PontoDesperta.Api.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PontoDesperta.Api.Repositories
{
    public class RotaRepository : IRotaRepository
    {
        private readonly List<Rota> _bancoDeDadosSimulado;

        public RotaRepository()
        {
            _bancoDeDadosSimulado = new List<Rota>
            {
                new Rota { 
                    Id = 1, 
                    Codigo = "5106", 
                    NomeDescritivo = "Bandeirantes / BH Shopping", 
                    Pontos = new List<Ponto>
                    {
                        new Ponto { Id = 101, Latitude = -19.9227, Longitude = -43.9451, DescricaoLocal = "Av. Afonso Pena, 1500" },
                        new Ponto { Id = 102, Latitude = -19.9332, Longitude = -43.9378, DescricaoLocal = "Praça da Savassi" }
                    }
                }
            };
        }

        public async Task<Rota?> ObterRotaPorCodigoAsync(string codigo)
        {
            await Task.Delay(100); 
            return _bancoDeDadosSimulado.FirstOrDefault(r => r.Codigo == codigo);
        }

        public async Task<IEnumerable<Rota>> ListarTodasRotasAsync()
        {
            await Task.Delay(100);
            return _bancoDeDadosSimulado;
        }
        // Adicione este bloco de código no final da classe RotaRepository:
        public async Task AdicionarRotaAsync(Rota novaRota)
        {
            await Task.Delay(100); // Simula o tempo de guardar na base de dados
            
            // Gera um ID fictício somando 1 ao maior ID existente
            novaRota.Id = _bancoDeDadosSimulado.Max(r => r.Id) + 1;
            
            // Adiciona a nova rota à nossa lista em memória
            _bancoDeDadosSimulado.Add(novaRota);
        }
    }
}