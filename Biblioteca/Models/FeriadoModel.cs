using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Biblioteca.Models
{
    public class FeriadoModel
    {
        public int Id { get; set; }
        [Display(Name = "Feriado")]
        public string Descriao { get; set; }
        [Display(Name = "Data do Feriado")]
        [Column(TypeName = "DateTime2")]
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }
    }
}