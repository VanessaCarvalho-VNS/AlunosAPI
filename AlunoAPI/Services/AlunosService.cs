using AlunoAPI.Context;
using AlunoAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlunoAPI.Services
{
    public class AlunosService : IAlunoService
    {
        private readonly AppDbContext _context;

        public AlunosService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Aluno>> GetAlunos()
        {
            try
            {
                return await _context.Alunos.ToListAsync();
            }
            catch (System.Exception)
            {
                throw;
            }
           
        }

        public async Task<IEnumerable<Aluno>> GetAlunoByNome(Aluno aluno)
        {
            IEnumerable<Aluno> alunos;
            if(!string.IsNullOrEmpty(aluno.Nome))
            {
                alunos = await _context.Alunos.Where(a => a.Nome.Contains(aluno.Nome)).ToListAsync();
            }
            else
            {
                alunos = await GetAlunos();
            }
            return alunos;
        }

        public async Task<Aluno> GetAluno(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            return aluno;
        }

        public async Task CreateAluno(Aluno aluno)
        {
           _context.Alunos.Add(aluno);
            await _context.SaveChangesAsync();

        }

        public async Task UpdateAluno(Aluno aluno)
        {
            _context.Entry(aluno).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }
        public async Task DeleteAluno(Aluno aluno)
        {
            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();

        }

    }
}
