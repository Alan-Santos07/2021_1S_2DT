using Sp_medical_group_tarde.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sp_medical_group_tarde.Interfaces
{
    interface IMedicoRepository 
    {
        List<Medico> Listar();

        Medico BuscarPorId(int id);

    }
}
