using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProdigyWeb.Models;

namespace GestaoOficina.Data
{
    public class ProdigyWebContext
    {
        private Usuario Usuarios { get; set; }

        public Usuario UsuarioProdigyWeb()
        {
            return Usuarios;
        }
    }
}