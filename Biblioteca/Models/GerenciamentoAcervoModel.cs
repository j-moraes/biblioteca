using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Biblioteca.Models
{
    public class GerenciamentoAcervoModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Selecione um usuário")]
        [Display(Name = "Nome do Usuário")]
        public UsuarioModel usuario { get; set; }
        [Required]
        [Display(Name = "Acervo")]
        public AcervoModel Item { get; set; }
        [Display(Name = "Data de Retirada")]
        [Column(TypeName = "DateTime2")]
        [DataType(DataType.Date)]
        public DateTime DataRetirada { get; set; }
        [Column(TypeName = "DateTime2")]
        [DataType(DataType.Date)]
        [Display(Name = "Data de Devolução")]
        public DateTime DataDevolucao { get; set; }
        public bool saida { get; set; }
        public string observacao { get; set; }
        [NotMapped]
        public int usuarioId { get; set; }
        [NotMapped]
        public int acervoId { get; set; }

        public static int ItemId { get; set; }

        public AcervoModel Descricao { get; set; }
    }
}