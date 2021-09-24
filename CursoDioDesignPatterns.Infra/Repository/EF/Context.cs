using CursoDioDesignPatterns.Domain.Veiculo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CursoDioDesignPatterns.Infra.Repository.EF
{
   public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        public DbSet<Veiculo> veiculos { get; set; }
    }
}
