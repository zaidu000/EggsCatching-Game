namespace EggCatcherGame
{
    public partial class Form1 : Form
    {
        bool goLeft, goRight;

        int speed = 1000;
        int score = 0;
        int missed = 0;

        Random randX = new Random();
        Random randY = new Random();

        PictureBox splash = new PictureBox();
        public Form1()
        {
            InitializeComponent();
            RestartGame();
        }

        private void MainGameTimerEvent(object sender, EventArgs e)
        {

            txtScore.Text = "Saved: " + score;
            txtMiss.Text = "Missed: " + missed;


            if (goLeft==true && player.Left > 0)
            {
                player.Left -= 12;
                player.Image = Properties.Resources.chicken_normal2;
            }

            if (goRight== true && player.Left + player.Width < this.ClientSize.Width)
            {
                player.Left += 12;
                player.Image = Properties.Resources.chicken_normal;
            }
            foreach (Control x in this.Controls)
            {

                if(x is PictureBox && (string)x.Tag == "eggs")
                {

                    x.Top += speed;

                    if(x.Top + x.Height > this.ClientSize.Height)
                    {

                        splash.Image = Properties.Resources.splash;
                        splash.Location = x.Location;
                        splash.Height = 60;
                        splash.Width = 60;
                        splash.BackColor = Color.Transparent;

                        this.Controls.Add(splash);
                        
                        x.Top = randY.Next(80,300) * -1;
                        x.Left = randX.Next(5, ClientSize.Width - x.Width);

                        missed += 1;
                        player.Image = Properties.Resources.chicken_hurt;
                    }

                    if (player.Bounds.IntersectsWith(x.Bounds))
                    {
                        x.Top = randY.Next(80, 300) * -1;
                        x.Left = randX.Next(5, ClientSize.Width - x.Width);
                        score += 1;
                    }



                }


            }

            if (score > 10)
            {
                speed = 12;
                if (score > 20)
                {
                    speed = 15;
                    if (score > 30)
                    {
                        speed = 20;
                    }
                }
            }
            if (missed > score)
            {
                GameTimer.Stop();
                MessageBox.Show(" GameOver ! " + Environment.NewLine + " We have missed more thar Saved Eggs ! \n You Scored "+score + " \n You Missed "+missed+  Environment.NewLine + " Click OK to Retry");
                RestartGame();
            }

        }

        private void keyIsDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode==Keys.Left)
            {
                goLeft = true;

            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = true;

            }

        }

        private void keyIsUp(object sender, KeyEventArgs e)
        {


            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;

            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;

            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void player_Click(object sender, EventArgs e)
        {

        }

        private void RestartGame()
        {


            foreach(Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "eggs")
                {
                    x.Top = randY.Next(80, 300) * -1;
                    x.Left = randX.Next(5, this.ClientSize.Width - x.Width);
                    
                }
            }
            player.Left = this.ClientSize.Width / 2;
            player.Image = Properties.Resources.chicken_normal;

            score = 0;
            missed = 0;
            speed = 8;

            goLeft = false;
            goRight = false;

            GameTimer.Start();
        }
    }
}