using BattleCards.Data;
using BattleCards.ViewModels.Cards;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleCards.Services
{
    public interface ICardsService
    {
        void InsertCard(CardsInputModel model);

        IEnumerable<AllCardsViewModel> GetAllCards();
    }
}
