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
        ReturnObject create(int id, String name, String email, String password);

        ReturnObject delete(int userId);

        ReturnObject changeStatus(int userId, Status userstatus);

        UserEntity findByEmail(String email);

        UserEntity findById(int userId);

        ReturnObject addFriend(int meId, int otherId);

        ReturnObject deleteFriend(int userId, int friendId);

        Collection<FriendEntity> getFriendlist(int userId);

        Collection<UserEntity> getAllUser();

        HistoryEntity getHistory(int userId);

        ReturnObject updateHistory(int userId, HistoryEntity history);

        ReturnObject createHistory(UserEntity user);
    }
}
