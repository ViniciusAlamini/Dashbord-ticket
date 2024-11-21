using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiDashboard.DB;
using ApiDashboard.Interface;
using ApiDashboard.Models;

namespace ApiDashboard.Repository
{
    public class ModuloRepository : CrudRepository<Modulo>, ICrudRepository<Modulo>
    {
        public ModuloRepository(DashboardContext dashboardContext) : base(dashboardContext)
        {
        }
    }
}