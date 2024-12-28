using AlunoAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlunoAPI.Services
{
    public interface IAlunoService  
    {
        Task<IEnumerable<Aluno>> GetAlunos();
        Task<Aluno> GetAluno(int id);
        Task<IEnumerable<Aluno>> AddAlunoByNome(Aluno aluno);
        Task CreateAluno(Aluno aluno);
        Task UpdateAluno(Aluno aluno);
        Task DeleteAluno(Aluno aluno);

    }
}
