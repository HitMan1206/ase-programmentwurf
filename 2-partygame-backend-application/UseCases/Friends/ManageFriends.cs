using _3_partygame_backend_domain.Entities.AggregateEntities;
using _3_partygame_backend_domain.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using _2_partygame_backend_application.UseCases.Friends;
using _3_partygame_backend_domain.Services;

namespace _2_partygame_backend_application.UseCases.Friends
{
    public class ManageFriends
    {
        private readonly UserRepository userRepository;
        private readonly ViewFriend viewFriend;

        public ManageFriends(UserRepository userRepository)
        {
            this.userRepository = userRepository;
            this.viewFriend = new ViewFriend(userRepository);
        }

        public ReturnObject addFriend(FriendEntity friend)
        {
            if (viewFriend.getAllFriends().Contains(friend))
            {
                return new ReturnObject(false, "Friend already exists.");
            }
            else
            {
                userRepository.addFriend(friend);
                return new ReturnObject(true, "Friend added.");
            }
        }

        public ReturnObject removeFriend(FriendEntity friend)
        {
            if (viewFriend.getAllFriends().Contains(friend))
            {
                userRepository.deleteFriend(friend);
                return new ReturnObject(true, "Friend removed.");
            }
            else
            {
                return new ReturnObject(false, "Friend does not exist.");
            }
        }
    }
}
