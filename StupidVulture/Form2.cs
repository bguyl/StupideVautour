using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StupidVulture.GameCore;
using StupidVulture.GameCore.Players;

namespace StupidVulture
{
    public partial class Game : Form
    {

        Engine engine;
        List<Bitmap> RedCards = new List<Bitmap>();
        List<Bitmap> BlueCards = new List<Bitmap>();
        List<Bitmap> GreenCards = new List<Bitmap>();
        List<Bitmap> YellowCards = new List<Bitmap>();
        List<Bitmap> PurpleCards = new List<Bitmap>();
        List<Bitmap> Mice = new List<Bitmap>();
        List<Bitmap> Vultures = new List<Bitmap>();

        /// <summary>
        /// Public constructor
        /// </summary>
        /// <param name="engine">The game handler</param>
        public Game(Engine engine)
        {

            this.engine = engine;
            InitializeComponent();
            CardsListInitialize(GameCore.Color.Blue, BlueCards);
            CardsListInitialize(GameCore.Color.Red, RedCards);
            CardsListInitialize(GameCore.Color.Green, GreenCards);
            CardsListInitialize(GameCore.Color.Yellow, YellowCards);
            CardsListInitialize(GameCore.Color.Purple, PurpleCards);
            CardsListInitialize();
            DisplayHand();

        }

        /// <summary>
        /// Load all images cards and add them in the list 'Color'Cards
        /// </summary>
        /// <param name="color">The player's color for this list of bitmap</param>
        /// <param name="list">A list of bitmap images name 'Color'Cards</param>
        public void CardsListInitialize(GameCore.Color color, List<Bitmap> list)
        {



            String path = "../../Images/Cards/"+color.ToString()+"/"+color.ToString("g");
            String path2 = "";
            Bitmap b,c;
            for(int i = 1; i <= 15; i++)
            {
                path2 = path + i.ToString() + ".png";
                b = (Bitmap)Image.FromFile(path2);
                c = new Bitmap(b, new Size(82, 119));
                list.Add(c);

            }
        }

        public void CardsListInitialize()
        {
            String path = "../../Images/Cards/Mice/mice";
            String path2;
            Bitmap b;
            for(int i = 1; i <= 10; i++)
            {
                path2 = path + i.ToString() + ".png";
                b = (Bitmap)Image.FromFile(path2);
                Mice.Add(b);
            }

            path = "../../Images/Cards/Vultures/vulture";
            for(int j = 1; j <= 5; j++)
            {
                path2 = path + j.ToString() + ".png";
                b = (Bitmap)Image.FromFile(path2);
                Vultures.Add(b);
            }
        }


        /// <summary>
        /// Display the player's hand with his color
        /// </summary>
        /// <param name="listImg">The list of bitmap with the player's color</param>
        public void DisplayHand(List<Bitmap> listImg)
        {
            int i = 0;
            PictureBox pb = null;
            foreach (Control ctrl in hand.Controls)
            {
                pb = (PictureBox)ctrl;
                pb.Image = listImg[i];
                i++;
            }
            
        }

        /// <summary>
        /// Display the player's hand, whatever is his color
        /// </summary>
        public void DisplayHand()
        {
            Human h;
            h = (Human) engine.Players.Find(player => player is Human);
            if (h != null)
            {
                switch(h.Color)
                {
                    case GameCore.Color.Blue   : DisplayHand(BlueCards);   break;
                    case GameCore.Color.Red    : DisplayHand(RedCards);    break;
                    case GameCore.Color.Yellow : DisplayHand(YellowCards); break;
                    case GameCore.Color.Purple : DisplayHand(PurpleCards); break;
                    case GameCore.Color.Green  : DisplayHand(GreenCards);  break;
                    default: break;

                }
            }


        }


        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



    }
}
