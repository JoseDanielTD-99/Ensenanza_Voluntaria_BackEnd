using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Models
{
    public class InstitucionViewModel
    {
        public InstitucionViewModel()
        {
            TutoriaCursos = new HashSet<TutoriaCurso>();
        }

        [Key]
        public int IdInstitucion { get; set; }

        [Display(Name = "Nombre de la institución")]
        public string Nombre { get; set; }

        public virtual ICollection<TutoriaCurso> TutoriaCursos { get; set; }
    }
}
