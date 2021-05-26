using _3_partygame_backend_domain.Entities.AggregateEntities;
using _3_partygame_backend_domain.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace _2_partygame_backend_application.UseCases.Friends
{
    public class ViewFriend
    {
        private readonly UserRepository userRepository;

        public ViewFriend(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public Collection<FriendEntity> getAllFriends()
        {
            return userRepository.getFriendlist();
        }

        public FriendEntity getFriendById(int id)
        {
            return userRepository.getFriendlist().Where(value => id == value.getFriendToId()).FirstOrDefault();
        }

        public FriendEntity getFriendByEmail(String email)
        {
            return userRepository.getFriendlist().Where(value => email == value.getFriendToEmail()).FirstOrDefault();
        }
    }
}
