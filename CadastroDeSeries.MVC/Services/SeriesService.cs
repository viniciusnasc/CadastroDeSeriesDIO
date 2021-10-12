using CadastroDeSeries.MVC.Data;
using CadastroDeSeries.MVC.Models;
using CadastroDeSeries.MVC.Models.Enums;
using CadastroDeSeries.MVC.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Serie>> ListarTudoAsync()
        {
            return await _context.Serie.ToListAsync();
        }

        public async Task InserirAsync(Serie serie)
        {
            _context.Add(serie);
            await _context.SaveChangesAsync();
        }

        public async Task<Serie> SelecionarPorIdAsync(int id)
        {
            return await _context.Serie.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task RemoverAsync(int id)
        {
            try
            {
                var obj = await _context.Serie.FindAsync(id);
                _context.Serie.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateException e) // Esse caso de exceção seria para controle de exceções de integridade referencial, não existe nesse projeto, mas deixei aqui para visualizações futuras
            {
                throw new IntegrityException(e.Message);
            }
        }

        public async Task UpdateAsync(Serie serie)
        {
            bool hasAny = await _context.Serie.AnyAsync(x => x.Id == serie.Id);
            if (!hasAny)
                throw new NotFoundException("Id não encontrado");

            try
            {
                _context.Update(serie);
                await _context.SaveChangesAsync();
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
