// Arquivo: Models/Rota.cs
namespace PontoDesperta.Api.Models
{
    public class Rota 
    { 
        public int Id { get; set; } 
        public string Codigo { get; set; } = string.Empty;
        public string NomeDescritivo { get; set; } = string.Empty;
        public List<Ponto> Pontos { get; set; } = new();
    }

    public class Ponto 
    { 
        public int Id { get; set; } 
        public double Latitude { get; set; } 
        public double Longitude { get; set; } 
        public string DescricaoLocal { get; set; } = string.Empty;
    }
}