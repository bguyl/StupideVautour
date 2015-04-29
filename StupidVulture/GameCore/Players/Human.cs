using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StupidVulture.GameCore.Cards;
using System.Windows.Forms;

namespace StupidVulture.GameCore.Players
{
    public class Human : Player {

        private bool played = false; // true if the human player already played, false if not
        
        public bool Played {
            get { return played; }
            set { played = value; }
        }

        public Human(Color color) : base(color)
        {
            
        }


        /// <summary>
        /// Play the card of value i+1
        /// </summary>
        /// <param name="i">index of the selected PictureBox</param>
        public void play(int i) {

            currentPlayerCard = remainingCards.Find(card => card.Value == i + 1);
            remainingCards.Remove(currentPlayerCard);
        }

        public override PlayerCard play(PointCard point)  {
            played = false;
            while(!played) {
                Application.DoEvents();
                Application.DoEvents();
            }
            return currentPlayerCard;
        }

        
    }
}
