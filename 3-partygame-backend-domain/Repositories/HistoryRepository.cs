using _3_partygame_backend_domain.Entities;
using _3_partygame_backend_domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3_partygame_backend_domain.Repositories
{
    public interface HistoryRepository
    {
        HistoryEntity getHistoryFromUser(UserEntity user);

        ReturnObject update(HistoryEntity history);

        ReturnObject create(UserEntity user);
    }
}
