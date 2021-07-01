using Microsoft.EntityFrameworkCore;
using Sp_medical_group_tarde.Context;
using Sp_medical_group_tarde.Domains;
using Sp_medical_group_tarde.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sp_medical_group_tarde.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        MedicalContext ctx = new MedicalContext();
        public Paciente BuscarPorId(int id)
        {
            return ctx.Pacientes.FirstOrDefault(tu => tu.IdPaciente == id);
        }

        public List<Paciente> Listar()
        {
            return ctx.Pacientes

            .Include(p => p.IdUsuarioNavigation)

            .ToList();
        }
    }
}
