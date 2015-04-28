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
        private double winning;
        private double confident = 0;
        private int average;
        private int alpha;
     
        /*public static List<UCB> data = new List<UCB>();
        private static UCB upperConfident;*/

        public UCB(PlayerCard card, int parameter)
        {
            this.card = card;
            this.alpha = parameter;
        }

        public int Average
        {
            set { average = value; }
            get { return average; } 
        }
        public double Winning
        {
            set { winning = value; }
            get { return winning; }
        }

        public double Confident
        {
            get { return confident; }
        }

        public int NbPlayed
        {
            set { nbPlayed = value; }
            get { return nbPlayed; }
        }

        /// <summary>
        /// Using this simulate a play
        /// </summary>
        public PlayerCard Card
        {
            get { return card; }
        }

        /// <summary>
        /// Calculation of confident of UCB algorithm -> See the report
        /// </summary>
        public void confidentCalculation(int nbOfPlays){
            averageCalculation();
            double logt = Math.Log(nbOfPlays);
            confident = average + (alpha*logt)/(nbPlayed);
        }

        public void averageCalculation()
        {
            average = (int)winning / nbPlayed;
        }
    }
}
