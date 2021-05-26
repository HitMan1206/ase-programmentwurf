using _3_partygame_backend_domain.Repositories;
using _3_partygame_backend_domain.Services;
using _3_partygame_backend_domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _2_partygame_backend_application.UseCases.CardDecks
{
    public class AddNewCard
    {
        private readonly CarddeckRepository carddeckRepository;

        public AddNewCard(CarddeckRepository carddeckRepository)
        {
            this.carddeckRepository = carddeckRepository;
        }

        public ReturnObject addNewCard(TaskCard card)
        {
            try
            {
                carddeckRepository.addCard(card);
                return new ReturnObject(true, "Card added.");
            }catch(Exception e)
            {
                return new ReturnObject(false, e.Message);
            }
        }
    }
}
