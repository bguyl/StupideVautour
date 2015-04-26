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
        private int confident = -1;
        private int average;
        private int alpha;

        private static int nbOfPlays;
        private static List<UCB> data = new List<UCB>();
        private static UCB upperConfident;

        public UCB(PlayerCard card, int parameter)
        {
            this.card = card;
            this.alpha = parameter;
            data.Add(this);
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
            get { nbPlayed++; nbOfPlays++; return card; }
        }

        /// <summary>
        /// Calculation of confident of UCB algorithm -> See the report
        /// </summary>
        public void confidentCalculation(){
            averageCalculation();
            int logt = (int)Math.Log(nbOfPlays);
            confident = average + (alpha*logt)/(nbPlayed);
        }

        public void averageCalculation()
        {
            average = nbWon / nbPlayed;
        }

        public static UCB findUpperConfident()
        {
            UCB tmp = data[0];
            foreach (UCB d in data)
                if (tmp.Confident < d.Confident)
                    tmp = d;
            upperConfident = tmp;
            return tmp;
        }

        public static void addWin()
        {
            upperConfident.nbWon++;
        }
    }
}
