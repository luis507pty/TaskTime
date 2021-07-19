using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PeopleCrud.Models
{
    public class TaskViewValidation
    {
        [Required] 
        [MaxLength(250,ErrorMessage ="El camopo {0}, No puede contener mas de 250 caracteres")]
        public string Nombre { get; set; } 

        [Required]
        [MaxLength(500, ErrorMessage = "El camopo {0}, No puede contener mas de 500 caracteres")]
        public string Descripcion { get; set; }  
        public int id { get; set; }
    }
}