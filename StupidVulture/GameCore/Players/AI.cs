using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StupidVulture.GameCore.Players
{
    public enum Difficulty {EASY, MEDIUM, HARD};

    public class AI : Player
    {
        private Difficulty difficulty;

        public AI(Color color/*, Difficulty difficulty*/) : base(color)
        {
            //this.difficulty = difficulty;
        }
    }
}
