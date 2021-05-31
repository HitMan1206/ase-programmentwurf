using _3_partygame_backend_domain.Entities;
using _3_partygame_backend_domain.Entities.AggregateEntities;
using _3_partygame_backend_domain.Repositories;
using _3_partygame_backend_domain.Services;
using _3_partygame_backend_domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace _2_partygame_backend_applicationTests.Mocks
{
    class UserRepositoryMock : UserRepository
    {
        public ReturnObject addFriend(int meId, int otherId)
        {
            return new ReturnObject(true, "test");
        }


        public ReturnObject changeStatus(int userId, int userstatusId)
        {
            return new ReturnObject(true, "test");
        }

        public ReturnObject create(int id, string name, string email, string password)
        {
            return new ReturnObject(true, "test");
        }

        public ReturnObject createHistory(int userId)
        {
            return new ReturnObject(true, "test");
        }

        public ReturnObject delete(int userId)
        {
            return new ReturnObject(true, "test");
        }

        public ReturnObject deleteFriend(int userId, int friendId)
        {
            return new ReturnObject(true, "test");
        }

        public UserEntity findByEmail(string email)
        {
            return new UserEntity(1, email, "testuser", "0testPassword!");
        }

        public UserEntity findById(int userId)
        {
            return new UserEntity(userId, "test", "testuser", "0testPassword!");
        }

        public Collection<UserEntity> getAllUser()
        {
            return new Collection<UserEntity>();
        }

        public Collection<FriendEntity> getFriendlist(int userId)
        {
            return new Collection<FriendEntity>();
        }

        public HistoryEntity getHistory(int userId)
        {
            return new HistoryEntity(0, 0);
        }

        public ReturnObject update(UserEntity user)
        {
            return new ReturnObject(true, "test");
        }

        public ReturnObject updateHistory(int userId, HistoryEntity history)
        {
            return new ReturnObject(true, "test");
        }
    }
}
