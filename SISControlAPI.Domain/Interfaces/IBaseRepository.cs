using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SISControlAPI.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        void Adicionar(T model);

        void Deletar(int id);

        void Atualizar(T model);

        Task<ICollection<T>> LeituraGeral();

        Task<T> Leitura(int id);

        Task<T> Pesquisar(Expression<Func<T, bool>> predicate);

        Task Salvar();
    }
}
