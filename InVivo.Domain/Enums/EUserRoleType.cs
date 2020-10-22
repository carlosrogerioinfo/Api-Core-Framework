using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InVivo.Domain.Enums
{
    public enum EUserRoleType
    {

        [Description("Administrador")]
        Admin = 1,

        [Description("Usuário")]
        User = 2,


    }
}

