using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StupidVulture.GameCore.Cards
{
    public class PointCard
    {
        private CardType type;
        private int value;

        public PointCard(CardType type, int value)
        {
            this.type = type;
            this.value = value;
        }

        public CardType Type
        {
            set { type = value;}
            get { return type; }
        }

        public int Value {
            set { this.value = value; }
            get { return value; }
        }

    }
}
