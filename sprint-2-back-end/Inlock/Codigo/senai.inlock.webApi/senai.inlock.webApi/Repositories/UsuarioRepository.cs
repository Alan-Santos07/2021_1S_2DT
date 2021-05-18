using Microsoft.EntityFrameworkCore;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        InLock_GamesContext ctx = new InLock_GamesContext();
        public void Atualizar(int id, Usuario usuarioAtualizado)
        {
            Usuario UsuarioBuscado = ctx.Usuarios.Find(id);
            if (usuarioAtualizado.Email != null)
            {
                UsuarioBuscado.Email = usuarioAtualizado.Email;
            }


            ctx.Usuarios.Update(UsuarioBuscado);

            ctx.SaveChanges();
        }

        public Usuario BuscarEmailSenha(string email, string senha)
        {
            return ctx.Usuarios.Include(u => u.IdTipoUsuarioNavigation).FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }

        public Usuario BuscarPorId(int id)
        {
            return ctx.Usuarios.FirstOrDefault(e => e.IdUsuario == id);
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            ctx.Usuarios.Add(novoUsuario);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Usuario UsuarioBuscado = ctx.Usuarios.Find(id);

            ctx.Usuarios.Remove(UsuarioBuscado);

            ctx.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return ctx.Usuarios.ToList();
        }
    }
}
