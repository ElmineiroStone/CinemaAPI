using System.ComponentModel.DataAnnotations;

namespace CinemaAPI.Data.Dtos.Gerente
{
    public class CreateGerenteDto
    {
        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Nome { get; set; }
    }
}
