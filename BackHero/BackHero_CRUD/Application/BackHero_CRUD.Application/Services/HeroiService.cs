using BackHero_CRUD.Application.DTOs;
using BackHero_CRUD.Domain.Entities;
using BackHero_CRUD.Domain.Interfaces;

namespace BackHero_CRUD.Application.Services
{
    public class HeroiService : IHeroiService
    {
        private readonly IHeroiRepository _repo;
        private readonly ISuperpoderRepository _superpoderRepo;

        public HeroiService(IHeroiRepository repo, ISuperpoderRepository superpoderRepo)
        {
            _repo = repo;
            _superpoderRepo = superpoderRepo;
        }

        public async Task<HeroiDto> CriarAsync(CriarHeroiRequest request)
        {
            var existeHeroi = await _repo.ObterTodosAsync();
            if (existeHeroi.Any(x => x.NomeHeroi == request.NomeHeroi))
                throw new ApplicationException($"Já existe um Heroi com esse Nome Heroi: {request.NomeHeroi}");


            var superpoderesSelecionados = await _superpoderRepo.ObterPorIdsAsync(request.SuperpoderesIds);
            if (superpoderesSelecionados.Count != request.SuperpoderesIds.Count)
                throw new ApplicationException("Selecione um ou mais super poderes.");

            var heroi = new Herois
            {
                Nome = request.Nome,
                NomeHeroi = request.NomeHeroi,
                DataNascimento = request.DataNascimento,
                Altura = float.Parse(request.Altura.ToString("F")),
                Peso = float.Parse(request.Peso.ToString("F")),
                HeroisSuperpoderes = new List<HeroisSuperpoderes>()
            };

            foreach (var sp in superpoderesSelecionados)
            {
                heroi.HeroisSuperpoderes.Add(new HeroisSuperpoderes { Herois = heroi, Superpoderes = sp });
            }

            await _repo.AdicionarAsync(heroi);
            return MapToDto(heroi);
        }

        public async Task<IEnumerable<HeroiDto>> ListarAsync()
        {
            var herois = await _repo.ObterTodosAsync();
            return herois.Select(MapToDto);
        }

        public async Task<HeroiDto?> ObterPorIdAsync(int id)
        {
            var heroi = await _repo.ObterPorIdAsync(id);
            return heroi != null ? MapToDto(heroi) : null;
        }

        public async Task<HeroiDto> AtualizarAsync(int id, CriarHeroiRequest request)
        {
            var heroi = await _repo.ObterPorIdAsync(id); 
            if (heroi == null)
                throw new Exception("Herói não encontrado.");

            heroi.Nome = request.Nome;
            heroi.NomeHeroi = request.NomeHeroi;
            heroi.DataNascimento = request.DataNascimento;
            heroi.Altura = float.Parse(request.Altura.ToString("F"));
            heroi.Peso = float.Parse(request.Peso.ToString("F"));

            var superpoderes = await _superpoderRepo.ObterPorIdsAsync(request.SuperpoderesIds);
            heroi.HeroisSuperpoderes.Clear();
            foreach (var sp in superpoderes)
            {
                heroi.HeroisSuperpoderes.Add(new HeroisSuperpoderes { HeroiId = heroi.Id, SuperpoderId = sp.Id });
            }

            await _repo.AtualizarAsync(heroi);
            return MapToDto(heroi);
        }

        public async Task<bool> RemoverAsync(int id)
        {
            var heroi = await _repo.ObterPorIdAsync(id);
            if (heroi == null)
                return false;

            await _repo.RemoverAsync(heroi);
            return true;
        }

        private HeroiDto MapToDto(Herois heroi)
        {
            return new HeroiDto
            {
                Id = heroi.Id,
                Nome = heroi.Nome,
                NomeHeroi = heroi.NomeHeroi,
                DataNascimento = heroi.DataNascimento,
                Altura = heroi.Altura,
                Peso = heroi.Peso,
                Superpoderes = heroi.HeroisSuperpoderes.Select(s => new SuperpoderDto
                {
                    Id = s.Superpoderes.Id,
                    SuperPoder = s.Superpoderes.Superpoder,
                    Descricao = s.Superpoderes.Descricao
                }).ToList()
            };
        }
    }
}
