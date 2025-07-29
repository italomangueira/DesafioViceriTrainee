using System.ComponentModel.DataAnnotations;

namespace BackHero_CRUD.Domain.Entities
{
    public class Superpoderes
    {
        public int Id { get; set; }
        public string Superpoder { get; set; } = string.Empty;
        public string? Descricao { get; set; }

        public ICollection<HeroisSuperpoderes> HeroisSuperpoderes { get; set; } = new List<HeroisSuperpoderes>();
    }
}
