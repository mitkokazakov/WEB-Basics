using System;
using System.Collections.Generic;
using System.Text;

namespace BattleCards.ViewModels.Cards
{
    public class AllCardsViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Keyword { get; set; }

        public string ImageUrl { get; set; }

        public int Attack { get; set; }

        public int Health { get; set; }

        public string Descritpion { get; set; }
    }
}
