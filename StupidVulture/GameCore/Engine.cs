using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StupidVulture.GameCore.Players;
using StupidVulture.GameCore.Cards;

namespace StupidVulture.GameCore
{
    class Engine
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
        }

        public List<Player> Players
        {
            get { return players; }
        }
        
        public int AmountPlayers
        {
            get { return nbPlayers; }
            set { nbPlayers = value; }
        }
        
        public void ShuffleCards()
        {
            Random rand = new Random();
            for(int i = stack.Count(); i > 1;i--)
            {
                int k = rand.Next(i + 1);
                PointCard temp = stack[k];
                stack[k] = stack[i];
                stack[i] = temp;
            }

        }
        public void InitializeCards()
        {
            for(int i = 1;i <= nbMice;i++)
            {
               stack.Add(new PointCard(CardType.Mouse,i));
            }
            for(int j = -1; j >= nbVultures; j--)
            {
                stack.Add(new PointCard(CardType.Vulture, j));
            }
            ShuffleCards();
        }

        public void InitializePlayers()
        {

        }

        public Boolean EndingTest()
        {
            if (stack.Count() == 0)
                return true;
            else
                return false;
        }

        public void DrawCard()
        {
            currentCard = stack[0];
            stack.Remove(currentCard);
        }

        public void ShowCards()
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

        public void Play()
        {
            for(int i = 0;i < nbPlayers; i++)
            {
                players[i].Play();
            }
            Player winner = TurnWinner();
        }

        public Player TurnWinner()
        {
            int min = 16, max = 0;
            Player playMin = null,playMax = null;
            for(int i=0; i < nbPlayers;i++)
            {
                if (players[i].CurrentPlayerCard.Value < min)
                {
                    playMin = players[i];
                    min = players[i].CurrentPlayerCard.Value;
                }
                else if (players[i].CurrentPlayerCard.Value > max)
                {
                    playMax = players[i];  
                    max = players[i].CurrentPlayerCard.Value;
                }

            }
            if (currentCard.Type == CardType.Mouse)
                return playMax;
            else
                return playMin;
        }



    }
}
