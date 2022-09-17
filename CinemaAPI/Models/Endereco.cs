using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CinemaAPI.Models
{
    public class Endereco
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Logradouro { get; set; }
        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Bairro { get; set; }
        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public int Numero { get; set; }
        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Cidade { get; set; }
        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Estado { get; set; }
        [JsonIgnore]
        public virtual Cinema Cinema { get; set; }
        

    }
}
