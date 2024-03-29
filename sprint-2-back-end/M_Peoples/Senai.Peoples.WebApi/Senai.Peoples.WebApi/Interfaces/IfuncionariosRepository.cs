﻿using Senai.Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Interfaces
{
    interface IfuncionariosRepository
    {
        List<funcionarios> Listar();

        funcionarios BuscarPorId(int id);

        void Deletar(int id);

        void Atualizar(funcionarios mudanca);

        void Cadastrar(funcionarios novoFuncionario);
    }
}
