using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Biblioteca.Models
{
    public class AcervoModel
    {

        public int Id { get; set; }

        [Required]
        [Display(Name = "Descriçao do Acervo")]
        public string Descricao { get; set; }

        [Required]
        [Display(Name = "Ano")]
        public int Ano { get; set; }

        [Required]
        [Display(Name = "Estoque")]
        public int Estoque { get; set; }

        
        [Display(Name = "Nome do Autor")]
        public AutoresModel Autor { get; set; }

        [Display(Name = "Nome da Editora")]
        public EditoraModel Editora { get; set; }
       
        [Display(Name = "Tipo do Acervo")]
        public TipoAcervoModel Tipo { get; set; }

        [Required]
        [Display(Name = "Genero")]
        public string Genero { get; set; }

        [Required]
        [Display(Name = "Ediçao")]
        public int Edicao { get; set; }

        [Required]
        [Display(Name = "Volume")]
        public string Volume { get; set; }

        [Required]
        [Display(Name = "Paginas")]
        public int Paginas { get; set; }

        [Required(ErrorMessage="Selecione um tipo de acervo")]
        [NotMapped]
        public int TipoAcervoId { get; set; }

        [Required(ErrorMessage = "Selecione uma Editora")]
        [NotMapped]
        public int EditoraId { get; set; }

        [Required(ErrorMessage = "Selecione um autor")]
        [NotMapped]
        public int AutorId { get; set; }


        public int DescricaoId { get; set; }
    }
}


