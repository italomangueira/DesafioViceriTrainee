using BackHero_CRUD.Domain.Entities;
using BackHero_CRUD.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BackHero_CRUD.Infrastructure.Repositories
{
    public class SuperpoderRepository : ISuperpoderRepository
    {
        private readonly HeroDbContext _context;

        public SuperpoderRepository(HeroDbContext context)
        {
            _context = context;
        }

        public async Task<List<Superpoderes>> ObterTodosAsync()
        {
            return await _context.Superpoderes
                                 .OrderBy(sp => sp.Superpoder)
                                 .ToListAsync();
        }

        public async Task<List<Superpoderes>> ObterPorIdsAsync(List<int> ids)
        {
            return await _context.Superpoderes
                               .Where(sp => ids.Contains(sp.Id))
                               .ToListAsync();
        }
    }
}
