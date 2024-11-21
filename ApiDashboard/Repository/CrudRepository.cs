using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiDashboard.DB;
using ApiDashboard.Interface;
using Microsoft.EntityFrameworkCore;

namespace ApiDashboard.Repository
{
    public abstract class CrudRepository<T> : ICrudRepository<T> where T : class
    {
        protected readonly DashboardContext _dashboardContext;

        public CrudRepository(DashboardContext dashboardContext)
        {
            _dashboardContext = dashboardContext;
        }

        public async Task<T> BuscarPorId(int id)
        {
            return await _dashboardContext.Set<T>().FindAsync(id);
        }

        public async Task Delete(T entity)
        {
            _dashboardContext.Remove(entity);
            await _dashboardContext.SaveChangesAsync();
        }

        public async Task<T> Adicionar(T entity)
        {
            if (_dashboardContext.Entry(entity).State == EntityState.Detached)
            {
                _dashboardContext.Add(entity);
            }
            else
            {
                _dashboardContext.Update(entity);
            }
            await _dashboardContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<T>> SelecionarTodos()
        {
            return await _dashboardContext.Set<T>().ToListAsync();
        }

        public async Task<T> Update(T entity)
        {
            _dashboardContext.Update(entity);
            await _dashboardContext.SaveChangesAsync();
            return entity;
        }
    }
}