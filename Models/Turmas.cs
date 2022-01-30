using System.ComponentModel.DataAnnotations;

namespace jeanFraga.Models
{
    public class Turmas
    {


          [Key]
          public int Id {get; set; }

          [MinLength(2, ErrorMessage = "The class name must be at minimum 2 characteres")]
          [MaxLength(20, ErrorMessage = "The class name must be at maximum of 20 characteres")]
          [Required(ErrorMessage = "Class name is required")]
          public string Name { get; set; }

        
    }
}