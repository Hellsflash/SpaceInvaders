using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceInvaders
{
    public partial class SpaceInvaders : Form
    {
        bool goLeft;
        bool goRight;
        int speed = 5;
        int Score = 0;
        bool isPressed;
        int totalEnemies = 12;
        int playerSpeed = 6;


        public SpaceInvaders()
        {
            InitializeComponent();
        }    
        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = true;
            }
            if (e.KeyCode ==Keys.Right)
            {
                goRight = true;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Left)
            {
                goLeft = false;
            }
            if (e.KeyCode ==Keys.Right)
            {
                goRight = false;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (goLeft)
            {
                Tank.Left -= playerSpeed;
            }
            else if (goRight)
            {
                Tank.Left += playerSpeed;
            }
        }

    }
}
