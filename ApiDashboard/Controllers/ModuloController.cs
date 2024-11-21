using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiDashboard.Models;
using ApiDashboard.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ApiDashboard.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ModuloController : CrudController<Modulo>
    {
        protected readonly ModuloRepository _moduloRepository;
        public ModuloController(ModuloRepository moduloRepository) : base(moduloRepository){
            _moduloRepository = moduloRepository;
        }
    }
}