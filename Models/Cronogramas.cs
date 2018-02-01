using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ianes.Models
{
    public class Cronogramas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCronograma { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DataInicio { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DataFim { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime HoraInicio { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime HoraFim { get; set; }

        public ICollection<Dias> DiaCronograma { get; set; }
        public Cursos Curso { get; set; }
    }
}