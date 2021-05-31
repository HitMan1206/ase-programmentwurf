using _1_partygame_backend_adapter.APIModels.Carddecks;
using _1_partygame_backend_adapter.APIModels.Game;
using _1_partygame_backend_adapter.APIModels.User;
using _1_partygame_backend_adapter.Mappings.CarddeckMappings;
using _1_partygame_backend_adapter.Mappings.UserMappings;
using _2_partygame_backend_application.UseCases.Game;
using _3_partygame_backend_domain.AggregateEntities;
using _3_partygame_backend_domain.Entities;
using _3_partygame_backend_domain.Entities.AggregateEntities;
using _3_partygame_backend_domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Carddeckgenre = _1_partygame_backend_adapter.APIModels.Carddecks.Carddeckgenre;
using GamemodeModel = _1_partygame_backend_adapter.APIModels.Game.GamemodeModel;
using RecommendedAge = _1_partygame_backend_adapter.APIModels.Carddecks.RecommendedAge;

namespace _1_partygame_backend_adapter.Mappings.GameMappings
{
    public class GameBridge
    {
        private readonly UserBridge _userbridge = new UserBridge();
        private readonly CarddeckBridge _deckbridge = new CarddeckBridge();

        public GameBridge()
        {
        }

        public GameModel mapToGameFrom(GameEntity game)
        {

            return new GameModel(game.getId(), game.Name, game.ActualPlayingUser.getId(), game.Status.getId(), game.Gamemode.getId(), game.ActualCard.getId(), game.ExecuteOfTaskRating, game.NumberOfExecutionOfTaskRatings);
        }

        public GameEntity mapToGameEntityFrom(GameModel game)
        {

            return new GameEntity(game.Id, game.Name);
        }

        public Collection<GameEntity> mapToGameEntityCollectionFrom(Collection<GameModel> games)
        {
            Collection<GameEntity> mappedGames = new Collection<GameEntity>();
            foreach(GameModel a in games)
            {
                mappedGames.Add(mapToGameEntityFrom(a));
            }
            return mappedGames;
        }

        public Player mapToPlayerFrom(PlayerEntity player)
        {
            return new Player(player.getUserId(), player.getGameId());
        }

        public PlayerEntity mapToPlayerEntityFrom(Player player)
        {
            return new PlayerEntity(player.GameId, player.SpielerId);
        }

        public Collection<Player> mapToPlayerCollectionFrom(Collection<PlayerEntity> players)
        {
            Collection<Player> mappedPlayers = new Collection<Player>();
            foreach(PlayerEntity a in players)
            {
                mappedPlayers.Add(mapToPlayerFrom(a));
            }
            return mappedPlayers;
        }

        public Collection<PlayerEntity> mapToPlayerEntityCollectionFrom(Collection<Player> players)
        {
            Collection<PlayerEntity> mappedPlayers = new Collection<PlayerEntity>();
            foreach (Player a in players)
            {
                mappedPlayers.Add(mapToPlayerEntityFrom(a));
            }
            return mappedPlayers;
        }

        public Gamestatus mapToGamestatusFrom(Status status)
        {
            return new Gamestatus(status.getId(), status.getName());
        }

        public Status mapToStatusFrom(Gamestatus status)
        {
            return new Status(status.Id, status.Name);
        }

        public GamemodeModel mapToGamemodeFrom(_3_partygame_backend_domain.ValueObjects.Gamemode gamemode)
        {
            return new GamemodeModel(gamemode.getId(), gamemode.getName());
        }

        public Gamemode mapToGamemodeEntityFrom(GamemodeModel gamemode)
        {
            return new Gamemode(gamemode.Id, gamemode.Name);
        }

        public Collection<Gamemode> mapToGamemodeEntityCollectionFrom(Collection<GamemodeModel> gamemodes)
        {
            Collection<Gamemode> mappedGamemodes = new Collection<Gamemode>();
            foreach(GamemodeModel a in gamemodes)
            {
                mappedGamemodes.Add(mapToGamemodeEntityFrom(a));
            }
            return mappedGamemodes;
        }


        public GameHasDeck mapToGameHasDeckFrom(GameHasDeckEntity gameHasDeck)
        {
            return new GameHasDeck(gameHasDeck.getGame().getId(), gameHasDeck.getDeck().getId());
        }
    }
}
