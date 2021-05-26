using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _3_partygame_backend_domain.Services.auth;
using _3_partygame_backend_domain.Repositories;
using _3_partygame_backend_domain.Entities;

namespace _2_partygame_backend_application.UseCases.Authentication
{
    public class LoginUser
    {
        private readonly UserRepository userRepository;
        private readonly AuthService authService;

        public LoginUser(UserRepository userRepository, AuthService authService)
        {
            this.userRepository = userRepository;
            this.authService = authService;
        }


        public UserEntity loginUser(String email, String password)
        {
            try
            {
                if (authService.verifyPassword(email, password))
                {
                    return userRepository.findByEmail(email);
                }
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            throw new InvalidCredentialsException();
        }
    }
}
