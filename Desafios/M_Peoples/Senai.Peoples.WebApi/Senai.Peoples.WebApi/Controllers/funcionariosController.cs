using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using Senai.Peoples.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Controllers
{
    public class funcionariosController
    {
        [Produces("application/json")]

        [Route("api/[controller]")]

        [ApiController]

        public class funcionariosControllers : ControllerBase
        {
            private IfuncionariosRepository _funcionariosRepository { get; set; }

            public funcionariosControllers()
            {
                _funcionariosRepository = new funcionariosRepository();
            }   

            [HttpGet]
            public IActionResult Get()
            {
                List<funcionarios> listarFuncionarios = _funcionariosRepository.Listar();

                return Ok(listarFuncionarios);
            }

            [HttpGet("{id}")]
            public IActionResult GetById(int id)
            {
                funcionarios funcionarioBuscado = _funcionariosRepository.BuscarPorId(id);

                if (funcionarioBuscado == null)
                {
                    return NotFound("Nenhum funcionário encontrado!");
                }

                return Ok(funcionarioBuscado);
            }

            [HttpPost]
            public IActionResult Post(funcionarios novoFuncionario)
            {
                _funcionariosRepository.Cadastrar(novoFuncionario);

                return StatusCode(201);
            }
            [HttpPut("{id}")]
            public IActionResult PutIdUrl(int id, funcionarios funcionariosAtualizado)
            {
                funcionarios funcionariosBuscado = _funcionariosRepository.BuscarPorId(id);

                if (funcionariosBuscado == null)
                {
                    return NotFound
                        (
                            new
                            {
                                mensagem = "Funcionario não encontrado!",
                                erro = true
                            }
                        );
                }

                try
                {
                    _funcionariosRepository.AtualizarIdUrl(id, funcionariosAtualizado);

                    return NoContent();
                }
                catch (Exception codErro)
                {
                    return BadRequest(codErro);
                }
            }

            [HttpPut]
            public IActionResult PutIdBody(funcionarios funcionariosAtualizado)
            {
                funcionarios funcionariosBuscado = _funcionariosRepository.BuscarPorId(funcionariosAtualizado.idFuncionarios);

                if (funcionariosBuscado != null)
                {
                    try
                    {
                        _funcionariosRepository.AtualizarIdCorpo(funcionariosAtualizado);

                        return NoContent();
                    }
                    catch (Exception codErro)
                    {
                        return BadRequest(codErro);
                    }
                }

                return NotFound
                    (
                        new
                        {
                            mensagem = "Funcionario não encontrado!"
                        }
                    );
            }

            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                _funcionariosRepository.Deletar(id);

                return StatusCode(204);
            }
        }
    }
}
