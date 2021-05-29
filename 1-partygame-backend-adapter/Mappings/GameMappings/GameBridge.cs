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

        public GameBridge()
        {
        }

        public GameModel mapToGameFrom(GameEntity game)
        {

            return new GameModel(game.getId(), game.Name, mapToUserFrom(game.ActualPlayingUser), mapToGamestatusFrom(game.Status), mapToGamemodeFrom(game.Gamemode), mapToTaskcardFrom(game.ActualCard), game.ExecuteOfTaskRating, game.NumberOfExecutionOfTaskRatings);
        }

        public Player mapToPlayerFrom(PlayerEntity player)
        {
            return new Player(mapToUserFrom(player.getPlayer()), mapToGameFrom(player.getGame()));
        }

        public Gamestatus mapToGamestatusFrom(Status status)
        {
            return new Gamestatus(status.getId(), status.getName());
        }

        public GamemodeModel mapToGamemodeFrom(_3_partygame_backend_domain.ValueObjects.Gamemode gamemode)
        {
            return new GamemodeModel(gamemode.getId(), gamemode.getName());
        }

        public Taskcard mapToTaskcardFrom(_3_partygame_backend_domain.ValueObjects.TaskCard card)
        {
            return new Taskcard(card.getId(), card.getName(), card.getTask(), card.getPenalty());
        }

        public UserModel mapToUserFrom(UserEntity user)
        {
            return new UserModel(user.getId(), user.getEmail(), user.getName(), user.getPassword(), new Userstatus(user.ActualStatus.getId(), user.ActualStatus.getName()));
        }

        public Carddeck mapToCarddeckFrom(CarddeckEntity deck)
        {
            return new Carddeck(deck.getId(), new Carddeckgenre(deck.getGenre().getId(), deck.getGenre().getName(), new RecommendedAge(deck.getGenre().getAge().getId(), deck.getGenre().getAge().getAgeRange(), deck.getGenre().getAge().getMinimumAge())), deck.getName(), deck.Rating, deck.GamesPlayedWith, deck.NumberOfRatings);
        }

        public GameHasDeck mapToGameHasDeckFrom(GameHasDeckEntity gameHasDeck)
        {
            return new GameHasDeck(mapToGameFrom(gameHasDeck.getGame()), mapToCarddeckFrom(gameHasDeck.getDeck()));
        }
    }
}
