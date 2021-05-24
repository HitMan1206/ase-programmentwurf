using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3_partygame_backend_domain.Services.auth
{
    public interface AuthService
    {
        bool verifyPassword(String email, String password);
    }
}
