using System;

namespace AspNetWebApplication.Core.Common
{
    [Flags]
    public enum Role
    {
        Administrador = 1,
        Gerente = 2,
        Usuario = 3
    }
}