using BackHero_CRUD.Domain.Entities;

namespace BackHero_CRUD.Domain.Interfaces
{
    public interface ISuperpoderRepository
    {
        Task<List<Superpoderes>> ObterTodosAsync();
        Task<List<Superpoderes>> ObterPorIdsAsync(List<int> ids);
    }
}
