using BackHero_CRUD.Application.DTOs;

namespace BackHero_CRUD.Application.Services
{
    public interface IHeroiService
    {
        Task<HeroiDto> CriarAsync(CriarHeroiRequest request);
        Task<IEnumerable<HeroiDto>> ListarAsync();
        Task<HeroiDto?> ObterPorIdAsync(int id);
        Task<HeroiDto> AtualizarAsync(int id, CriarHeroiRequest request);
        Task<bool> RemoverAsync(int id);
    }
}
