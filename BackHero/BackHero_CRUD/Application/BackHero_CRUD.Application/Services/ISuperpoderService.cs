using BackHero_CRUD.Application.DTOs;

namespace BackHero_CRUD.Application.Services
{
    public interface ISuperpoderService
    {
        Task<List<SuperpoderDto>> ListarSuperpoderesAsync();
        Task<List<SuperpoderDto>> ObterPorIdsAsync(List<int> ids);
    }
}
