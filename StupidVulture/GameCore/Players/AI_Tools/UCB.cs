using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StupidVulture.GameCore.Cards;

namespace StupidVulture.GameCore.Players.AI_Tools
{
    public class UCB
    {
        private PlayerCard card;
        private int nbPlayed;
        private int nbWon;
        private int confident = 0;
        private int average;
        private int alpha;
     
        /*public static List<UCB> data = new List<UCB>();
        private static UCB upperConfident;*/

        public UCB(PlayerCard card, int parameter)
        {
            this.card = card;
            this.alpha = parameter;
        }

        public int NbWon
        {
            set { nbWon = value; }
            get { return nbWon; }
        }

        public int Confident
        {
            get { return confident; }
        }

        /// <summary>
        /// Using this simulate a play
        /// </summary>
        public PlayerCard Card
        {
            get { nbPlayed++; return card; }
        }

        /// <summary>
        /// Calculation of confident of UCB algorithm -> See the report
        /// </summary>
        public void confidentCalculation(int nbOfPlays){
            averageCalculation();
            int logt = (int)Math.Log(nbOfPlays);
            confident = average + (alpha*logt)/(nbPlayed);
        }

        public void averageCalculation()
        {
            average = nbWon / nbPlayed;
        }

    }
}
