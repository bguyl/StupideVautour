using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StupidVulture.GameCore.Cards;

namespace StupidVulture.GameCore.Players.AI_Tools
{
    class UCB
    {
        private PlayerCard card;
        private int nbPlayed;
        private int nbWon;
        private int confident;
        private int average;
        private int alpha;

        static int nbOfPlays;

        public UCB(PlayerCard card, int parameter)
        {
            this.card = card;
            this.alpha = parameter;
        }

        /// <summary>
        /// Calculation of confident of UCB algorithm -> See the report
        /// </summary>
        public void confidentCalculation(){
            int logt = (int)Math.Log(nbOfPlays);
            confident = average + (alpha*logt)/(nbPlayed);
        }

        public void averageCalculation()
        {
            average = nbWon / nbPlayed;
        }
    }
}
