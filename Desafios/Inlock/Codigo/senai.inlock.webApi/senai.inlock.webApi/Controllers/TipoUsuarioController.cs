using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TipoUsuarioController : ControllerBase
    {
        private ITipoUsuarioRepository _TipoUsuarioRepository { get; set; }


        public TipoUsuarioController()
        {
            _TipoUsuarioRepository = new TipoUsuarioRepository();
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_TipoUsuarioRepository.Listar());
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_TipoUsuarioRepository.BuscarPorId(id));
        }
    }
}
