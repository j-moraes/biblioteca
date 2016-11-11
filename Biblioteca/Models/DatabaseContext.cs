using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Biblioteca.Models
{
    public class UsersContext : DbContext
    {
        public UsersContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }

        public DbSet<TipoAcervoModel> TipoAcervoModels { get; set; }

        public DbSet<AutoresModel> AutoresModels { get; set; }

        public DbSet<UsuarioModel> UsuarioModels { get; set; }

        public DbSet<EditoraModel> EditoraModels { get; set; }

        public DbSet<AcervoModel> AcervoModels { get; set; }

        public DbSet<GerenciamentoAcervoModel> GerenciamentoAcervoModels { get; set; }

        public DbSet<FuncionarioModel> FuncionarioModels { get; set; }

        public DbSet<FolhaPagamentoModel> FolhaPagamentoModels { get; set; }

        public DbSet<FeriadoModel> FeriadoModels { get; set; }

        public System.Collections.IEnumerable ItemGerenciamentoAcervoModels { get; set; }

        public System.Collections.IEnumerable DescricaoAcervoModels { get; set; }
    }
}