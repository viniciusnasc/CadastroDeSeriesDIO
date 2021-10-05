using CadastroDeSeries.MVC.Data;
using CadastroDeSeries.MVC.Models;
using CadastroDeSeries.MVC.Models.Enums;
using CadastroDeSeries.MVC.Services.Exceptions;
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

        public void Inserir(Serie serie)
        {
            _context.Add(serie);
            _context.SaveChanges();
        }

        public Serie SelecionarPorId(int id)
        {
            return _context.Serie.FirstOrDefault(x => x.Id == id);
        }

        public void Remover(int id)
        {
            var obj = _context.Serie.Find(id);
            _context.Serie.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Serie serie)
        {
            if (!_context.Serie.Any(x => x.Id == serie.Id))
                throw new NotFoundException("Id não encontrado");

            try
            {
                _context.Update(serie);
                _context.SaveChanges();
            }
            catch (DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

        public List<Genero> ListarGenero()
        {
            List<Genero> list = new();
            list.Add(Genero.Aventura);
            list.Add(Genero.Acao);
            list.Add(Genero.Comedia);
            list.Add(Genero.Documentario);
            list.Add(Genero.Drama);
            list.Add(Genero.Suspense);
            list.Add(Genero.Terror);
            return list;
        }
    }
}
