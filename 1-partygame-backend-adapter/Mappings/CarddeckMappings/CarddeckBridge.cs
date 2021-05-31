using _1_partygame_backend_adapter.APIModels.Carddecks;
using _1_partygame_backend_adapter.APIModels.Game;
using _2_partygame_backend_application.UseCases.CardDecks;
using _3_partygame_backend_domain.AggregateEntities;
using _3_partygame_backend_domain.Entities;
using _3_partygame_backend_domain.Repositories;
using _3_partygame_backend_domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Carddeckgenre = _1_partygame_backend_adapter.APIModels.Carddecks.Carddeckgenre;
using RecommendedAge = _1_partygame_backend_adapter.APIModels.Carddecks.RecommendedAge;

namespace _1_partygame_backend_adapter.Mappings.CarddeckMappings
{
    public class CarddeckBridge
    {

        public CarddeckBridge()
        {
        }

        public Carddeck mapToCarddeckFrom(CarddeckEntity deck)
        {
            return new Carddeck(deck.getId(), mapToCarddeckgenreFrom(deck.getGenre()), deck.getName(), deck.Rating, deck.GamesPlayedWith, deck.NumberOfRatings);
        }

        public CarddeckEntity mapToCarddeckEntityFrom(Carddeck deck)
        {
            return new CarddeckEntity(deck.Id, deck.Name, mapToCarddeckgenreEntityFrom(deck.Genre));
        }


        public Carddeckgenre mapToCarddeckgenreFrom(_3_partygame_backend_domain.ValueObjects.Carddeckgenre genre)
        {
            return new Carddeckgenre(genre.getId(), genre.getName(), mapToRecommendedAgeFrom(genre.getAge()));
        }

        public _3_partygame_backend_domain.ValueObjects.Carddeckgenre mapToCarddeckgenreEntityFrom(Carddeckgenre genre)
        {
            return new _3_partygame_backend_domain.ValueObjects.Carddeckgenre(genre.Id, genre.Name, mapToRecommendedAgeEntityFrom(genre.RecommendedAge));
        }

        public RecommendedAge mapToRecommendedAgeFrom(_3_partygame_backend_domain.ValueObjects.RecommendedAge recommendedAge)
        {
            return new RecommendedAge(recommendedAge.getId(), recommendedAge.getAgeRange(), recommendedAge.getMinimumAge());
        }

        public _3_partygame_backend_domain.ValueObjects.RecommendedAge mapToRecommendedAgeEntityFrom(RecommendedAge recommendedAge)
        {
            return new _3_partygame_backend_domain.ValueObjects.RecommendedAge(recommendedAge.Id, recommendedAge.Altersbereich, recommendedAge.Mindestalter);
        }

        public Taskcard mapToTaskcardFrom(_3_partygame_backend_domain.ValueObjects.TaskCard card)
        {
            return new Taskcard(card.getId(), card.getName(), card.getTask(), card.getPenalty());
        }

        public TaskCard mapToTaskCardFrom(Taskcard card)
        {
            return new TaskCard(card.Id, card.Name, card.Task, card.Penalty);
        }


        public DeckIncludesCard mapToDeckIncludesCardFrom(DeckIncludesCardEntity deckIncludesCard)
        {
            return new DeckIncludesCard(mapToCarddeckFrom(deckIncludesCard.getDeck()), mapToTaskcardFrom(deckIncludesCard.getCard()));
        }

        public GamemodeModel mapToGamemodeFrom(_3_partygame_backend_domain.ValueObjects.Gamemode gamemode)
        {
            return new GamemodeModel(gamemode.getId(), gamemode.getName());
        }

        public Gamemode mapToGamemodeModelFrom(GamemodeModel gamemode)
        {
            return new Gamemode(gamemode.Id, gamemode.Name);
        }
    }
}
