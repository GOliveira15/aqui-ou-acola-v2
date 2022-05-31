using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AquiOuAcola.Entidades
{
    public class CursoF
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int CursoId { get; set; }
        public Curso Curso { get; set; }
        public Usuarios Usuario { get; set; }
    }
}
