using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StupidVulture.GameCore.Cards;
using StupidVulture.GameCore.Players.AI_Tools;

namespace StupidVulture.GameCore.Players
{
    public enum Difficulty { EASY, MEDIUM, HARD, RANDOM };

    public class AI : Player
    {
        private Difficulty difficulty;
        private List<Player> opponent = new List<Player>();
        private List<Clone> virtualPlayers = new List<Clone>();
        private List<UCB> data = new List<UCB>();
        private UCB upperConfident;
        private List<PointCard> playedMiceVultures = new List<PointCard>();
        public AI(Color color, Difficulty difficulty)
            : base(color)
        {
            this.difficulty = difficulty;
        }

        public List<Player> Opponent
        {
            get { return opponent; }
            set { opponent = value; }
        }

        public PlayerCard playEasy(PointCard point)
        {
            playedMiceVultures.Add(point);
            int[] value = { 1, -1, 2, 3, -2, 4, 5, -3, 6, 7, -4, 8, 9, -5, 10 };
            int[] cards = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            List<PlayerCard> playableCards = new List<PlayerCard>();
            int j = 0;
            int i = 2;
            int index = -1;
            for (int z = 0; z < 15;z++ )
            {
                if (value[z] == point.Value)
                {
                    index = z;
                    z = 15;
                }
            }
                while (j <= 0)
                {
                    for (int k = index - i; k <= index + i; k++)
                    {
                        if (k >= 0 && k < 15)
                        {
                            PlayerCard playerCard = remainingCards.Find(card => card.Value == cards[k]);
                            if (playerCard != null)
                            {
                                j++;
                                playableCards.Add(playerCard);
                            }
                        }

                    }
                    i++;
                }
            int r = Program.rand.Next(playableCards.Count);
            currentPlayerCard = playableCards[r];
            remainingCards.Remove(playableCards[r]);
            return playableCards[r];
        }

        public PlayerCard playMedium(PointCard point)
        {
            
            int[] value = { 1, -1, 2, 3, -2, 4, 5, -3, 6, 7, -4, 8, 9, -5, 10 };
            int[] cards = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            List<PlayerCard> playableCards = new List<PlayerCard>();
            int j = 0;
            int i = 2;
            int index = -1;
            for (int z = 0; z < 15; z++)
            {
                if (value[z] == point.Value)
                {
                    index = z;
                    z = 15;
                }
            }
            while (j <= 0)
            {
                for (int k = index - i; k <= index + i; k++)
                {
                    if (k >= 0 && k < 15)
                    {
                        PlayerCard playerCard = remainingCards.Find(card => card.Value == cards[k]);
                        if (playerCard != null)
                        {
                            j++;
                            playableCards.Add(playerCard);
                        }
                    }

                }
                i++;
            }

            int moyenne;
            if (playedMiceVultures.Count > 0)
            {
                int somme = 0;
                for (int l = 0; l < playedMiceVultures.Count; l++)
                {
                    if (playedMiceVultures[l].Type == CardType.Mouse)
                        somme += playedMiceVultures[l].Value;
                    else
                        somme += (-2) * playedMiceVultures[l].Value;
                }
                moyenne = somme / playedMiceVultures.Count;
            }
            else
                moyenne = 0;
            int r;
            if(moyenne > point.Value && playableCards.Count >= 2)
            {
                r = Program.rand.Next(playableCards.Count / 2, playableCards.Count);
            }
            else if(moyenne < point.Value && playableCards.Count >=2)
            {
                r = Program.rand.Next(0, playableCards.Count / 2 + 1);
            }
            else
            {
                r = Program.rand.Next(playableCards.Count);
            }

            currentPlayerCard = playableCards[r];
            remainingCards.Remove(playableCards[r]);
            return playableCards[r];
            playedMiceVultures.Add(point);
        }
        /// <summary>
        /// Create numerous virtual game and choose the best card.
        /// </summary>
        /// <param name="param">UCB parameter \alpha</param>
        /// <returns>The card played</returns>
        public override PlayerCard play(PointCard point)
        {
            if (difficulty == Difficulty.EASY)
                return playEasy(point);
            if (difficulty == Difficulty.MEDIUM)
                return playMedium(point);
 
            if (remainingCards.Count() == 1)
                return remainingCards[0];

                        foreach (PlayerCard card in remainingCards)
            {
                UCB d = new UCB(card, 2);
                data.Add(d);
            }

            //TODO Error when serveral AI : The card played is missing when cloning         
            foreach(Player op in opponent){
                Clone cl = new Clone(op.Color);
                cl.clone(op);
                virtualPlayers.Add(cl);
            }

            data.Reverse();

            int i = 1, foo = 10;
            foreach (UCB d in data)
            {
                foreach (Clone vp in virtualPlayers)
                    vp.play(point);
                d.NbPlayed++;
                d.Winning = d.Winning - d.Card.Value;
                if (winAgainstClone(point, d.Card))
                    d.Winning = d.Winning + point.Value + foo;
                d.confidentCalculation(i);
                i++;

            }

            for (i = 16; i < 10000; i++)
            {
                foreach(Clone vp in virtualPlayers)
                {
                    vp.play(point);
                }
                UCB currentData = findUpperConfident();
                currentData.NbPlayed++;
                currentData.Winning = currentData.Winning - currentData.Card.Value;
                if (winAgainstClone(point, currentData.Card))
                    currentData.Winning = currentData.Winning + point.Value + foo;
                foreach (UCB d in data)
                    d.confidentCalculation(i);
            }

            /*for (int i = 0; i < 100000; i++) { 
                foreach (UCB d in data)
                {
                    d.NbPlayed++;
                    foreach (Clone vp in virtualPlayers)
                        vp.play(point);
                    d.Winning = d.Winning - d.Card.Value;
                    if (winAgainstClone(point, d.Card))
                        d.Winning = d.Winning + point.Value;
                    d.averageCalculation();
                }
            }*/

            foreach (UCB d in data)
            {
                Console.WriteLine("Carte " + d.Card.Value + " - Confiance: " + d.Confident+" / Average: "+d.Average+" / NbPlayer :"+d.NbPlayed+" / Winning: "+d.Winning);
            }
            
            Console.WriteLine("===================================================================================================================");
            virtualPlayers.Clear();
            UCB CurrentUCB = findUpperConfident();
            //UCB CurrentUCB = findUpperAverage();
            CurrentPlayerCard = CurrentUCB.Card;
            data.Clear();
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

        public UCB findUpperAverage()
        {
            UCB tmp = data[0];
            foreach (UCB d in data)
                if (tmp.Average < d.Average)
                    tmp = d;
            upperConfident = tmp;
            return tmp;
        }
    }
}
