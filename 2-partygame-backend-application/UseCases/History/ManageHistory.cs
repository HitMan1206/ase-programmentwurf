using _3_partygame_backend_domain.Entities;
using _3_partygame_backend_domain.Repositories;
using _3_partygame_backend_domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _2_partygame_backend_application.UseCases.History
{
    public class ManageHistory
    {
        private readonly HistoryRepository historyRepository;

        public ManageHistory(HistoryRepository historyRepository)
        {
            this.historyRepository = historyRepository;
        }

        public ReturnObject createHistory(UserEntity user)
        {
            if (user.HasHistory)
            {
                return new ReturnObject(false, "User already has a History.");
            }
            else
            {
                historyRepository.create(user);
                user.HasHistory = true;
                return new ReturnObject(true, "History created.");
            }
        }

        public ReturnObject updateHistory(HistoryEntity history)
        {
            try
            {
                historyRepository.update(history);
                return new ReturnObject(true, "History Updated.");
            }catch(Exception e)
            {
                return new ReturnObject(false, e.Message);
            }
        }
    }
}
