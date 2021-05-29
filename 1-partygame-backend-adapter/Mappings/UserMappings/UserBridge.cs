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
            return new UserModel(user.getId(), user.getEmail(), user.getName(), mapToUserstatusFrom(user.ActualStatus));
        }

        public Userstatus mapToUserstatusFrom(Status status)
        {
            return new Userstatus(status.getId(), status.getName());
        }

        public HistoryModel mapToHistoryFrom(HistoryEntity history)
        {

            return new HistoryModel(history.Id, history.PlayedGames, history.NumberOfPenalties, mapToUserFrom(history.User));
        }
    }
}
