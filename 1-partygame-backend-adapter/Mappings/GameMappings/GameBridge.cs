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

        public GameEntity mapToGameEntityFrom(GameModel game)
        {

            return new GameEntity(game.Id, game.Name);
        }

        public Player mapToPlayerFrom(PlayerEntity player)
        {
            return new Player(mapToUserFrom(player.getPlayer()), mapToGameFrom(player.getGame()));
        }

        public PlayerEntity mapToPlayerEntityFrom(Player player)
        {
            return new PlayerEntity(mapToGameEntityFrom(player.Game), mapToUserEntityFrom(player.Spieler));
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

        public Taskcard mapToTaskcardFrom(_3_partygame_backend_domain.ValueObjects.TaskCard card)
        {
            return new Taskcard(card.getId(), card.getName(), card.getTask(), card.getPenalty());
        }

        public UserModel mapToUserFrom(UserEntity user)
        {
            UserBridge a = new UserBridge();
            UserModel newUser = new UserModel();

            newUser.ActualStatus = a.mapToUserstatusFrom(user.ActualStatus);
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

        public Carddeck mapToCarddeckFrom(CarddeckEntity deck)
        {
            return new Carddeck(deck.getId(), new Carddeckgenre(deck.getGenre().getId(), deck.getGenre().getName(), new RecommendedAge(deck.getGenre().getAge().getId(), deck.getGenre().getAge().getAgeRange(), deck.getGenre().getAge().getMinimumAge())), deck.getName(), deck.Rating, deck.GamesPlayedWith, deck.NumberOfRatings);
        }

        public GameHasDeck mapToGameHasDeckFrom(GameHasDeckEntity gameHasDeck)
        {
            return new GameHasDeck(mapToGameFrom(gameHasDeck.getGame()), mapToCarddeckFrom(gameHasDeck.getDeck()));
        }

        public TaskCard mapToTaskCardFrom(Taskcard card)
        {
            return new TaskCard(card.Id, card.Name, card.Task, card.Penalty);
        }

        public CarddeckEntity mapToCarddeckEntityFrom(Carddeck deck)
        {
            return new CarddeckEntity(deck.Id, deck.Name, mapToCarddeckgenreEntityFrom(deck.Genre));
        }


        public _3_partygame_backend_domain.ValueObjects.Carddeckgenre mapToCarddeckgenreEntityFrom(Carddeckgenre genre)
        {
            return new _3_partygame_backend_domain.ValueObjects.Carddeckgenre(genre.Id, genre.Name, mapToRecommendedAgeEntityFrom(genre.RecommendedAge));
        }

        public _3_partygame_backend_domain.ValueObjects.RecommendedAge mapToRecommendedAgeEntityFrom(RecommendedAge recommendedAge)
        {
            return new _3_partygame_backend_domain.ValueObjects.RecommendedAge(recommendedAge.Id, recommendedAge.Altersbereich, recommendedAge.Mindestalter);
        }
    }
}
