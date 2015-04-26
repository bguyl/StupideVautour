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
        private List<Player> opponent = new List<Player>();
        private List<Clone> virtualPlayers = new List<Clone>();
        private List<UCB> data = new List<UCB>();



        public AI(Color color, Difficulty difficulty) : base(color)
        {
            this.difficulty = difficulty;
            foreach (PlayerCard card in remainingCards)
            {
                UCB d = new UCB(card, 2);
                data.Add(d);
            }
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
        /// Create numerous virtual game and choose the best card.
        /// </summary>
        /// <param name="param">UCB parameter \alpha</param>
        /// <returns>The card played</returns>
        public PlayerCard play(int param)
        {
            //TODO implement Monte-Carlos & UCB            
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
                PlayerCard card  = UCBPlay();
                if (winAgainstClone(card))
                {
                    UCB.addWin();
                }

                
            }

            return play();
        }


        /// <summary>
        /// Choose a card to test with the UCB algorithm.
        /// </summary>
        /// <returns>The card we want to test</returns>
        private PlayerCard UCBPlay()
        {
            foreach (UCB d in data)
            {
                if (d.Confident < 0)
                    return d.Card;

                d.confidentCalculation();
            }

            UCB current = UCB.findUpperConfident();
            return current.Card;
        }

        /// <summary>
        /// Test if the current card win against the virtual clone.
        /// </summary>
        /// <param name="card">The current card</param>
        /// <returns></returns>
        private Boolean winAgainstClone(PlayerCard card)
        {
            foreach (Clone vp in virtualPlayers)
            {
                vp.play();
            }
            
            

            return false;
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
