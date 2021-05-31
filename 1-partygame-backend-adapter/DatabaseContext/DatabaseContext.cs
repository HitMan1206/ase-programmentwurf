using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _1_partygame_backend_adapter.APIModels.Carddecks;
using _1_partygame_backend_adapter.APIModels.Friends;
using _1_partygame_backend_adapter.APIModels.Game;
using _1_partygame_backend_adapter.APIModels.History;
using _1_partygame_backend_adapter.APIModels.User;
using Microsoft.EntityFrameworkCore;

namespace _1_partygame_backend_adapter.APIModels.Context
{
    public class DatabaseContext : DbContext
    {

        private static readonly DatabaseContext instance;

        private DatabaseContext(DbContextOptions<DatabaseContext> options): base(options) { }

        public static DatabaseContext getInstance()
        {
            if(instance == null)
            {
                new DatabaseContext(new DbContextOptions<DatabaseContext>());
            }
            return instance;
        }

        public DbSet<Carddeck> Carddeck { get; set; }

        public DbSet<Carddeckgenre> Carddeckgenre { get; set; }

        public DbSet<DeckIncludesCard> DeckIncludesCard { get; set; }

        public DbSet<RecommendedAge> RecommendedAge { get; set; }

        public DbSet<Taskcard> Taskcard { get; set; }

        public DbSet<Friend> Friend { get; set; }

        public DbSet<GameModel> GameModel { get; set; }

        public DbSet<GameHasDeck> GameHasDeck { get; set; }

        public DbSet<GamemodeModel> Gamemode { get; set; }

        public DbSet<GamemodeIncludesDeck> GamemodeIncludesDeck { get; set; }

        public DbSet<Gamestatus> Gamestatus { get; set; }

        public DbSet<Player> Player { get; set; }

        public DbSet<HistoryModel> HistoryModel { get; set; }

        public DbSet<UserModel> UserModel { get; set; }

        public DbSet<Userstatus> Userstatus { get; set; }

        public DbSet<APIReturnObject> APIReturnObject { get; set; }
    }
}
