﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace BattleCards.Data
{
    public class UserCard
    {
        public string UserId { get; set; }

        public virtual User User { get; set; }

        public string CardId { get; set; }

        public virtual Card Card { get; set; }
    }
}
