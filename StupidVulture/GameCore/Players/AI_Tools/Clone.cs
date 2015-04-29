using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StupidVulture.GameCore.Cards;

namespace StupidVulture.GameCore.Players.AI_Tools
{
    class Clone : Player
    {

        static Random rand = new Random();

        public Clone(Color color) : base(color)
        {

        }

        /// <summary>
        /// Copy the player for simulation
        /// </summary>
        /// <param name="player">The player to copy</param>
        public void clone(Player player) {
            score = player.Score;
            color = player.Color;
            remainingCards = player.RemainingCards;
            currentPlayerCard = player.CurrentPlayerCard;
        }

        /// <summary>
        /// Random play for the clones
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public override PlayerCard play(PointCard point) {
            int i = rand.Next(remainingCards.Count());
            currentPlayerCard = remainingCards[i];
            return currentPlayerCard;
        }

        public void addPlayedCard(PlayerCard pc)
        {
            RemainingCards.Add(pc);
        }
    }
}
