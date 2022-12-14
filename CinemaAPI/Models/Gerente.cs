using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CinemaAPI.Models
{
    public class Gerente
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Nome { get; set; }
        [JsonIgnore]
        public virtual List<Cinema> Cinemas { get; set; }
        
    }
}
