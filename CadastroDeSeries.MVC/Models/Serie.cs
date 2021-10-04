using CadastroDeSeries.MVC.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroDeSeries.MVC.Models
{
    public class Serie
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public Genero Genero { get; set; }
        public string Descricao { get; set; }
        public int AnoLancamento { get; set; }
        public DateTime DataVisto { get; set; }

        public Serie()
        { }

        public Serie(int id, string titulo, Genero genero, string descricao, int anoLancamento, DateTime dataVisto)
        {
            Id = id;
            Titulo = titulo;
            Genero = genero;
            Descricao = descricao;
            AnoLancamento = anoLancamento;
            DataVisto = dataVisto;
        }
    }
}
