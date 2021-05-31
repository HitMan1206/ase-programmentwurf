using _3_partygame_backend_domain.Entities;
using _3_partygame_backend_domain.Repositories;
using _3_partygame_backend_domain.Services;
using _3_partygame_backend_domain.Services.auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _2_partygame_backend_application.UseCases.Authentication
{
    public class RegisterUser
    {
        private readonly UserRepository userRepository;


        public RegisterUser(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public ReturnObject registerUser(int id, String email, String password, String name)
        {
            CredentialService credentialService = new CredentialService();
            if (credentialService.credentialsValid(name, email, password))
            {
                if(userRepository.findByEmail(email) == null)
                {

                    userRepository.createHistory(new UserEntity(id,email,name,password));
                    return userRepository.create(id, name, email, password);
                }
                else
                {
                    return new ReturnObject(false, "User already exists.");
                }
            }
            else
            {
                return new ReturnObject(false, "Credentials are invalid.");
            }
        }
    }
}
