using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StupidVulture.GameCore.Players.AI_Tools
{
    class Clone : Player
    {
        public Clone(Color color) : base(color)
        {

        }

        /// <summary>
        /// Copy the player for simulation
        /// </summary>
        /// <param name="player">The player to copy</param>
        public void clone(Player player)
        {
            score = player.Score;
            color = player.Color;
            remainingCards = player.RemainingCards;
            wonCards = player.WonCards;
            currentPlayerCard = player.CurrentPlayerCard;
        }


    }
}
