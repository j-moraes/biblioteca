using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Biblioteca.Models
{
    public class FolhaPagamentoModel
    {
        public int Id { get; set; }
        [Required]
        
        public FuncionarioModel Funcionario { get; set; }
        [Required]

        public int Salario { get; set; }

        [Column(TypeName = "DateTime2")]
        [DataType(DataType.Date)]
        public DateTime DataAdmissao { get; set; }

        public bool Ativo { get; set; }

    }
}