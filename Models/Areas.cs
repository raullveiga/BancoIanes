using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ianes.Models{
    public class Areas{

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdArea { get; set; }

        [Required]
        public string NomeArea { get; set; }
        
        public ICollection<Cursos> Curso{get;set;}
    }
}