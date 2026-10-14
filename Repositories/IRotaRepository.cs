using PontoDesperta.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PontoDesperta.Api.Repositories.Interfaces
{
    public interface IRotaRepository
    {
        Task<Rota?> ObterRotaPorCodigoAsync(string codigo);
        Task<IEnumerable<Rota>> ListarTodasRotasAsync();
        
        // NOVA LINHA: Método para adicionar uma nova rota
        Task AdicionarRotaAsync(Rota novaRota); 
    }
}