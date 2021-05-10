using Microsoft.EntityFrameworkCore;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        InLock_GamesContext ctx = new InLock_GamesContext();
        public void Atualizar(int id, Estudio estudioAtualizado)
        {
            Estudio estudioBuscado = ctx.Estudios.Find(id);

            if (estudioAtualizado.NomeEstudio != null)
            {

                estudioBuscado.NomeEstudio = estudioAtualizado.NomeEstudio;
            }


            ctx.Estudios.Update(estudioBuscado);

            ctx.SaveChanges();
        }

        public Estudio BuscarPorId(int id)
        {
            return ctx.Estudios.FirstOrDefault(e => e.IdEstudio == id);
        }

        public void Cadastrar(Estudio novoEstudio)
        {
            ctx.Estudios.Add(novoEstudio);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Estudio estudioBuscado = ctx.Estudios.Find(id);

            ctx.Estudios.Remove(estudioBuscado);

            ctx.SaveChanges();
        }

        public List<Estudio> Listar()
        {
            return ctx.Estudios.ToList();
        }

        public List<Estudio> ListarJogos()
        {
            return ctx.Estudios.Include(e => e.Jogos).ToList();
        }
    }
}
