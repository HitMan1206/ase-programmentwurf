using _3_partygame_backend_domain.Entities;
using _3_partygame_backend_domain.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace _2_partygame_backend_application.UseCases.Game
{
    public class ViewGame
    {
        private readonly GameRepository gameRepository;

        public ViewGame(GameRepository gameRepository)
        {
            this.gameRepository = gameRepository;
        }

        public GameEntity getGameById(int gameId)
        {
            return gameRepository.getById(gameId);
        }

        public Collection<GameEntity> getAllGames()
        {
            return gameRepository.getAllGames();
        }

        public Collection<CarddeckEntity> getDecksForGame(int gameId)
        {
            return gameRepository.getDecksForGame(gameId);
        }
    }
}
