using BackHero_CRUD.Domain.Entities;
using BackHero_CRUD.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BackHero_CRUD.Infrastructure.Repositories
{
    public class HeroRepository : IHeroiRepository
    {
        private readonly HeroDbContext _context;

        public HeroRepository(HeroDbContext context)
        {
            _context = context;
        }

        public async Task AdicionarAsync(Herois heroi)
        {
            await _context.Herois.AddAsync(heroi);
            await _context.SaveChangesAsync();
        }


        public async Task AtualizarAsync(Herois heroi)
        {
          

            _context.Herois.Update(heroi);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(Herois heroi)
        {
            _context.Herois.Remove(heroi);
            await _context.SaveChangesAsync();
        }

        public async Task<Herois?> ObterPorIdAsync(int id)
        {
            return await _context.Herois
                .Include(h => h.HeroisSuperpoderes)
                .ThenInclude(hs => hs.Superpoderes)
                .FirstOrDefaultAsync(h => h.Id == id);
        }

        public async Task<IEnumerable<Herois>> ObterTodosAsync()
        {
            return await _context.Herois
                .Include(h => h.HeroisSuperpoderes)
                .ThenInclude(hs => hs.Superpoderes)
                .ToListAsync();
        }
    }
}
