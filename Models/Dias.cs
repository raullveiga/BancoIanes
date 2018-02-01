using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ianes.Models
{
    public class Dias
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdDiaSemana { get; set; }

        [Required]
        public string DiaSemana { get; set; }

        [Required]
        public int IdChronograma { get; set; }
    }
}