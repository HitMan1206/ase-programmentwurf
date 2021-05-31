using _1_partygame_backend_adapter.APIModels;
using _1_partygame_backend_adapter.APIModels.Context;
using _1_partygame_backend_adapter.APIModels.Friends;
using _1_partygame_backend_adapter.APIModels.History;
using _1_partygame_backend_adapter.APIModels.User;
using _1_partygame_backend_adapter.Mappings;
using _1_partygame_backend_adapter.Mappings.FriendMappings;
using _1_partygame_backend_adapter.Mappings.UserMappings;
using _2_partygame_backend_application.UseCases.User;
using _3_partygame_backend_domain.Entities;
using _3_partygame_backend_domain.Entities.AggregateEntities;
using _3_partygame_backend_domain.Repositories;
using _3_partygame_backend_domain.Services;
using _3_partygame_backend_domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace _1_partygame_backend_adapter.Services
{
    public class Userservice : UserRepository
    {
        private readonly DatabaseContext _context;
        private readonly UserBridge _bridge;
        private readonly ReturnObjectBridge _returnBridge;
        private readonly FriendBridge _friendBridge;
        private readonly ViewUser _viewUser;
        private readonly ManageUser _manageUser;

        public Userservice(DatabaseContext context)
        {
            _context = context;
            _bridge = new UserBridge();
            _friendBridge = new FriendBridge();
            _returnBridge = new ReturnObjectBridge();
        }

        /*public UserModel getUser(int userId)
        {
            return _context.UserModel.Where(item => item.Id == userId).FirstOrDefault();
        }

        public HistoryModel getHistory(int userId)
        {
            return _context.HistoryModel.Where(item => item.User.Id == userId).FirstOrDefault();
        }

        public IEnumerable<Friend> getFriends(int userId)
        {
            return _context.Friend.Where(item => item.Me.Id == userId).ToList();
        }

        public APIReturnObject addFriend(int userId, int friendId)
        {
            FriendEntity newFriend = new FriendEntity(_viewUser.getUserById(userId), _viewUser.getUserById(friendId));
            ReturnObject returnObject = _manageUser.addFriend(newFriend);
            if (returnObject.isSuccess())
            {
                _context.Friend.Add(_friendBridge.mapToFriendFrom(newFriend));
                _context.SaveChanges();
            }
            return _returnBridge.mapToAPIReturnObjectFrom(returnObject);
        }

        public APIReturnObject removeFriend(int userId, int friendId)
        {
            FriendEntity friend = _viewUser.getFriendById(friendId);
            ReturnObject returnObject = _manageUser.removeFriend(friend);
            if (returnObject.isSuccess())
            {
                _context.Friend.Remove(_friendBridge.mapToFriendFrom(friend));
                _context.SaveChanges();
            }
            return _returnBridge.mapToAPIReturnObjectFrom(returnObject);
        }

        public APIReturnObject updateHistory(int userId, int numberOfPenalties)
        {
            UserEntity user = _viewUser.getUserById(userId);
            HistoryEntity history = _viewUser.getHistory();
            ReturnObject returnObject = _manageUser.updateHistory(history);
            if (returnObject.isSuccess())
            {
                _context.HistoryModel.Where(item => item.User.Id == userId).FirstOrDefault().NumberOfPenalties = (history.NumberOfPenalties + numberOfPenalties);
                _context.HistoryModel.Where(item => item.User.Id == userId).FirstOrDefault().PlayedGames = (history.PlayedGames + 1);
                _context.Entry(_bridge.mapToUserFrom(user)).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }
            return _returnBridge.mapToAPIReturnObjectFrom(returnObject);
        }

        public APIReturnObject changeUserstatus(int userId, Status newStatus)
        {
            UserEntity user = _viewUser.getUserById(userId);
            ReturnObject returnObject = _manageUser.changeUserStatus(newStatus);
            if (returnObject.isSuccess())
            {
                _context.UserModel.Where(item => item.Id == userId).FirstOrDefault().ActualStatus = _bridge.mapToUserstatusFrom(newStatus);
                _context.Entry(_bridge.mapToUserFrom(user)).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }
            return _returnBridge.mapToAPIReturnObjectFrom(returnObject);
        }*/

        public ReturnObject create(int id, string name, string email, string password)
        {
            UserModel newUser = _bridge.mapToUserFrom(new UserEntity(id, email, name, password));
            if(_context.UserModel.Where(item => item.Id == newUser.Id).Count() < 1)
            {
                _context.UserModel.Add(newUser);
                _context.SaveChanges();
                return new ReturnObject(true, "User created");
            }
            return new ReturnObject(false, "User already exists.");
        }

        public ReturnObject delete(int userId)
        {
            if(_context.UserModel.Where(item => item.Id == userId).Count() < 1)
            {
                return new ReturnObject(false, "User does not exist");
            }
            _context.UserModel.Remove(_bridge.mapToUserFrom(findById(userId)));
            return new ReturnObject(true, "User deleted");
        }

        public ReturnObject changeStatus(int userId, int userstatusId)
        {
            if(_context.UserModel.Where(item => item.Id == userId).Count() < 1)
            {
                _context.UserModel.Where(item => item.Id == userId).FirstOrDefault().ActualStatusId = userstatusId;
                return new ReturnObject(true, "Status changed");
            }
            return new ReturnObject(false, "User not found");
        }

        public UserEntity findByEmail(string email)
        {
            if(_context.UserModel.Where(item => item.Email == email).Count() >= 1)
            {
                var user = _context.UserModel.Where(item => item.Email == email).FirstOrDefault();
                return new UserEntity(user.Id, user.Email, user.Username, user.Password);
            }
            return null;
        }

        public UserEntity findById(int userId)
        {
            if (_context.UserModel.Where(item => item.Id == userId).Count() >= 1)
            {
                var user = _context.UserModel.Where(item => item.Id == userId).FirstOrDefault();
                return new UserEntity(user.Id, user.Email, user.Username, user.Password);
            }
            return null;
        }

        public ReturnObject addFriend(int meId, int otherId)
        {
            _context.Friend.Add(_friendBridge.mapToFriendFrom(new FriendEntity(otherId, meId)));
            return new ReturnObject(true, "Friend added");
        }

        public ReturnObject deleteFriend(int userId, int friendId)
        {
            var friend = _context.Friend.Where(item => item.MeId == userId && item.OtherId == friendId);

            if (_context.Friend.Where(item => item.MeId == userId && item.OtherId == friendId).Count() < 1)
            {
                return new ReturnObject(false, "Freind does not exist");
            }
            _context.Friend.Remove(friend.FirstOrDefault());
            return new ReturnObject(true, "Friend deleted");
        }

        public Collection<FriendEntity> getFriendlist(int userId)
        {
            if (_context.Friend.Where(item => item.MeId == userId).Count() < 1)
             {
                 return null;
             }
             Collection<Friend> friends = new Collection<Friend>();
             foreach (Friend a in _context.Friend.Where(item => item.MeId == userId))
             {
                 friends.Add(a);
             }
             return _friendBridge.mapToFriendEntityCollectionFrom(friends);
        }

        public Collection<UserEntity> getAllUser()
        {
            Collection<UserModel> users = new Collection<UserModel>();
            foreach(UserModel a in _context.UserModel.ToList())
            {
                users.Add(a);
            }
            if(users.Count() < 1)
            {
                return null;
            }
            return _bridge.mapToUserEntityCollectionFrom(users);
            
        }

        public HistoryEntity getHistory(int userId)
        {
            var history = _context.HistoryModel.Where(item => item.UserId == userId);
            if(history.Count() < 1)
            {
                return null;
            }
            return _bridge.mapToHistoryEntityFrom(history.FirstOrDefault());
        }

        public ReturnObject updateHistory(int userId, HistoryEntity history)
        {
            if (_context.HistoryModel.Where(item => item.UserId == history.UserId).Count() < 1)
            {
                return new ReturnObject(false, "History not found");
            }
            var oldHistory = _context.HistoryModel.Where(item => item.UserId == history.UserId).FirstOrDefault();
            oldHistory.NumberOfPenalties = history.NumberOfPenalties;
            oldHistory.PlayedGames = history.PlayedGames;
            return new ReturnObject(true, "History updated");
        }

        public ReturnObject createHistory(int userId)
        {
            if(_context.HistoryModel.Where(item => item.UserId == userId).Count() < 1)
            {
                _context.HistoryModel.Add(_bridge.mapToHistoryFrom(new HistoryEntity(userId, userId)));
                return new ReturnObject(true, "History added");
            }
            return new ReturnObject(false, "User already has History");
        }
    }
}
