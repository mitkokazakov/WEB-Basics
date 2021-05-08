using BattleCards.Data;
using BattleCards.ViewModels.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleCards.Services
{
    public class CardsService : ICardsService
    {
        private readonly ApplicationDbContext db;

        public CardsService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void InsertCard(CardsInputModel model)
        {
            Card card = new Card()
            {
                Name = model.Name,
                ImageUrl = model.Image,
                Keyword = model.Keyword,
                Attack = model.Attack,
                Health = model.Health,
                Description = model.Description
            };

            this.db.Cards.Add(card);
            this.db.SaveChanges();
        }

        public IEnumerable<AllCardsViewModel> GetAllCards()
        {
            var allCards = this.db.Cards.Select(c => new AllCardsViewModel()
            {
                Id = c.Id,
                Name = c.Name,
                ImageUrl = c.ImageUrl,
                Keyword = c.Keyword,
                Attack = c.Attack,
                Health = c.Health,
                Descritpion = c.Description
            }).ToList();


            return allCards;
            
        }
    }
}
