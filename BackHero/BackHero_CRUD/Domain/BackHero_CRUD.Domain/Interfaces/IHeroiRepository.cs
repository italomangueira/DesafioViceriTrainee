using BackHero_CRUD.Domain.Entities;

namespace BackHero_CRUD.Domain.Interfaces
{
    public interface IHeroiRepository
    {
        Task<Herois?> ObterPorIdAsync(int id);
        Task<IEnumerable<Herois>> ObterTodosAsync();
       // Task<bool> ExisteNomeHeroiAsync(string nomeHeroi, int? ignorarId = null);
        Task AdicionarAsync(Herois heroi);
        Task AtualizarAsync(Herois heroi);
        Task RemoverAsync(Herois heroi);
    }
}
