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
        
        public class EstudiosController : ControllerBase
        {

            private IEstudioRepository _estudioRepository { get; set; }


            public EstudiosController()
            {
                _estudioRepository = new EstudioRepository();
            }
            [HttpGet]
            public IActionResult Get()
            {
                return Ok(_estudioRepository.Listar());
            }
            [HttpPost]
            public IActionResult Post(Estudio novoEstudio)
            {
                _estudioRepository.Cadastrar(novoEstudio);
                return StatusCode(201);
            }
            [HttpGet("Jogos")]
            public IActionResult GetGames()
            {
                return Ok(_estudioRepository.ListarJogos());
            }
            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                _estudioRepository.Deletar(id);
                return StatusCode(204);
            }
            [HttpGet("{id}")]
            public IActionResult GetById(int id)
            {
                return Ok(_estudioRepository.BuscarPorId(id));
            }
            [HttpPut("{id}")]
            public IActionResult Put(int id, Estudio estudioAtualizado)
            {
                _estudioRepository.Atualizar(id, estudioAtualizado);
                return StatusCode(204);
            }
        }
    }

