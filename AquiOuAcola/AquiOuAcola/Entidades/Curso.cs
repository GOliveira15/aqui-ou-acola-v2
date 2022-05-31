using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AquiOuAcola.Entidades
{
    public class Curso
    {
        public int Id { get; set; }
        public int Id_Usuario { get; set; }
        public string foto { get; set; }
        public string nome { get; set; }
        public string disponibilidade { get; set; }
        public string gratuito { get; set; }
        public string link { get; set; }
        public string descricao { get; set; }
        public string nivel { get; set; }
    }
}
