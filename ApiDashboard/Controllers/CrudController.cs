using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiDashboard.Interface;
using ApiDashboard.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ApiDashboard.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CrudController<T> : ControllerBase where T : class
    {
        protected readonly ICrudRepository<T> _crudRepository;

        public CrudController(ICrudRepository<T> crudRepository)
        {
            _crudRepository = crudRepository;
        }

        [HttpGet("BuscarPorId{id}")]
        public async Task<ActionResult<T>> BuscarPorId(int id)
        {
            try
            {
                var buscar = await _crudRepository.BuscarPorId(id);
                if (buscar == null)
                {
                    return NotFound($"Item com ID {id} não encontrado.");
                }
                return Ok(buscar);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao buscar o item: {ex.Message}");
            }
        }

        [HttpGet("BuscarTodos")]
        public async Task<ActionResult<IEnumerable<T>>> BuscarTodos()
        {
            try
            {
                var buscar = await _crudRepository.SelecionarTodos();
                return Ok(buscar);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao buscar todos os itens: {ex.Message}");
            }
        }

        [HttpPost("adicionar")]
        public async Task<ActionResult<T>> Salvar([FromBody] T entity)
        {
            if (entity == null)
            {
                return BadRequest("Entidade não pode ser nula.");
            }

            try
            {
                var savedEntity = await _crudRepository.Adicionar(entity);
                return Ok(savedEntity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao adicionar o item: {ex.Message}");
            }
        }

        [HttpPut("editar")]
        public async Task<ActionResult<T>> Atualizar([FromBody] T entity)
        {
            if (entity == null)
            {
                return BadRequest("Entidade não pode ser nula.");
            }

            try
            {
                var updatedEntity = await _crudRepository.Update(entity);
                return Ok(updatedEntity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao atualizar o item: {ex.Message}");
            }
        }

        [HttpDelete("deletar")]
        public async Task<ActionResult<T>> Delete(int id)
        {
            try
            {
                T entity = await _crudRepository.BuscarPorId(id);
                if (entity == null)
                {
                    return NotFound($"Item com ID {id} não encontrado.");
                }

                _crudRepository.Delete(entity);
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao deletar o item: {ex.Message}");
            }
        }
    }
}