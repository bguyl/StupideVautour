using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StupidVulture.GameCore.Cards;
using StupidVulture.GameCore.Players.AI_Tools;

namespace StupidVulture.GameCore.Players
{
    public enum Difficulty {EASY, MEDIUM, HARD};

    public class AI : Player
    {
        private Difficulty difficulty;
        private List<Player> opponent = new List<Player>();
        private List<Clone> virtualPlayers = new List<Clone>();
        private List<UCB> data = new List<UCB>();
        private UCB upperConfident;

        public AI(Color color, Difficulty difficulty) : base(color)
        {
            this.difficulty = difficulty;
            int param = 2;
            switch (difficulty)
            {
                case Difficulty.EASY: param = 2; break;
                case Difficulty.MEDIUM: param = 3; break;
                default: param = 25; break;
            }
            foreach (PlayerCard card in remainingCards)
            {
                UCB d = new UCB(card, param);
                data.Add(d);
            }
        }

        public List<Player> Opponent
        {
            get { return opponent; }
            set { opponent = value; }
        }


        /// <summary>
        /// Create numerous virtual game and choose the best card.
        /// </summary>
        /// <param name="param">UCB parameter \alpha</param>
        /// <returns>The card played</returns>
        public override PlayerCard play(PointCard point)
        {
            if (remainingCards.Count() == 1)
                return remainingCards[0];

            //TODO Error when serveral AI : The card played is missing when cloning         
            foreach(Player op in opponent){
                Clone cl = new Clone(op.Color);
                cl.clone(op);
                virtualPlayers.Add(cl);
            }

            int i = 1;
            foreach (UCB d in data)
            {

                d.NbPlayed++;
                d.confidentCalculation(i);
                foreach (Clone vp in virtualPlayers)
                    vp.play(point);
                if (winAgainstClone(point, d.Card))
                    d.Winning += point.Value - d.Card.Value;
                i++;
            }

            for (i = 16; i < 10000; i++)
            {

                foreach(Clone vp in virtualPlayers)
                {
                    vp.play(point);
                }
                UCB currentData = findUpperConfident();
                if (winAgainstClone(point, currentData.Card))
                    currentData.Winning += point.Value - currentData.Card.Value;
                foreach (UCB d in data)
                    d.confidentCalculation(i);
            }


            virtualPlayers.Clear();
            UCB CurrentUCB = findUpperConfident();
            CurrentPlayerCard = CurrentUCB.Card;
            data.Remove(CurrentUCB);
            RemainingCards.Remove(CurrentPlayerCard);
            return CurrentPlayerCard;
        }


        /// <summary>
        /// Test if the current card win against the virtual clone.
        /// </summary>
        /// <param name="card">The current card</param>
        /// <returns></returns>
        private Boolean winAgainstClone(PointCard point, PlayerCard card)
        {

            PlayerCard tmp = CurrentPlayerCard;
            CurrentPlayerCard = card;

            List<Player> virtualList = new List<Player>(virtualPlayers);
            virtualList.Add(this);

            Player winner = turnWinner(virtualList, point);

            CurrentPlayerCard = tmp;

            if (point.Type == CardType.Mouse && winner == this)
                return true;
            if ((point.Type == CardType.Vulture && winner != this))
                return true;

            return false;
        }

        public Player turnWinner(List<Player> players, PointCard point)
        {
            int min = 16, max = 0;
            List<Player> playmin, playmax;
            playmin = new List<Player>();
            playmax = new List<Player>();
            for (int i = 0; i < players.Count(); i++)
            {
                if (players[i].CurrentPlayerCard.Value < min)
                {
                    playmin.Clear();
                    playmin.Add(players[i]);
                    min = players[i].CurrentPlayerCard.Value;
                }
                else if (players[i].CurrentPlayerCard.Value == min)
                {
                    playmin.Add(players[i]);
                }
                if (players[i].CurrentPlayerCard.Value > max)
                {
                    playmax.Clear();
                    playmax.Add(players[i]);
                    max = players[i].CurrentPlayerCard.Value;
                }
                else if (players[i].CurrentPlayerCard.Value == max)
                {
                    playmax.Add(players[i]);
                }
            }

            List<Player> players2 = new List<Player>(players);

            if (point.Type == CardType.Mouse && playmax.Count() > 1)
            {
                foreach (Player player in playmax)
                {
                    players2.Remove(player);
                }
                return turnWinner(players2, point);
            }
            else if (point.Type == CardType.Vulture && playmin.Count() > 1)
            {
                foreach (Player player in playmin)
                {
                    players2.Remove(player);
                }
                return turnWinner(players2, point);
            }
            else if (point.Type == CardType.Mouse && playmax.Count() == 1)
            {
                return playmax[0];
            }
            else if (point.Type == CardType.Vulture && playmin.Count() == 1)
            {
                return playmin[0];
            }
            else
                return null;

        }

        public UCB findUpperConfident()
        {
            UCB tmp = data[0];
            foreach (UCB d in data)
                if (tmp.Confident < d.Confident)
                    tmp = d;
            upperConfident = tmp;
            return tmp;
        }
    }
}
