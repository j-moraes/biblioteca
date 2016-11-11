using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Biblioteca.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nome do Usuário")]
        public string Nome { get; set; }
        [Required]
        [Display(Name = "RG")]
        public string RG { get; set; }
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email do Usuário")]
        public string eMail { get; set; }
        [Display(Name = "Sexo")]
        public string Sexo { get; set; }
        [Display(Name = "Ativo")]
        public bool Ativo { get; set; }

    }
}