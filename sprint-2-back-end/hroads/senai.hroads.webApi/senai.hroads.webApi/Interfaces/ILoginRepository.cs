﻿using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface ILoginRepository
    {
        Usuario BuscarPorEmailSenha(string email, string senha);
    }
}
