using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CadastroDeSeries.MVC.Models;

namespace CadastroDeSeries.MVC.Data
{
    public class CadastroDeSeriesMVCContext : DbContext
    {
        public CadastroDeSeriesMVCContext (DbContextOptions<CadastroDeSeriesMVCContext> options)
            : base(options)
        {
        }

        public DbSet<Serie> Serie { get; set; }
    }
}
