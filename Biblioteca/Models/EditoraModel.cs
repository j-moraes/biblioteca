using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Biblioteca.Models
{
    public class EditoraModel
    {
        public int id { get; set; }
        [Required]
        [Display(Name = "digite o nome da editora: ")]
        public string nome { get; set; }

        [Required]
        [Display(Name = "digite o endereço da editora: ")]
        public string endereco { get; set; }
        [Required]
        [Display(Name = "digite o telefône da editora: ")]
        public string telefone { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "digite o e-mail da editora: ")]
        public string email { get; set; }

    }
}