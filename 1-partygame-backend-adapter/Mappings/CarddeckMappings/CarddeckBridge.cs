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

        public Collection<CarddeckEntity> mapToCarddeckEntityCollectionFrom(Collection<Carddeck> decks)
        {
            Collection<CarddeckEntity> carddecks = new Collection<CarddeckEntity>();
            foreach(Carddeck a in decks)
            {
                carddecks.Add(mapToCarddeckEntityFrom(a));
            }
            return carddecks;
        }

        public Collection<Carddeck> mapToCarddeckCollectionFrom(Collection<CarddeckEntity> decks)
        {
            Collection<Carddeck> carddecks = new Collection<Carddeck>();
            foreach (CarddeckEntity a in decks)
            {
                carddecks.Add(mapToCarddeckFrom(a));
            }
            return carddecks;
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

        public Collection<TaskCard> mapToTaskCardCollectionFrom(Collection<Taskcard> cards)
        {
            Collection<TaskCard> mappedCards = new Collection<TaskCard>();
            foreach(Taskcard a in cards)
            {
                mappedCards.Add(mapToTaskCardFrom(a));
            }
            return mappedCards;
        }

        public Collection<Taskcard> mapToTaskcardCollectionFrom(Collection<TaskCard> cards)
        {
            Collection<Taskcard> mappedCards = new Collection<Taskcard>();
            foreach (TaskCard a in cards)
            {
                mappedCards.Add(mapToTaskcardFrom(a));
            }
            return mappedCards;
        }


        public DeckIncludesCard mapToDeckIncludesCardFrom(DeckIncludesCardEntity deckIncludesCard)
        {
            return new DeckIncludesCard(mapToCarddeckFrom(deckIncludesCard.getDeck()), mapToTaskcardFrom(deckIncludesCard.getCard()));
        }
    }
}
