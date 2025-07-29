using BackHero_CRUD.Application.DTOs;
using BackHero_CRUD.Domain.Interfaces;

namespace BackHero_CRUD.Application.Services
{
    public class SuperpoderService : ISuperpoderService
    {
        private readonly ISuperpoderRepository _repo;

        public SuperpoderService(ISuperpoderRepository repo)
        {
            _repo = repo;
        }
        public async Task<List<SuperpoderDto>> ListarSuperpoderesAsync()
        {
            var poderes = await _repo.ObterTodosAsync();
            return poderes.Select(p => new SuperpoderDto
            {
                Id = p.Id,
                SuperPoder = p.Superpoder,
                Descricao = p.Descricao
            }).ToList();
        }

        public async Task<List<SuperpoderDto>> ObterPorIdsAsync(List<int> ids)
        {
            var poderes = await _repo.ObterPorIdsAsync(ids);
            return poderes.Select(p => new SuperpoderDto
            {
                Id = p.Id,
                SuperPoder = p.Superpoder,
                Descricao = p.Descricao
            }).ToList();
        }
    }
}
