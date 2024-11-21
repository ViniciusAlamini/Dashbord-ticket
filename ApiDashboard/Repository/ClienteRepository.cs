using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiDashboard.DB;
using ApiDashboard.Interface;
using ApiDashboard.Models;

namespace ApiDashboard.Repository
{
    public class ClienteRepository : CrudRepository<Cliente>, ICrudRepository<Cliente>
    {
        public ClienteRepository(DashboardContext dashboardContext) : base(dashboardContext)
        {
        }
    }
}