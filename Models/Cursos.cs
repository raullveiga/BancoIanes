using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ianes.Models
{
    public class Cursos
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCurso { get; set; }
        
        [Required]
        public string NomeCurso { get; set; }

        [Required]
        public Areas AreaCurso { get; set; }

        public ICollection<Cronogramas> Cronograma { get; set; }
    }
}