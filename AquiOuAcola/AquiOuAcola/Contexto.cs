using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AquiOuAcola.Entidades;

namespace AquiOuAcola
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<CursoF> CursoF { get; set; }
    }
}
