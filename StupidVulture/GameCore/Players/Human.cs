using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StupidVulture.GameCore.Cards;

namespace StupidVulture.GameCore.Players
{
    public class Human : Player
    {
        public Human(Color color) : base(color)
        {
            
        }

        public PlayerCard playRandom()
        {
            Random rand = new Random();
            int i = rand.Next(remainingCards.Count() - 1);
            currentPlayerCard = remainingCards[i];
            remainingCards.Remove(currentPlayerCard);
            return currentPlayerCard;
        }
    }
}
