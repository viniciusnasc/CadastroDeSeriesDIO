using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroDeSeries.Models
{
    public enum Genero
    {
        [Display(Name = "Ação")]
        Acao,
        Aventura,
        Comedia,
        Documentario,
        Drama,
        Espionagem,
        Faroeste,
        Fantasia,
        [Display(Name = "Ficção Cientifica")]
        FiccaoCientifica,
        Musical,
        Romance,
        Suspense,
        Terror
    }
}
