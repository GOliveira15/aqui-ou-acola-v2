using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AquiOuAcola.Models
{
    public class Curso
    {
        public int codigo { get; set; }
        public string foto { get; set; }
        public string nome { get; set; }
        public string disponibilidade { get; set; }
        public string preco { get; set; }
        public string link { get; set; }
        public string descricao { get; set; }
        public string nivel { get; set; }
    }
}
