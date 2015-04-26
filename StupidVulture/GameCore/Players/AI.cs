using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StupidVulture.GameCore.Cards;
using StupidVulture.GameCore.Players.AI_Tools;

namespace StupidVulture.GameCore.Players
{
    public enum Difficulty {EASY, MEDIUM, HARD, RANDOM};

    public class AI : Player
    {
        private Difficulty difficulty;
        public List<Player> opponent;

        public AI(Color color, Difficulty difficulty) : base(color)
        {
            this.difficulty = difficulty;
        }

        public override PlayerCard play()
        {
            switch (difficulty)
            {
                case Difficulty.EASY : return play(0);
                case Difficulty.MEDIUM : return play(1);
                case Difficulty.HARD : return play(2);
                default : return playRandom();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param">UCB parameter \alpha</param>
        /// <returns>The card played</returns>
        public PlayerCard play(int param)
        {
            //TODO implement Monte-Carlos & UCB
            List<Clone> virtualPlayers = new List<Clone>();
            foreach(Player op in opponent){
                Clone cl = new Clone(op.Color);
                cl.clone(op);
                virtualPlayers.Add(cl);
            }


            for (int i = 0; i < 1000000; i++)
            {
                for (int j = 0; j < opponent.Count; j++ )
                {
                    virtualPlayers[j].clone(opponent[j]);
                    virtualPlayers[j].play();
                }
                UCBPlay();

            }
            return null;
        }

        public PlayerCard UCBPlay()
        {
            return null;
        }

        /// <summary>
        /// Play randomly in his hand. For testing only
        /// </summary>
        /// <returns>The card played</returns>
        public PlayerCard playRandom()
        {
            Random rand = new Random();
            int i = rand.Next(remainingCards.Count()-1);
            currentPlayerCard = remainingCards[i];
            remainingCards.Remove(currentPlayerCard);
            return currentPlayerCard;
        }
    }
}
