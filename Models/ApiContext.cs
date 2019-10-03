using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {

        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Tipo> Tipos { get; set; }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasSequence<int>("AutoIncrementProduto").StartsAt(1).IncrementsBy(1);
            modelBuilder.HasSequence<int>("AutoIncrementTipo").StartsAt(1).IncrementsBy(1);*/

            /*Sequencia criada para corrigir o bug do SqlServer com o Identity(1, 1) pulando de 1000 em 1000
             * (https://stackoverflow.com/questions/14146148/identity-increment-is-jumping-in-sql-server-database)
             * Mais tarde tentar uma solução melhor */

            /*modelBuilder.Entity<Produto>()
                .Property(p => p.Id)
                .HasDefaultValueSql("NEXT VALUE FOR AutoIncrementProduto");

            modelBuilder.Entity<Tipo>()
                .Property(t => t.Id)
                .HasDefaultValueSql("NEXT VALUE FOR AutoIncrementTipo");
        }*/
    }
}