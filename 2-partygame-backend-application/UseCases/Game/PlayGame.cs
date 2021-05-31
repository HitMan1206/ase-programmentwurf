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

        public TaskCard drawCard(int gameId)
        {
            Collection<TaskCard> allCardsInGame = gameRepository.getCardsForGame(gameId);
            if(!(allCardsInGame.Count() < 1))
            {
                int randomNumber = new Random().Next(allCardsInGame.Count());
                return allCardsInGame.ElementAt(randomNumber);
            }
            return null;

        }

        public String getTask(int gameId)
        {
            if(gameRepository.getById(gameId).ActualCard == null)
            {
                return "No ActualCard set";
            }
            return gameRepository.getById(gameId).ActualCard.getTask();
        }

        public ReturnObject rateExecutionOfTask(int gameId, double rating)
        {
            gameRepository.addExecutionOfTaskRating(gameId, rating);
            return new ReturnObject(true, "Execution of Task Rating updated.");

        }

        public ReturnObject resetExecutionOfTaskRating(int gameId)
        {
            gameRepository.resetExecutionOfTaskRating(gameId);
            return new ReturnObject(true, "Execution of Task Rating resetted.");
        }

        public String getPunishment(int gameId)
        {
            if (gameRepository.getById(gameId).ActualCard == null)
            {
                return "No ActualCard set";
            }
            return gameRepository.getById(gameId).ActualCard.getPenalty();
        }

        public ReturnObject changeActualPlayer(int playerId, int gameId)
        {
            gameRepository.changeActualPlayingUser(playerId, gameId);
            return new ReturnObject(true, "Actual Player changed.");
        }

        public ReturnObject finishGame(GameEntity game)
        {
            gameRepository.delete(game);
            return new ReturnObject(true, "Game finished.");
        }
    }
}
