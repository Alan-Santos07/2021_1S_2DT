using senai.inlock.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Interfaces
{
    interface IUsuarioRepository
    {
        List<Usuario> Listar();
        Usuario BuscarPorId(int id);
        void Atualizar(int id, Usuario usuarioAtualizado);
        void Cadastrar(Usuario novoUsuario);
        void Deletar(int id);
        Usuario BuscarEmailSenha(string email, string senha);
    }
}
