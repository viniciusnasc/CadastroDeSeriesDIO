using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroDeSeries.MVC.Models.Enums
{
    public enum Genero : int
    {
        Aventura = 0,
        [Display(Name = "Ação")]
        Acao = 1,
        [Display(Name = "Comédia")]
        Comedia = 2,
        [Display(Name = "Documentário")]
        Documentario = 3,
        Drama = 4,
        Suspense = 5,
        Terror = 6
    }
}
