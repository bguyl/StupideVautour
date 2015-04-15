﻿using System;
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
using StupidVulture.Properties;


namespace StupidVulture
{
    public partial class Menu : Form
    {


        Bitmap _human = Resources.Human;
        Bitmap _easy = Resources.Easy;
        Bitmap _medium = Resources.Medium;
        Bitmap _hard = Resources.Hard;
        Bitmap _none = Resources.None;

        public Menu()
        {
            InitializeComponent();
        }

        private void LaunchButton_Click(object sender, EventArgs e)
        {

            List<Player> players = new List<Player>();
            PictureBox[] pictures = { joueur1, joueur2, joueur3, joueur4, joueur5 };
            
            foreach (PictureBox picture in pictures)
            {
                if(picture.Image == _human)
                {
                    Human h = new Human(GameCore.Color.Red);
                    players.Add(h);
                }
                else if (picture.Image == _easy)
                {
                        AI easy = new AI(GameCore.Color.Blue);
                        players.Add(easy);
                }
                else if (picture.Image == _medium)
                {
                       AI medium = new AI(GameCore.Color.Green);
                       players.Add(medium);
                }
                else if (picture.Image == _hard)
                {
                       AI hard = new AI(GameCore.Color.Purple);
                       players.Add(hard);
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
            
            joueur1.Image = _human;
            joueur2.Image = _easy;
            joueur3.Image = _none;
            joueur4.Image = _none;
            joueur5.Image = _none;

        }

        private void joueurX_Click(object sender, EventArgs e)
        {
            


            PictureBox picture = (PictureBox)sender;
            if (picture.Image == _human)
                picture.Image = _easy;
            else if (picture.Image == _easy)
                picture.Image = _medium;
            else if (picture.Image == _medium)
                picture.Image = _hard;
            else if (picture.Image == _hard && picture == joueur1)
                picture.Image = _human;
            else if (picture.Image == _hard && picture == joueur2)
                picture.Image = _easy;
            else if (picture.Image == _hard)
                picture.Image = _none;
            else if (picture.Image == _none)
                picture.Image = _easy;

            picture.Invalidate();
            picture.Update();
           
           

        }

    }     
}
