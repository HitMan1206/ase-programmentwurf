using _3_partygame_backend_domain.Services;
using _3_partygame_backend_domain.Services.auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2_partygame_backend_applicationTests.Mocks
{
    class ChangePasswordServiceMock : ChangePasswordService
    {
        public ReturnObject changePassword(int userId, string oldPassword, string newPassword)
        {
            return new ReturnObject(true, "Test");
        }
    }
}
