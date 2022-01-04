using Gestao.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace Gestao.Data.Context
{
    public class GestaoDbContext: DbContext
    {
        public GestaoDbContext(DbContextOptions options) : base(options)   { }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
    }
}
