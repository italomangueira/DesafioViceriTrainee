using System.ComponentModel.DataAnnotations;

namespace BackHero_CRUD.Domain.Entities
{
    public class Herois
    {
        public int Id { get;  set; }
        public string Nome { get;  set; } = string.Empty;
        public string NomeHeroi { get; set; } = string.Empty;
        public DateTime? DataNascimento { get; set; }
        public float Altura { get; set; }
        public float Peso { get; set; }

        public ICollection<HeroisSuperpoderes> HeroisSuperpoderes { get; set; } = new List<HeroisSuperpoderes>();

        
    }

}
