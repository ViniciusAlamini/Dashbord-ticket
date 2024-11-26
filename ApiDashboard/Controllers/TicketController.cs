using ApiDashboard.DTOs;
using ApiDashboard.Interface;
using ApiDashboard.Models;
using ApiDashboard.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ApiDashboard.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController : CrudController<Ticket>
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketController(ICrudRepository<Ticket> crudRepository, ITicketRepository ticketRepository)
            : base(crudRepository)
        {
            _ticketRepository = ticketRepository;
        }

        [HttpGet("buscar-mes-ano")]
        public async Task<IActionResult> BuscaPorMesAno(int mes, int ano)
        {
            try
            {
                var tickets = await _ticketRepository.BuscaPorMesAnoAsync(mes, ano);
                return Ok(tickets);
            }
            catch (Exception ex)
            {
                return BadRequest($"Algum erro ocorreu durante a requisição: {ex.Message}");
            }
        }

        [HttpGet("agrupar-por-cliente")]
        public async Task<IActionResult> AgruparPorCliente()
        {
            try
            {
                var result = await _ticketRepository.AgruparPorClienteAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Algum erro ocorreu durante a requisição: {ex.Message}");
            }
        }

        [HttpGet("agrupar-por-modulo")]
        public async Task<IActionResult> AgruparPorModulo()
        {
            try
            {
                var result = await _ticketRepository.AgruparPorModuloAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Algum erro ocorreu durante a requisição: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("criar-ticket")]
        public async Task<IActionResult> CreateTicket([FromBody] CriarTicketDTO criarTicketDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var ticket = await _ticketRepository.CriarTicketAsync(criarTicketDTO);
                return Ok($"Ticket criado: {ticket}");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao criar ticket: {ex.Message}");
            }
        }

        [HttpGet("SelecionarTodos")]
        public async Task<IActionResult> SelecionarTodosAsync(){
            try
            {
                var tickets = await _ticketRepository.SelecionarTodosAsync();
                return Ok(tickets);
            }
            catch (Exception ex)
            {
                return BadRequest($"Algum erro ocorreu durante a requisição: {ex.Message}");
            }
        }

        [HttpGet("BuscarPorIdInclude")]
        public async Task<IActionResult> BuscarPorIdInclude(int id){
            try
            {
                var ticket = await _ticketRepository.BuscarPorIdInclude(id);
                return Ok(ticket);
            }
            catch (Exception ex)
            {
                return BadRequest($"Algum erro ocorreu durante a requisição: {ex.Message}");
            }
        }
    }
}
