using _3_partygame_backend_domain.Entities;
using _3_partygame_backend_domain.Entities.AggregateEntities;
using _3_partygame_backend_domain.Repositories;
using _3_partygame_backend_domain.Services;
using _3_partygame_backend_domain.Services.auth;
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
        private readonly ChangePasswordService changePasswordService;
        private readonly ViewUser viewUser;

        public ManageUser(UserRepository userRepository, ChangePasswordService changePasswordService)
        {
            this.userRepository = userRepository;
            this.changePasswordService = changePasswordService;
            this.viewUser = new ViewUser(userRepository);
        }
        
        public ReturnObject changeUserStatus(int userId, Status status)
        {
            try
            {
                userRepository.changeStatus(userId, status.getId());
                return new ReturnObject(true, "Status changed.");
            }catch(Exception e)
            {
                return new ReturnObject(false, e.Message);
            }
        }

        public ReturnObject changePassword(int userId, string oldPassword, string newPassword)
        {
            return changePasswordService.changePassword(userId, oldPassword, newPassword);
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

        public ReturnObject addFriend(int userId, int friendId)
        {
            if (viewUser.getAllFriends(userId).Where(item => item.getOtherId() == friendId).Count() >= 1)
            {
                return new ReturnObject(false, "Friend already exists.");
            }
            else
            {
                userRepository.addFriend(userId, friendId);
                return new ReturnObject(true, "Friend added.");
            }
        }

        public ReturnObject removeFriend(int userId, int friendId)
        {
            if (viewUser.getAllFriends(userId).Where(item => item.getOtherId() == friendId).Count() >= 1)
            {
                userRepository.deleteFriend(userId, friendId);
                return new ReturnObject(true, "Friend removed.");
            }
            else
            {
                return new ReturnObject(false, "Friend does not exist.");
            }
        }

        public ReturnObject createHistory(int userId)
        {
            UserEntity user = userRepository.findById(userId);
            if (user.HasHistory)
            {
                return new ReturnObject(false, "User already has a History.");
            }
            else
            {
                userRepository.createHistory(userId);
                user.HasHistory = true;
                return new ReturnObject(true, "History created.");
            }
        }

        public ReturnObject updateHistory(int userId, HistoryEntity history)
        {
            try
            {
                userRepository.updateHistory(userId, history);
                return new ReturnObject(true, "History Updated.");
            }
            catch (Exception e)
            {
                return new ReturnObject(false, e.Message);
            }
        }
    }
}
