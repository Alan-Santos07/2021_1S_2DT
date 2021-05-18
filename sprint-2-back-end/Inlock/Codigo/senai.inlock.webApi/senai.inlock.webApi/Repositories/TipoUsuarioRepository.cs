using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Repositories
{
    
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        InLock_GamesContext ctx = new InLock_GamesContext();
        public TiposUsuario BuscarPorId(int id)
        {
            return ctx.TiposUsuarios.FirstOrDefault(e => e.IdTipoUsuario == id);
        }

        public List<TiposUsuario> Listar()
        {
            return ctx.TiposUsuarios.ToList();
        }
    }
}
