using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StupidVulture.GameCore.Cards;

namespace StupidVulture.GameCore.Players.AI_Tools
{
    public class Data
    {
        private PlayerCard card;            
        private int nbPlayed;               //How many this card was tried in the virtualisation
        private double winning;             //Represent our account : PointCard.Value - PlayerCard.Value for each play
        private double average;             //The average of winning
        private double alpha;               //A parameter 

        public double probaEstimation;      //'proba'*(Winning-Cost)
        public double nbOfWin;              //How many this card has won in the virtualisation


        public Data(PlayerCard card, int parameter) {
            this.card = card;
            this.alpha = parameter;
        }

        public double Average {
            set { average = value; }
            get { return average; }
        }

        public double Winning {
            set { winning = value; }
            get { return winning; }
        }

        public double Confident {
            get { return confident; }
        }

        public int NbPlayed {
            set { nbPlayed = value; }
            get { return nbPlayed; }
        }


        public PlayerCard Card {
            get { return card; }
        }


        public void averageCalculation() {
            average = winning / nbPlayed;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point">The value point</param>
        public void probabilityCalculation(int point) {
            //Negative values reevaluated !
            if (point < 0)
                point = -2 * point;

            //Formula : estimateur = (estimated proba)*(point*2,75 - card.value);
            //2,75 is an arbitrary parameter
            probaEstimation = (nbOfWin / nbPlayed) * ( point*2.75 - card.Value);
        }
    }
}
