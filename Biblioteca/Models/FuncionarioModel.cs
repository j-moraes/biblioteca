using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Biblioteca.Models
{
    public class FuncionarioModel
    {
        public int Id { get; set; }
        
        [Required]
        [Display(Name = "Nome do Funcionário")]
        public string Nome { get; set; }

        [Display(Name = "Data de Nascimento")]
        [Column(TypeName = "DateTime2")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime Nascimento { get; set; }
        
        [Required]
        public string Nacionalidade { get; set; }
        
        [Required]
        public string Funcao { get; set; }

    }
}