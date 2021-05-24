using _3_partygame_backend_domain.Entities;
using _3_partygame_backend_domain.Entities.AggregateEntities;
using _3_partygame_backend_domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace _3_partygame_backend_domain.Repositories
{
    interface UserRepository
    {
        bool create(String name, String email, String password);

        bool update(UserEntity user);

        bool delete(int userId);

        bool changeStatus(Status userstatus);

        UserEntity findByEmail(String email);

        UserEntity findById(int userId);

        bool addFriend(FriendEntity friend);

        bool deleteFriend(FriendEntity friend);

        Collection<FriendEntity> getFriendlist();
    }
}
