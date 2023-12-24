using System.ComponentModel.DataAnnotations;

namespace cadastro10.Models
{
    public class Pessoa
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [StringLength(100)]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Somente letras e espaços são permitidos no nome.")]
        public string Nome { get; set; }
    }
}
