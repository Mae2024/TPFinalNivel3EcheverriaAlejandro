using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDominio;

namespace CapaNegocio
{
    public static class Seguridad
    {
        public static bool SessionActiva(object usuario)
        {
            USERS user = usuario != null ? (USERS)usuario : null;
            if (user != null && user.Id != 0)
                return true;
            else
                return false;
        }

        public static bool esAdmin(object usuario)
        {
            USERS user = usuario != null ? (USERS)usuario : null;
            return user != null ? user.Admin : false;
        }

    }
}
