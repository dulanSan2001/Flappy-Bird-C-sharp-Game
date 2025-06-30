using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy_Bird_Windows_Form
{
    public partial class Form1 : Form
    {

        int pipeSpeed = 7;
        int gravity = 14;
        int score = 0;





        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ground_Click(object sender, EventArgs e)
        {

        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            flappyBird.Top += gravity;
            pipeTop.Left -= pipeSpeed;
            pipeBottom.Left -= pipeSpeed;
            scoreText.Text = "score: " + score;

            if (pipeBottom.Left<-150)
            {
                pipeBottom.Left = 700;
                score++;
            }

            if (pipeTop.Left < -180)
            {
                pipeTop.Left = 850;
                score++;
            }

            if (flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) ||
                flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                flappyBird.Bounds.IntersectsWith(ground.Bounds) || 
                (flappyBird.Top < -25))
            {
                endGame();
            }
  
            if (score > 8)
            {
                pipeSpeed = 15;
            }

            if (score > 20)
            {
                pipeSpeed = 25;
            }

          
            

        }

        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Space)
            {
                gravity = -15;
            }
        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 15;
            }
        }

        private void endGame()
        { 
          gameTimer.Stop();
            scoreText.Text += "Game Over!!!";
        
        }









    }
}
