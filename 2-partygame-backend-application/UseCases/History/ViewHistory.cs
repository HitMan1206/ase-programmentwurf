using _3_partygame_backend_domain.Entities;
using _3_partygame_backend_domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _2_partygame_backend_application.UseCases.History
{
    public class ViewHistory
    {
        private readonly HistoryRepository historyRepository;

        public ViewHistory(HistoryRepository historyRepository)
        {
            this.historyRepository = historyRepository;
        }

        public HistoryEntity getHistoryFromUser(UserEntity user)
        {
            return historyRepository.getHistoryFromUser(user);
        }
    }
}
