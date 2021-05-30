using _3_partygame_backend_domain.Services.auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2_partygame_backend_applicationTests.Mocks
{
    class AuthServiceMock : AuthService
    {

        public bool verifyPassword(string email, string password)
        {
            return true;
        }
    }
}
