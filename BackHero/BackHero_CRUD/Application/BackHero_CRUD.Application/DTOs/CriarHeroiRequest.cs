using System.ComponentModel.DataAnnotations;

namespace BackHero_CRUD.Application.DTOs
{
    public class CriarHeroiRequest
    {
        [Required, MaxLength(120)]
        public string Nome { get; set; } = string.Empty;

        [Required, MaxLength(120)]
        public string NomeHeroi { get; set; } = string.Empty;

        public DateTime DataNascimento { get; set; }

        [Required]
        public float Altura { get; set; }

        [Required]
        public float Peso { get; set; }

        [Required, MinLength(1, ErrorMessage = "Selecione ao menos um superpoder.")]
        public List<int> SuperpoderesIds { get; set; }
    }
}
