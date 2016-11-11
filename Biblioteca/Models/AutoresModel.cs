using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Biblioteca.Models
{
    public class AutoresModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nome do Autor")]
        public string Nome { get; set; }
        [Required]
        [Display(Name = "Nacionalidade")]
        public string Nacionalidade { get; set; }
        [Display(Name = "Perfil")]
        public string Perfil { get; set; }
      

    }
}