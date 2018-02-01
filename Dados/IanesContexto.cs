using Microsoft.EntityFrameworkCore;
using Ianes.Models;

namespace Ianes.Dados
{
    public class IanesContexto:DbContext
    {
        public IanesContexto(DbContextOptions<IanesContexto>options):base(options){}
        public DbSet<Areas> Areas{ get; set; }
        public DbSet<Cursos> Cursos { get; set; }
        public DbSet<Cronogramas> Cronogramas { get; set; }
        public DbSet<Dias> Dias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Areas>().ToTable("Areas");
            modelBuilder.Entity<Cursos>().ToTable("Cursos");
            modelBuilder.Entity<Cronogramas>().ToTable("Cronogramas");
            modelBuilder.Entity<Dias>().ToTable("Dias");
        }


    }
}