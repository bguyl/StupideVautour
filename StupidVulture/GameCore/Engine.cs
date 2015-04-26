using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StupidVulture.GameCore.Players;
using StupidVulture.GameCore.Cards;

namespace StupidVulture.GameCore
{
    public class Engine
    {

        private List<Player> players;
        private int nbPlayers;
        private List<PointCard> stack;
        private PointCard currentCard = null;
        private const int nbMice = 10;
        private const int nbVultures = 5;
        

        public List<PointCard> Stack
        {
            get { return stack; }
            
        }
        


        public Engine(List<Player> players)
        {
            this.players = players;
            nbPlayers = this.players.Count();
            this.stack = new List<PointCard>();
            initializeCards();
        }

        public List<Player> Players
        {
            get { return players; }
        }
        
        public int amountPlayers
        {
            get { return nbPlayers; }
            set { nbPlayers = value; }
        }
        
        public void shuffleCards()
        {
            Random rand = new Random();
            for(int i = stack.Count()-1; i >= 0;i--)
            {
                int k = rand.Next(i+1);
                PointCard temp = stack[k];
                stack[k] = stack[i];
                stack[i] = temp;
            }

        }
        public void initializeCards()
        {
            for(int i = 1;i <= nbMice;i++)
            {
               stack.Add(new PointCard(CardType.Mouse,i));
            }
            for(int j = -1; j >= (0-nbVultures); j--)
            {
                stack.Add(new PointCard(CardType.Vulture, j));
            }
            shuffleCards();
        }

        public void initializePlayers()
        {

        }

        public Boolean endingTest()
        {
            if (stack.Count() == 0)
                return true;
            else
                return false;
        }

        public PointCard DrawCard()
        {
            currentCard = stack[0];
            stack.Remove(currentCard);
            return currentCard;
        }

        public void showCards()
        {
            for(int i = 0; i < nbPlayers; i++)
            {
                try
                {
                    players[i].CurrentPlayerCard.TurnOver();
                       
                } catch (ArgumentNullException e)
                {
                    Console.WriteLine("Player " + (i + 1) + " doesn't have a card ! : "+e);
                }
            }

        }

        public Player play()
        {
            
            for(int i = 0;i < nbPlayers; i++)
            {
                players[i].play(currentCard);
            }
            Player winner = turnWinner(players);
            if(winner != null)
                incrementWinnerScore(winner);
            return winner;
        }

        public void incrementWinnerScore(Player winner)
        {
            winner.Score += currentCard.Value;
        }


        public Player turnWinner(List<Player> players)
        {
            int min = 16, max = 0;
            List<Player> playmin, playmax;
            playmin = new List<Player>();
            playmax = new List<Player>();
            for(int i=0; i < players.Count();i++)
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
                else if(players[i].CurrentPlayerCard.Value == max)
                {
                    playmax.Add(players[i]);
                }


            }

            List<Player> players2 = new List<Player>(players);

            if (currentCard.Type == CardType.Mouse && playmax.Count() > 1)
            {
                foreach (Player player in playmax)
                {
                    players2.Remove(player);
                }
                return turnWinner(players2);
            }
            else if (currentCard.Type == CardType.Vulture && playmin.Count() > 1)
            {
                foreach (Player player in playmin)
                {
                    players2.Remove(player);
                }
                return turnWinner(players2);
            }
            else if (currentCard.Type == CardType.Mouse && playmax.Count() == 1)
            {
                return playmax[0];
            }
            else if (currentCard.Type == CardType.Vulture && playmin.Count() == 1)
            {
                return playmin[0];
            }
            else
                return null;

        }

        public List<Player> getWinner()
        {
            int max = -1;
            List<Player> winners = new List<Player>();
            foreach(Player player in players)
            {
                if(player.Score > max)
                {
                    winners.Clear();
                    winners.Add(player);
                    max = player.Score;
                }
                else if(player.Score == max)
                {
                    winners.Add(player);
                }
            }

            return winners;
        }




    }
}
