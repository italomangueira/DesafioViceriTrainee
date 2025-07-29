namespace BackHero_CRUD.Domain.Entities
{
    public class HeroisSuperpoderes
    {
        public int HeroiId { get; set; }
        public Herois Herois { get; set; }

        public int SuperpoderId { get; set; }
        public Superpoderes Superpoderes { get; set; }
    }
}
