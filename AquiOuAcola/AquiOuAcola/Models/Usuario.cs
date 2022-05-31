using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AquiOuAcola.Models
{
    public class Usuario
    {
        public int codigo { get; set; }
        public string foto { get; set; }
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public string cidade { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
    }
}
