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
using StupidVulture.GameCore.Cards;

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
        Bitmap CardsBack;

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
            CardsBackInitialize();
            DisplayHand();
            

        }

        /// <summary>
        /// Load all images cards and add them in the list 'Color'Cards
        /// </summary>
        /// <param name="color">The player's color for this list of bitmap</param>
        /// <param name="list">A list of bitmap images name 'Color'Cards</param>
        public void CardsListInitialize(GameCore.Color color, List<Bitmap> list)
        {



            String path = "../../Images/Cards/" + color.ToString() + "/" + color.ToString("g");
            String path2 = "";
            Bitmap b, c;
            for (int i = 1; i <= 15; i++)
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
            for (int i = 1; i <= 10; i++)
            {
                path2 = path + i.ToString() + ".png";
                b = (Bitmap)Image.FromFile(path2);
                Mice.Add(b);
            }

            path = "../../Images/Cards/Vultures/vulture";
            for (int j = 1; j <= 5; j++)
            {
                path2 = path + j.ToString() + ".png";
                b = (Bitmap)Image.FromFile(path2);
                Vultures.Add(b);
            }

          
        }

        public void CardsBackInitialize()
        {
            String path = "../../Images/Cards/CardsBack.png";
            Bitmap b = (Bitmap)Image.FromFile(path);
            CardsBack = b;
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
            h = (Human)engine.Players.Find(player => player is Human);
            if (h != null)
            {
                switch (h.Color)
                {
                    case GameCore.Color.Blue: DisplayHand(BlueCards); break;
                    case GameCore.Color.Red: DisplayHand(RedCards); break;
                    case GameCore.Color.Yellow: DisplayHand(YellowCards); break;
                    case GameCore.Color.Purple: DisplayHand(PurpleCards); break;
                    case GameCore.Color.Green: DisplayHand(GreenCards); break;
                    default: break;

                }
            }


        }


        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void showCurrentCard(PointCard currentCard)
        {
            CardType type = currentCard.Type;
            int num = currentCard.Value;
            if (type == CardType.Mouse)
                stack.Image = Mice[num-1];
            else
                stack.Image = Vultures[0-num-1];
        }

        private void showBackCards()
        {
            int i = engine.amountPlayers;
            for(int j = 0; j < i; j++)
            {
                PictureBox pb = (PictureBox)playersCards.Controls[j];
                pb.Image = CardsBack;
            }
        }

        private void showCards()
        {
            int i = engine.amountPlayers;
            for(int j = 0;j < i; j++)
            {
                PictureBox pb = (PictureBox)playersCards.Controls[j];
                GameCore.Color color = engine.Players[j].Color;
                int num = engine.Players[j].CurrentPlayerCard.Value;
                Bitmap image = null; 
                switch (color)
                {
                    case GameCore.Color.Blue :
                        image = BlueCards[num - 1];
                        break;
                    case GameCore.Color.Red :
                        image = RedCards[num - 1];
                        break;
                    case GameCore.Color.Green :
                        image = GreenCards[num - 1];
                        break;
                    case GameCore.Color.Yellow :
                        image = YellowCards[num - 1];
                        break;
                    case GameCore.Color.Purple :
                        image = PurpleCards[num - 1];
                        break;
                    default :
                        break;
                }

                pb.Image = new Bitmap(image, new Size(164, 238));
            }
        }

        private void showWinner(Player winner)
        {
            if(winner == null)
            {
                MessageBox.Show("Personne ne remporte cette carte.");
                return;
            }
            string color = winner.Color.ToString();
            if(winner is Human)
            {
                MessageBox.Show("Vous remportez cette carte.");

            }
            else
            {
                MessageBox.Show("Le joueur " + color + " remporte cette carte.");
            }
        }
        public void gameLoop()
        {
            while(!engine.endingTest())
            {
                PointCard currentCard = engine.DrawCard();
                showCurrentCard(currentCard);
                showBackCards();
                Player winner = engine.play();
                showCards();
                showWinner(winner);
                
            }
        }

        private void handUpdate(int index)
        {
            PictureBox pb = (PictureBox)hand.Controls[index];
            pb.Image = null;
            hand.Controls[index].Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            gameLoop();
        }

        private void cX_Click(object sender, EventArgs e)
        {
            Human h = (Human)engine.Players.Find(player => player is Human);
            PictureBox pb = (PictureBox)sender;
            int index=-1;
            int j = 0;
            PictureBox pbTest;
            foreach(Control ctrl in hand.Controls)
            {
                pbTest = (PictureBox)ctrl;
                if(pbTest.Image == pb.Image)
                {
                    index = j;
                }
                j++;
            }
            h.Played = true;
            h.play(index);
            handUpdate(index);
            }

        }

    }
