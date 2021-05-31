using _1_partygame_backend_adapter.APIModels.History;
using _1_partygame_backend_adapter.APIModels.User;
using _2_partygame_backend_application.UseCases.User;
using _3_partygame_backend_domain.Entities;
using _3_partygame_backend_domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace _1_partygame_backend_adapter.Mappings.UserMappings
{
    public class UserBridge
    {

        public UserBridge()
        {
        }

        public UserModel mapToUserFrom(UserEntity user)
        {
            UserModel newUser = new UserModel();

            newUser.ActualStatus = mapToUserstatusFrom(user.ActualStatus);
            newUser.Email = user.getEmail();
            newUser.Password = user.getPassword();
            newUser.Username = user.getName();
            newUser.Id = user.getId();
            return newUser;
        }

        public UserEntity mapToUserEntityFrom(UserModel user)
        {

            return new UserEntity(user.Id, user.Email, user.Username, user.Password);
        }

        public Userstatus mapToUserstatusFrom(Status status)
        {
            return new Userstatus(status.getId(), status.getName());
        }

        public HistoryModel mapToHistoryFrom(HistoryEntity history)
        {

            return new HistoryModel(history.Id, history.PlayedGames, history.NumberOfPenalties, mapToUserFrom(history.User));
        }

        public HistoryEntity mapToHistoryEntityFrom(HistoryModel history)
        {

            return new HistoryEntity(history.Id, mapToUserEntityFrom(history.User));
        }

    }
}
