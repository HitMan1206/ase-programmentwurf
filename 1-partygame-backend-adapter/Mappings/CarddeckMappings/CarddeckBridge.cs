using _1_partygame_backend_adapter.APIModels.Carddecks;
using _1_partygame_backend_adapter.APIModels.Game;
using _2_partygame_backend_application.UseCases.CardDecks;
using _3_partygame_backend_domain.AggregateEntities;
using _3_partygame_backend_domain.Entities;
using _3_partygame_backend_domain.Repositories;
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


        public Carddeckgenre mapToCarddeckgenreFrom(_3_partygame_backend_domain.ValueObjects.Carddeckgenre genre)
        {
            return new Carddeckgenre(genre.getId(), genre.getName(), mapToRecommendedAgeFrom(genre.getAge()));
        }

        public RecommendedAge mapToRecommendedAgeFrom(_3_partygame_backend_domain.ValueObjects.RecommendedAge recommendedAge)
        {
            return new RecommendedAge(recommendedAge.getId(), recommendedAge.getAgeRange(), recommendedAge.getMinimumAge());
        }

        public Taskcard mapToTaskcardFrom(_3_partygame_backend_domain.ValueObjects.TaskCard card)
        {
            return new Taskcard(card.getId(), card.getName(), card.getTask(), card.getPenalty());
        }


        public DeckIncludesCard mapToDeckIncludesCardFrom(DeckIncludesCardEntity deckIncludesCard)
        {
            return new DeckIncludesCard(deckIncludesCard.getId(), mapToCarddeckFrom(deckIncludesCard.getDeck()), mapToTaskcardFrom(deckIncludesCard.getCard()));
        }
    }
}
