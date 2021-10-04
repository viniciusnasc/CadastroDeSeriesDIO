using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroFilmesSeries.Model
{
    public class Filme : Video
    {
        public List<string> Atores { get; set; }
    }
}
