using _1_partygame_backend_adapter.APIModels;
using _1_partygame_backend_adapter.APIModels.Context;
using _1_partygame_backend_adapter.APIModels.History;
using _1_partygame_backend_adapter.APIModels.User;
using _1_partygame_backend_adapter.Mappings;
using _1_partygame_backend_adapter.Mappings.UserMappings;
using _2_partygame_backend_application.UseCases.Authentication;
using _2_partygame_backend_application.UseCases.User;
using _3_partygame_backend_domain.Entities;
using _3_partygame_backend_domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _1_partygame_backend_adapter.Services
{
    public class Authservice
    {
        private readonly DatabaseContext _context;
        private readonly ReturnObjectBridge _returnBridge;
        private readonly UserBridge _bridge;
        private readonly LoginUser _loginUser;
        private readonly RegisterUser _registerUser;
        private readonly ViewUser _viewUser;

        private static readonly string NAME_REGEX = "(?:[A-Z]|[a-z]|[0-9]|_){4,16}";
        private static readonly string EMAIL_REGEX = "(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\e.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|\"(?:[\x01 -\x08\x0b\x0c\x0e -\x1f\x21\x23 -\x5b\x5d -\x7f] |\\[\x01 -\x09\x0b\x0c\x0e -\x7f])*\")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\e.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\\e[(?:(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9]))\\e.){3}(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9])|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\\e])";
        private static readonly string PASSWORD_REGEX = "^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[*.!@$%^&(){}#=+]).{8,}$";


        public Authservice(DatabaseContext context, ViewUser viewUser)
        {
            _context = context;
            _returnBridge = new ReturnObjectBridge();
            _bridge = new UserBridge();
            _viewUser = viewUser;
        }

        public APIReturnObject login(string email, string password)
        {
            UserEntity user = _viewUser.getUserbyEmail(email);
            if(BCrypt.Net.BCrypt.Verify(password, user.getPassword()))
            {
                return _returnBridge.mapToAPIReturnObjectFrom(_loginUser.loginUser(email, password));
            }
            return _returnBridge.mapToAPIReturnObjectFrom(new ReturnObject(false, "Invalid Password or Email."));
            
        }
        
        public APIReturnObject register(String email, String name, string password)
        {

            if (!Regex.IsMatch(name, NAME_REGEX)) return _returnBridge.mapToAPIReturnObjectFrom(new ReturnObject(false, "Invalid Username."));
            if (!Regex.IsMatch(email, EMAIL_REGEX)) return _returnBridge.mapToAPIReturnObjectFrom(new ReturnObject(false, "Invalid Email."));
            if (!Regex.IsMatch(password, PASSWORD_REGEX)) return _returnBridge.mapToAPIReturnObjectFrom(new ReturnObject(false, "Invalid Password."));

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
            ReturnObject returnObject = _registerUser.registerUser(email, hashedPassword, name);
            UserEntity newUser = _viewUser.getUserbyEmail(email);
            if (returnObject.isSuccess())
            {
                _context.UserModel.Add(new UserModel(newUser.getId(), email, name, hashedPassword, _bridge.mapToUserstatusFrom(newUser.ActualStatus)));
                _context.HistoryModel.Add(new HistoryModel(_viewUser.getHistory().Id, 0, 0, _bridge.mapToUserFrom(newUser)));
                _context.SaveChanges();
            }

            return _returnBridge.mapToAPIReturnObjectFrom(returnObject);
        }
    }
}
