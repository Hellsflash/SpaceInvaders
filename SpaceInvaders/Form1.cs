﻿using System;
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
            if (e.KeyCode == Keys.Right)
            {
                goRight = true;
            }
            if (e.KeyCode == Keys.Space && !isPressed)
            {
                isPressed = true;
                MakeBullet();
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
            if (isPressed)
            {
                isPressed = false;
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
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Tag == "invader")
                {
                    if (((PictureBox)x).Bounds.IntersectsWith(Tank.Bounds))
                    {
                        GameOver();
                    }
                     ((PictureBox)x).Left += speed;

                    if (((PictureBox)x).Left > 720)
                    {
                        ((PictureBox)x).Top += ((PictureBox)x).Height + 10;

                        ((PictureBox)x).Left = -50;
                    }
                }
            }
            foreach (Control y in this.Controls)
            {
                if (y is PictureBox && y.Tag == "bullet")
                {
                    y.Top -= 20;

                    if (((PictureBox)y).Top < this.Height - 490)
                    {
                        this.Controls.Remove(y); 
                    }
                }
            }

        }
        private void MakeBullet()
        {
            PictureBox bullet = new PictureBox();

            bullet.Image = Properties.Resources.bullet1;

            bullet.Size = new Size(5, 20);

            bullet.Tag = "bullet";

            bullet.Left = Tank.Left + Tank.Width / 2;

            bullet.Top = Tank.Top - 20;

            this.Controls.Add(bullet);

            bullet.BringToFront();
        }
        private void GameOver()
        {
            timer2.Stop();
            label1.Text += " Game Over";
        }
    }
}
