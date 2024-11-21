using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDashboard.Interface
{
    public interface ICrudRepository<T>
    {
         Task<IEnumerable<T>> SelecionarTodos();

        Task<T> BuscarPorId(int id);

        Task<T> Adicionar(T entity);

        Task<T> Update(T entity);

        Task Delete(T entity);
    }
}