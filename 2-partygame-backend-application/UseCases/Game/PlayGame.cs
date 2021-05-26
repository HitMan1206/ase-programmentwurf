using _3_partygame_backend_domain.Entities;
using _3_partygame_backend_domain.Entities.AggregateEntities;
using _3_partygame_backend_domain.Repositories;
using _3_partygame_backend_domain.Services;
using _3_partygame_backend_domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace _2_partygame_backend_application.UseCases.Game
{
    public class PlayGame
    {
        private readonly GameRepository gameRepository;

        public PlayGame(GameRepository gameRepository)
        {
            this.gameRepository = gameRepository;
        }

        public TaskCard drawCard()
        {
            Collection<TaskCard> allCardsInGame = gameRepository.getCardsForGame();
            int randomNumber = new Random().Next(allCardsInGame.Count());
            return allCardsInGame.ElementAt(randomNumber);
        }

        public String getTask(GameEntity game)
        {
            return gameRepository.getActualCard(game).getTask();
        }

        public ReturnObject rateExecutionOfTask(GameEntity game, double rating)
        {
            double newRating;

            double actualRating = (gameRepository.getExecutionOfTaskRating(game)* gameRepository.getNumberOfExecutionOfTaskRatings(game));
            int newNumberOfRatings = (gameRepository.getNumberOfExecutionOfTaskRatings(game) + 1);

            newRating = (actualRating + rating)/newNumberOfRatings;

            gameRepository.updateExecutionOfTaskRating(newRating, newNumberOfRatings);
            return new ReturnObject(true, "Execution of Task Rating updated.");

        }

        public double getExecutionOfTaskRating(GameEntity game)
        {
            return gameRepository.getExecutionOfTaskRating(game);
        }

        public ReturnObject resetExecutionOfTaskRating()
        {
            gameRepository.resetExecutionOfTaskRating();
            return new ReturnObject(true, "Execution of Task Rating resetted.");
        }

        public String getPunishment(GameEntity game)
        {
            return gameRepository.getActualCard(game).getPenalty();
        }

        public ReturnObject changeActualPlayer(PlayerEntity player)
        {
            gameRepository.changeActualPlayingUser(player);
            return new ReturnObject(true, "Actual Player changed.");
        }

        public ReturnObject finishGame(GameEntity game)
        {
            gameRepository.delete(game);
            return new ReturnObject(true, "Game finished.");
        }
    }
}
