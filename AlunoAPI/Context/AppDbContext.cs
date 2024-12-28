using AlunoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AlunoAPI.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Aluno> Alunos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluno>().HasData(
                new Aluno
                {
                    Id = 1,
                    Nome = "Maria da Penha",
                    Email = "mariapenha@gmail.com",
                    Idade = 25
                },
                new Aluno
                {
                    Id = 2,
                    Nome = "João da Silva",
                    Email = "joaosilva@gmail.com",
                    Idade = 30
                }
            );
        }
    }
}


            
