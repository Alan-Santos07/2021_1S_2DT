using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sp_medical_group_tarde.Domains;
using Sp_medical_group_tarde.Interfaces;
using Sp_medical_group_tarde.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sp_medical_group_tarde.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        private IConsultaRepository _ConsultaRepository { get; set; }

        public ConsultaController()
        {
            _ConsultaRepository = new ConsultumRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_ConsultaRepository.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_ConsultaRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPost]
        public IActionResult Post(Consultum novoConsultum)
        {
            try
            {
                _ConsultaRepository.Cadastrar(novoConsultum);

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Consultum ConsultumAtualizado)
        {
            try
            {
                _ConsultaRepository.Atualizar(id, ConsultumAtualizado);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _ConsultaRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
