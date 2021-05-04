using Sp_medical_group_tarde.Context;
using Sp_medical_group_tarde.Domains;
using Sp_medical_group_tarde.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sp_medical_group_tarde.Repositories
{
    public class ConsultumRepository : IConsultaRepository
    {
        MedicalContext ctx = new MedicalContext();
        public void Atualizar(int id, Consultum ConsultumAtualizado)
        {
            Consultum ConsultumBuscado = ctx.Consulta.Find(id);    
        }

        public Consultum BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Consultum novoConsultum)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Consultum> Listar()
        {
            throw new NotImplementedException();
        }

        public List<Consultum> Minhas(int idUsuario)
        {
            throw new NotImplementedException();
        }

        public void Permissao(int id, Consultum ConsultumPermissao)
        {
            throw new NotImplementedException();
        }
    }
}
