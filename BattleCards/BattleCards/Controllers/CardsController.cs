using BattleCards.ViewModels.Cards;
using SIS.HTTP;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleCards.Controllers
{
    public class CardsController : Controller
    {
        public HttpResponse All()
        {
            return this.View();
        }

        public HttpResponse Add()
        {
            return this.View();
        }

        public HttpResponse Collection()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(CardsInputModel model)
        {
            if (model.Name.Length < 5 || model.Name.Length > 15 || String.IsNullOrEmpty(model.Name))
            {
                return this.Error("Invalid length of the Name!");
            }

            if (String.IsNullOrEmpty(model.Image))
            {
                return this.Error("The ImageUrl field is required");
            }

            if (String.IsNullOrEmpty(model.Keyword))
            {
                return this.Error("The Keyword field is required");
            }

            if (model.Attack < 0)
            {
                return this.Error("The Attack can not be negative");
            }

            if (model.Health < 0)
            {
                return this.Error("The Health can not be negative");
            }

            if (model.Description.Length > 200 || String.IsNullOrEmpty(model.Description))
            {
                return this.Error("Invalid length of the description");
            }
        }
    }
}
