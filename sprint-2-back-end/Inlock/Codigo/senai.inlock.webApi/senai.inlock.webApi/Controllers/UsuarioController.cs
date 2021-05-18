using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _UsuarioRepository { get; set; }


        public UsuarioController()
        {
            _UsuarioRepository = new UsuarioRepository();
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_UsuarioRepository.Listar());
        }
        [HttpPost]
        public IActionResult Post(Usuario NovoUsuario)
        {
            _UsuarioRepository.Cadastrar(NovoUsuario);
            return StatusCode(201);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _UsuarioRepository.Deletar(id);
            return StatusCode(204);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_UsuarioRepository.BuscarPorId(id));
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, Usuario UsuarioAtualizado)
        {
            _UsuarioRepository.Atualizar(id,UsuarioAtualizado);
            return StatusCode(204);
        }
        [HttpPost("Login")]
        public IActionResult GetEmailAndPassword(Usuario UsuarioProcurado)
        {
            try
            {
                // Busca o usuário pelo e-mail e senha
                Usuario usuarioBuscado = _UsuarioRepository.BuscarEmailSenha(UsuarioProcurado.Email, UsuarioProcurado.Senha);

                // Caso não encontre nenhum usuário com o e-mail e senha informados
                if (usuarioBuscado == null)
                {
                    // Retorna NotFound com uma mensagem de erro
                    return NotFound("E-mail ou senha inválidos!");
                }

                // Caso o usuário seja encontrado, prossegue para a criação do token

                /*
                    Dependências
                    Criar e validar o JWT:      System.IdentityModel.Tokens.Jwt
                    Integrar a autenticação:    Microsoft.AspNetCore.Authentication.JwtBearer (versão compatível com o .NET do projeto)
                */

                // Define os dados que serão fornecidos no token - Payload
                var claims = new[]
                {
                    // Armazena na Claim o e-mail do usuário autenticado
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),

                    // Armazena na Claim o ID do usuário autenticado
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),

                    // Armazena na Claim o tipo de usuário que foi autenticado (Administrador ou Comum)
                    new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuario.ToString())
                };

                // Define a chave de acesso ao token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Inlock-chave-autenticacao"));

                // Define as credenciais do token - Header
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                // Gera o token
                var token = new JwtSecurityToken(
                    issuer: "Inlock.webApi",                 // emissor do token
                    audience: "Inlock.webApi",               // destinatário do token
                    claims: claims,                        // dados definidos acima
                    expires: DateTime.Now.AddMinutes(30),  // tempo de expiração
                    signingCredentials: creds              // credenciais do token
                );

                // Retorna Ok com o token
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
    
}
