using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StupideVautour.GameCore.Cards
{
    public class PointCard
    {
        CardType type;
        short value;

        PointCard(CardType type, short value)
        {
            this.type = type;
            this.value = value;
        }

        CardType Type
        {
            set { type = value;}
            get { return type; }
        }

        short Value {
            set { this.value = value; }
            get { return value; }
        }

    }
}
