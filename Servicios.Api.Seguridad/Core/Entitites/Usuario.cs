﻿using Microsoft.AspNetCore.Identity;

namespace Servicios.Api.Seguridad.Core.Entitites
{
    public class Usuario : IdentityUser
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
    }
}
