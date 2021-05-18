using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi.Domains;
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
    public class JogoController : ControllerBase
    {
        private IJogoRepository _JogoRepository { get; set; }


        public JogoController()
        {
            _JogoRepository = new JogoRepository();
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_JogoRepository.Listar());
        }
        [HttpPost]
        public IActionResult Post(Jogo novoJogo)
        {
            _JogoRepository.Cadastrar(novoJogo);
            return StatusCode(201);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _JogoRepository.Deletar(id);
            return StatusCode(204);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_JogoRepository.BuscarPorId(id));
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, Jogo JogoAtualizado)
        {
            _JogoRepository.Atualizar(id, JogoAtualizado);
            return StatusCode(204);
        }
    }
}
