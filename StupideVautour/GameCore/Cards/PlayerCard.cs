using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StupideVautour.GameCore.Cards
{
    public class PlayerCard
    {
        Color color;
        ushort value;

        public PlayerCard(Color color, ushort value) {
            this.color = color;
            this.value = value;
        }


        Color Color
        {
            set { color = value; }
            get { return color; }
        }

        short Value
        {
            set { this.value = value; }
            get { return value; }
        }
    }
}
