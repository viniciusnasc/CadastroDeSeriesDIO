using CadastroDeSeries.MVC.Data;
using CadastroDeSeries.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroDeSeries.MVC.Services
{
    public class SeriesService
    {
        private readonly CadastroDeSeriesMVCContext _context;

        public SeriesService(CadastroDeSeriesMVCContext context)
        {
            _context = context;
        }

        public List<Serie> ListarTudo()
        {
            return _context.Serie.ToList();
        }
    }
}
