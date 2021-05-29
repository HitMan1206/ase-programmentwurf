using _1_partygame_backend_adapter.APIModels;
using _1_partygame_backend_adapter.APIModels.Context;
using _1_partygame_backend_adapter.APIModels.Friends;
using _1_partygame_backend_adapter.APIModels.History;
using _1_partygame_backend_adapter.APIModels.User;
using _1_partygame_backend_adapter.Mappings;
using _1_partygame_backend_adapter.Mappings.FriendMappings;
using _1_partygame_backend_adapter.Mappings.UserMappings;
using _2_partygame_backend_application.UseCases.History;
using _2_partygame_backend_application.UseCases.User;
using _3_partygame_backend_domain.Entities;
using _3_partygame_backend_domain.Entities.AggregateEntities;
using _3_partygame_backend_domain.Services;
using _3_partygame_backend_domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1_partygame_backend_adapter.Services
{
    public class Userservice
    {
        private readonly DatabaseContext _context;
        private readonly UserBridge _bridge;
        private readonly ReturnObjectBridge _returnBridge;
        private readonly FriendBridge _friendBridge;
        private readonly ViewUser _viewUser;
        private readonly ManageUser _manageUser;
        private readonly ManageHistory _manageHistory;

        public Userservice(DatabaseContext context, ViewUser viewUser, ManageUser manageUser, ManageHistory manageHistory)
        {
            _context = context;
            _bridge = new UserBridge();
            _friendBridge = new FriendBridge();
            _returnBridge = new ReturnObjectBridge();
            _viewUser = viewUser;
            _manageUser = manageUser;
            _manageHistory = manageHistory;
        }

        public UserModel getUser(int userId)
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
            ReturnObject returnObject = _manageHistory.updateHistory(history);
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
        }
    }
}
