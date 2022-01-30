using Microsoft.EntityFrameworkCore;
using jeanFraga.Models;



namespace jeanFraga.Data
{
    public class DataContext : DbContext
    {
        
        public  DataContext(DbContextOptions<DataContext> options) 
          : base(options)
        {}

        public DbSet<Turmas> Turmas { get; set; }
        public DbSet<Alunos> Alunos { get; set; }
        public DbSet<Professores> Professores { get; set; }
    }
}