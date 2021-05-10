using senai.inlock.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Interfaces
{
    interface IEstudioRepository
    {

        List<Estudio> Listar();


        Estudio BuscarPorId(int id);

        void Cadastrar(Estudio novoEstudio);

        void Atualizar(int id, Estudio estudioAtualizado);


        void Deletar(int id);


        List<Estudio> ListarJogos();
    }
}
