using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroFilmesSeries.Data.ContextDB
{
    class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        { }


    }
}
