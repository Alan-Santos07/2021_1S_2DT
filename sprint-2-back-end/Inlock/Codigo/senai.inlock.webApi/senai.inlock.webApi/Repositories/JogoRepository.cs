using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        InLock_GamesContext ctx = new InLock_GamesContext();
        public void Atualizar(int id, Jogo jogosAtualizados)
        {
            Jogo JogoBuscado = ctx.Jogos.Find(id);

            if (jogosAtualizados.NomeJogo != null)
            {
                JogoBuscado.NomeJogo = jogosAtualizados.NomeJogo;
            }


            ctx.Jogos.Update(JogoBuscado);

            ctx.SaveChanges();
        }

        public Jogo BuscarPorId(int id)
        {
            return ctx.Jogos.FirstOrDefault(e => e.IdJogo == id);
        }

        public void Cadastrar(Jogo novoJogo)
        {
            ctx.Jogos.Add(novoJogo);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Jogo JogoBuscado = ctx.Jogos.Find(id);

            ctx.Jogos.Remove(JogoBuscado);

            ctx.SaveChanges();
        }

        public List<Jogo> Listar()
        {
            return ctx.Jogos.ToList();
        }
    }
}
