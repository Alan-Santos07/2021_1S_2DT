using senai.inlock.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Interfaces
{
    interface IJogoRepository
    {
        List<Jogo> Listar();
        Jogo BuscarPorId(int id);
        void Atualizar(int id, Jogo jogosAtualizados);
        void Cadastrar(Jogo novoJogo);
        void Deletar(int id);
    }
}
