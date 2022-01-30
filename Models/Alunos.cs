
using System.ComponentModel.DataAnnotations;

namespace jeanFraga.Models
{
    public class Alunos
    {
        [Key]
        public int Id { get; set; }

        [MinLength(4, ErrorMessage = "The class name must be at minimum 4 characteres")]
        [MaxLength(90, ErrorMessage = "The class name must be at maximum of 90 characteres")]
        [Required(ErrorMessage = " Name field is required")]

        public string Name { get; set;}  

        [Range (1, int.MaxValue, ErrorMessage = "Turma inválida")]
        public int TurmasId { get; set;}
        public Turmas Turma { get; set; }
    }
}