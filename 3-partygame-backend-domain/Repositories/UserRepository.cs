using _3_partygame_backend_domain.Entities;
using _3_partygame_backend_domain.Entities.AggregateEntities;
using _3_partygame_backend_domain.Services;
using _3_partygame_backend_domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace _3_partygame_backend_domain.Repositories
{
    public interface UserRepository
    {
        UserEntity create(String name, String email, String password);

        ReturnObject update(UserEntity user);

        ReturnObject delete(int userId);

        ReturnObject changeStatus(Status userstatus);

        UserEntity findByEmail(String email);

        UserEntity findById(int userId);

        ReturnObject addFriend(FriendEntity friend);

        ReturnObject deleteFriend(FriendEntity friend);

        Collection<FriendEntity> getFriendlist();

        Collection<UserEntity> getAllUser();

        HistoryEntity getHistory();

        ReturnObject updateHistory(HistoryEntity history);

        ReturnObject createHistory(UserEntity user);
    }
}
