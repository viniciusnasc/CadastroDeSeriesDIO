using CadastroDeSeries.MVC.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroDeSeries.MVC.Models
{
    public class Serie
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} é obrigatório!")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "{0} é obrigatório!")]
        public Genero Genero { get; set; }
        [StringLength(60, MinimumLength = 5, ErrorMessage = "A {0} deve ter de {2} a {1} caracteres!")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "{0} é obrigatório!")]
        [Display(Name = "Ano de lançamento")]
        public int AnoLancamento { get; set; }
        [Required(ErrorMessage = "{0} é obrigatório!")]
        [Display(Name = "Data de conclusão")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
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
