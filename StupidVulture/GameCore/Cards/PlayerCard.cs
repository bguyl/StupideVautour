using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StupidVulture.GameCore.Cards
{
    public class PlayerCard
    {
        Color color;
        ushort value;
        Boolean faceDown;

        public PlayerCard(Color color, ushort value) {
            this.color = color;
            this.value = value;
        }


        public Color Color
        {
            set { color = value; }
            get { return color; }
        }

        public ushort Value
        {
            set { this.value = value; }
            get { return value; }
        }

        public void TurnOver()
        {
            faceDown = !faceDown;
        }
    }
}
