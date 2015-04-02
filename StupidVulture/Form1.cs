using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StupidVulture.GameCore.Players;
using StupidVulture.GameCore;


namespace StupidVulture
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void LaunchButton_Click(object sender, EventArgs e)
        {
            
            List<Player> players = new List<Player>();
            PictureBox[] pictures = {joueur1,joueur2,joueur3,joueur4,joueur5};

            foreach(PictureBox picture in pictures)
            {
                switch(picture.ImageLocation)
                {
                    case "../../Images/Human.png" :
                        Human h = new Human(GameCore.Color.Red);
                        players.Add(h);
                        break;
                    case "../../Images/Easy.png" :
                        AI easy = new AI(GameCore.Color.Blue);
                        players.Add(easy);
                        break;
                    case "../../Images/Medium.png" :
                        AI medium = new AI(GameCore.Color.Green);
                        players.Add(medium);
                        break;
                    case "../../Images/Hard.png" :
                        AI hard = new AI(GameCore.Color.Purple);
                        players.Add(hard);
                        break;
                    default :
                        break;
                }

            }
            
            Engine engine = new Engine(players);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            joueur1.Load("../../Images/Human.png");
            joueur2.Load("../../Images/Easy.png");
            joueur3.Load("../../Images/None.png");
            joueur4.Load("../../Images/None.png");
            joueur5.Load("../../Images/None.png");
        }

        private void joueur1_Click(object sender, EventArgs e)
        {
            String s = joueur1.ImageLocation;
            String result ="";
            switch (s)
            {
                case "../../Images/Human.png" :
                    result = result + "Easy.png";
                    break;
                case "../../Images/Easy.png":
                    result = result + "Medium.png";
                    break;
                case "../../Images/Medium.png":
                    result = result + "Hard.png";
                    break;
                case "../../Images/Hard.png":
                    result = result + "Human.png";
                    break;
                default :
                    result = result + "Human.png";
                    break;
            }
            result = "../../Images/" + result;
            joueur1.Load(result);
        }

        private void joueur2_Click(object sender, EventArgs e)
        {
            String s = joueur2.ImageLocation;
            String result = "";
            switch (s)
            {
                case "../../Images/Easy.png":
                    result = result + "Medium.png";
                    break;
                case "../../Images/Medium.png":
                    result = result + "Hard.png";
                    break;
                case "../../Images/Hard.png":
                    result = result + "Easy.png";
                    break;
                default:
                    result = result + "Easy.png";
                    break;
            }
            result = "../../Images/" + result;
            joueur2.Load(result);
        }

        private void joueur3_Click(object sender, EventArgs e)
        {
            String s = joueur3.ImageLocation;
            String result = "";
            switch (s)
            {
                case "../../Images/None.png":
                    result = result + "Easy.png";
                    break;
                case "../../Images/Easy.png":
                    result = result + "Medium.png";
                    break;
                case "../../Images/Medium.png":
                    result = result + "Hard.png";
                    break;
                case "../../Images/Hard.png":
                    result = result + "None.png";
                    break;
                default:
                    result = result + "None.png";
                    break;
            }
            result = "../../Images/" + result;
            joueur3.Load(result);
        }

        private void joueur4_Click(object sender, EventArgs e)
        {
            String s = joueur4.ImageLocation;
            String result = "";
            switch (s)
            {
                case "../../Images/None.png":
                    result = result + "Easy.png";
                    break;
                case "../../Images/Easy.png":
                    result = result + "Medium.png";
                    break;
                case "../../Images/Medium.png":
                    result = result + "Hard.png";
                    break;
                case "../../Images/Hard.png":
                    result = result + "None.png";
                    break;
                default:
                    result = result + "None.png";
                    break;
            }
            result = "../../Images/" + result;
            joueur4.Load(result);
        }

        private void joueur5_Click(object sender, EventArgs e)
        {
            String s = joueur5.ImageLocation;
            String result = "";
            switch (s)
            {
                case "../../Images/None.png":
                    result = result + "Easy.png";
                    break;
                case "../../Images/Easy.png":
                    result = result + "Medium.png";
                    break;
                case "../../Images/Medium.png":
                    result = result + "Hard.png";
                    break;
                case "../../Images/Hard.png":
                    result = result + "None.png";
                    break;
                default:
                    result = result + "None.png";
                    break;
            }
            result = "../../Images/" + result;
            joueur5.Load(result);
        }

    }
}
