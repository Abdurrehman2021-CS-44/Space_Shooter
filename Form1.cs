using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EZInput;

namespace spaceShooter2D
{
    public partial class frmSpaceShooter : Form
    {
        PictureBox player;
        PictureBox enemy;
        List<PictureBox> playerFire = new List<PictureBox>();
        Random rand;
        string movementCall = "Left";

        public frmSpaceShooter()
        {
            InitializeComponent();
        }

        private void frmSpaceShooter_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = spaceShooter2D.Properties.Resources.mario_campello_fundo_espaco;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            startGame();
        }
        
        private void startGame()
        {
            createPlayer();
            createEnemy();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Keyboard.IsKeyPressed(Key.LeftArrow))
            {
                player.Left -= 10;
            }
            if (Keyboard.IsKeyPressed(Key.RightArrow))
            {
                player.Left += 10;
            }
            if (movementCall == "Left")
            {
                enemy.Left -= 10;
            }
            if (movementCall == "Right")
            {
                enemy.Left += 10;
            }
            if ((enemy.Left + enemy.Width) > this.Width)
            {
                movementCall = "Left";
            }
            if (enemy.Left < 0)
            {
                movementCall = "Right";
            }
            if (Keyboard.IsKeyPressed(Key.Space))
            {
                GenetrateFire();
            }
            foreach (PictureBox fire in playerFire)
            {
                fire.Top -= 25;
            }
            for (int i = 0; i < playerFire.Count; i++)
            {
                if (playerFire[i].Bottom < 0)
                {
                    playerFire.RemoveAt(i);
                }
            }
        }

        private void createPlayer()
        {
            player = new PictureBox();
            Image img = spaceShooter2D.Properties.Resources.playerShip2_blue;
            player.Image = img;
            player.Width = img.Width;
            player.Height = img.Height;
            player.BackColor = Color.Transparent;
            player.Top = this.Height - (img.Height + 100);
            player.Left = this.Width / 2;
            this.Controls.Add(player);
        }

        private void createEnemy()
        {
            rand = new Random();
            enemy = new PictureBox();
            Image img = spaceShooter2D.Properties.Resources.playerShip1_orange;
            enemy.Image = img;
            enemy.Width = img.Width;
            enemy.Height = img.Height;
            enemy.BackColor = Color.Transparent;
            enemy.Top = 50;
            enemy.Left = rand.Next(0, this.Width);
            this.Controls.Add(enemy);
        }

        private void GenetrateFire()
        {
            PictureBox fire = new PictureBox();
            Image img = spaceShooter2D.Properties.Resources.laserBlue16;
            fire.Image = img;
            fire.Width = img.Width;
            fire.Height = img.Height;
            fire.BackColor = Color.Transparent;
            fire.Top = player.Top - 55;
            fire.Left = player.Left + 49;
            playerFire.Add(fire);
            this.Controls.Add(fire);
        }
    }
}
