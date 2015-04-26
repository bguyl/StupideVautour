using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StupidVulture.GameCore.Cards;
using System.Windows.Forms;

namespace StupidVulture.GameCore.Players
{
    public class Human : Player
    {
        private bool played = false;
        
        public bool Played
        {
            get { return played; }
            set { played = value; }
        }
        public Human(Color color) : base(color)
        {
            
        }


        public void play(int i)
        {
            currentPlayerCard = remainingCards.Find(card => card.Value == i + 1);

            remainingCards.Remove(currentPlayerCard);
        }

        public override PlayerCard play(PointCard point)
        {
            played = false;
            while(!played)
            {
                Application.DoEvents();
                Application.DoEvents();
            }
            return currentPlayerCard;
        }

        
    }
}
