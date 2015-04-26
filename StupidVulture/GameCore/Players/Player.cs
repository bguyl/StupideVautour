using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StupidVulture.GameCore.Cards;

namespace StupidVulture.GameCore.Players
{
    public class Player
    {
        protected int score;
        protected Color color;
        protected List<PlayerCard> remainingCards;
        protected List<PointCard> wonCards;
        protected PlayerCard currentPlayerCard;
        private const int amountCard = 15;

        public Player(Color playerColor)
        {
            Color = playerColor;
            Score = 0;
            wonCards = new List<PointCard>();
            remainingCards = new List<PlayerCard>();
            for(ushort i=1;i<=amountCard;i++)
            {
                remainingCards.Add(new PlayerCard(Color, i));
            }
        }

        

        public int Score
        {
            get { return this.score; }
            set { this.score = value; }
        }

        public Color Color 
        {
            get { return color; }
            set { color = value; }
        }

        public List<PlayerCard> RemainingCards
        {
            get { return remainingCards; }
           
        }

        public List<PointCard> WonCards
        {
            get { return wonCards; }
        }
        
        public PlayerCard CurrentPlayerCard
        {
            get { return currentPlayerCard; }
            set { currentPlayerCard = value; }
        }

        public virtual PlayerCard play()
        {
            currentPlayerCard = remainingCards.Last();
            remainingCards.Remove(currentPlayerCard);
            return currentPlayerCard;
        }
        
        public PlayerCard playRandom()
        {
            Random rand = new Random();
            int i = rand.Next(remainingCards.Count() - 1);
            currentPlayerCard = remainingCards[i];
            remainingCards.Remove(currentPlayerCard);
            return currentPlayerCard;
        }
        
    }
   
}
