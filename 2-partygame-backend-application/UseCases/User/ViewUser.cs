using _3_partygame_backend_domain.Entities;
using _3_partygame_backend_domain.Entities.AggregateEntities;
using _3_partygame_backend_domain.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace _2_partygame_backend_application.UseCases.User
{
    public class ViewUser
    {

        private readonly UserRepository userRepository;

        public ViewUser(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public Collection<UserEntity> getAllUsers()
        {
            return userRepository.getAllUser();
        }
        
        public UserEntity getUserById(int id)
        {
            return userRepository.findById(id);
        }

        public UserEntity getUserbyEmail(String email)
        {
            return userRepository.findByEmail(email);
        }

        public HistoryEntity getHistory(int userId)
        {
            return userRepository.getHistory(userId);
        }

        public Collection<FriendEntity> getAllFriends(int userId)
        {
            return userRepository.getFriendlist(userId);
        }

        public FriendEntity getFriendById(int userId, int friendId)
        {
            return userRepository.getFriendlist(userId).Where(value => friendId == value.getOtherId()).FirstOrDefault();
        }

        public FriendEntity getFriendByEmail(int userId, String email)
        {
            return userRepository.getFriendlist(userId).Where(value => email == value.getOtherEmail()).FirstOrDefault();
        }

    }
}
