using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BattleCards.Data
{
    public class Card
    {

        public Card()
        {
            this.Id = Guid.NewGuid().ToString();
            this.UserCards = new HashSet<UserCard>();
        }

        [Key]
        [Required]
        public string Id { get; set; }

        [Required]
        [MaxLength(15)]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string Keyword { get; set; }

        public int Attack { get; set; }

        public int Health { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        public ICollection<UserCard> UserCards { get; set; }

    }
}



