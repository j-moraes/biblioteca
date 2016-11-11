using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Biblioteca.Models
{
    public class TipoAcervoModel
    {
        public int Id { get; set; }
        [Required] 
        [Display(Name="Nome do Tipo")]
        public string Descricao { get; set; }
    }
}