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
    public class ClienteController : CrudController<Cliente>
    {
        protected readonly ClienteRepository _clienteRepository;
        
        public ClienteController(ClienteRepository clienteRepository) : base(clienteRepository){
            _clienteRepository = clienteRepository;
        }
    }
}