using _3_partygame_backend_domain.Repositories;
using _3_partygame_backend_domain.Services;
using _3_partygame_backend_domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _2_partygame_backend_application.UseCases.User
{
    public class ManageUser
    {
        private readonly UserRepository userRepository;
        private readonly ViewUser viewUser;

        public ManageUser(UserRepository userRepository)
        {
            this.userRepository = userRepository;
            this.viewUser = new ViewUser(userRepository);
        }

        public ReturnObject changeUserStatus(Status status)
        {
            try
            {
                userRepository.changeStatus(status);
                return new ReturnObject(true, "Status changed.");
            }catch(Exception e)
            {
                return new ReturnObject(false, e.Message);
            }
        }

        public ReturnObject deleteUser(int userId)
        {
            if(viewUser.getAllUsers().Where(value => value.getId() == userId).Count() < 1)
            {
                return new ReturnObject(false, "User does not exist.");
            }
            else
            {
                userRepository.delete(userId);
                return new ReturnObject(true, "User deleted.");
            }
        }
    }
}
