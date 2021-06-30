using Microsoft.AspNetCore.Mvc;
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
    public class SituacaoController : ControllerBase
    {
        private ISituacaoRepository _situacaoRepository { get; set; }

        public SituacaoController()
        {
            _situacaoRepository = new SituacaoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_situacaoRepository.Listar());
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
                return Ok(_situacaoRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
