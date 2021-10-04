using CadastroFilmesSeries.Model.Enums;
using System;

namespace CadastroFilmesSeries.Model
{
    abstract public class Video
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public Genero Genero { get; set; }
        public int Ano { get; set; }
        public string Diretor { get; set; }
        public double Nota { get; set; }
    }
}
