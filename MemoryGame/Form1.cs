using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;

namespace MemoryGame
{
    public partial class Form1 : Form
    {
        static List<Bitmap> list1 = new List<Bitmap>();

        public Form1()
        {
            InitializeComponent();
        }

        public List<Player> players = new List<Player>();

        int index ;
        int openedBoxes;
        int moves;
        double seconds ;
        List<Bitmap> list2;
        PictureBox pB;
        Stopwatch stopwatch;

        //for logger
        Player player ;
        TextBox t1 = new TextBox();
        Form form = new Form();
        string officialName;

        //shuffles the list of images
        public static List<Bitmap> Scrambler(List<Bitmap> list)
        {
            int length = list.Count - 1;
            var rand = new Random();
            List<Bitmap> newList = new List<Bitmap>();

            for (int i = length; i >= 0; i--)
            {
                int a = rand.Next(i);
                newList.Add(list[a]);
                list.Remove(list[a]);
            }

            return newList;
        }

        //locks or unlocks the pictureboxes so you cant randomly click them
        public void LockUnlockPictureBoxes(bool locked)
        {
            pictureBox0.Enabled = locked;
            pictureBox1.Enabled = locked;
            pictureBox2.Enabled = locked;
            pictureBox3.Enabled = locked;
            pictureBox4.Enabled = locked;
            pictureBox5.Enabled = locked;
            pictureBox6.Enabled = locked;
            pictureBox7.Enabled = locked;
            pictureBox8.Enabled = locked;
            pictureBox9.Enabled = locked;
            pictureBox10.Enabled = locked;
            pictureBox11.Enabled = locked;
            pictureBox12.Enabled = locked;
            pictureBox13.Enabled = locked;
            pictureBox14.Enabled = locked;
            pictureBox15.Enabled = locked;
            pictureBox16.Enabled = locked;
            pictureBox17.Enabled = locked;
        }

        //for logger
        public void b1_Click(object sender, EventArgs e)
        {
            if (t1.Text.Length > 0)
            {
                player = new Player();
                officialName = t1.Text;
                form.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StartForm();
        }

        public void StartForm()
        {
            //for logger

            ///
            index = 0;
            openedBoxes = 0;
            moves = 0;
            seconds = 0;
            stopwatch = new Stopwatch();
            FormLeaderboard leaderboardForm = new FormLeaderboard();
            ///

            t1.Top = 100;
            t1.Left = 80;

            Button b1 = new Button();
            b1.Top = 160;
            b1.Left = 95;
            b1.Text = "Start!";

            Label l1 = new Label();
            l1.Top = 75;
            l1.Left = 89;
            l1.Text = "Enter nickname";

            form.Controls.Add(t1);
            form.Controls.Add(b1);
            form.Controls.Add(l1);

            b1.Click += b1_Click;
            form.ShowDialog();

            //add pictures
            pictureBox0.Image = imageList1.Images[0];
            pictureBox1.Image = imageList1.Images[0];
            pictureBox2.Image = imageList1.Images[0];
            pictureBox3.Image = imageList1.Images[0];
            pictureBox4.Image = imageList1.Images[0];
            pictureBox5.Image = imageList1.Images[0];
            pictureBox6.Image = imageList1.Images[0];
            pictureBox7.Image = imageList1.Images[0];
            pictureBox8.Image = imageList1.Images[0];
            pictureBox9.Image = imageList1.Images[0];
            pictureBox10.Image = imageList1.Images[0];
            pictureBox11.Image = imageList1.Images[0];
            pictureBox12.Image = imageList1.Images[0];
            pictureBox13.Image = imageList1.Images[0];
            pictureBox14.Image = imageList1.Images[0];
            pictureBox15.Image = imageList1.Images[0];
            pictureBox16.Image = imageList1.Images[0];
            pictureBox17.Image = imageList1.Images[0];

            //all the pictures used
            Bitmap pic1 = new Bitmap("pictures\\pic1.png");
            Bitmap pic10 = pic1;
            Bitmap pic2 = new Bitmap("pictures\\pic2.png");
            Bitmap pic11 = pic2;
            Bitmap pic3 = new Bitmap("pictures\\pic3.png");
            Bitmap pic12 = pic3;
            Bitmap pic4 = new Bitmap("pictures\\pic4.png");
            Bitmap pic13 = pic4;
            Bitmap pic5 = new Bitmap("pictures\\pic5.png");
            Bitmap pic14 = pic5;
            Bitmap pic6 = new Bitmap("pictures\\pic6.png");
            Bitmap pic15 = pic6;
            Bitmap pic7 = new Bitmap("pictures\\pic7.png");
            Bitmap pic16 = pic7;
            Bitmap pic8 = new Bitmap("pictures\\pic8.png");
            Bitmap pic17 = pic8;
            Bitmap pic9 = new Bitmap("pictures\\pic9.png");
            Bitmap pic18 = pic9;

            list1.Add(pic1);
            list1.Add(pic2);
            list1.Add(pic3);
            list1.Add(pic4);
            list1.Add(pic5);
            list1.Add(pic6);
            list1.Add(pic7);
            list1.Add(pic8);
            list1.Add(pic9);
            list1.Add(pic10);
            list1.Add(pic11);
            list1.Add(pic12);
            list1.Add(pic13);
            list1.Add(pic14);
            list1.Add(pic15);
            list1.Add(pic16);
            list1.Add(pic17);
            list1.Add(pic18);

            list2 = Scrambler(list1);

            stopwatch.Start();
        }
    
        
        private async void pictureBox0_Click(object sender, EventArgs e)
        {
            if (index == 0)
            {
                pictureBox0.Image = list2[0];

                pB = pictureBox0;

                index++;
            }

            else
            {
                pictureBox0.Image = list2[0];
                LockUnlockPictureBoxes(false);

                if (pB.Image != list2[0])
                {
                    await Task.Delay(1500);
                    pB.Image = imageList1.Images[0];
                    pictureBox0.Image = imageList1.Images[0];
                }

                else
                    openedBoxes++;

                LockUnlockPictureBoxes(true);
                index = 0;
                moves++;

                if (openedBoxes == 9)
                    EndProgram();
            }
        }

        private async void pictureBox1_Click(object sender, EventArgs e)
        {
            if (index == 0)
            {
                pictureBox1.Image = list2[1];

                pB = pictureBox1;
                index++;

            }

            else
            {
                pictureBox1.Image = list2[1];
                LockUnlockPictureBoxes(false);

                if (pB.Image != list2[1])
                {
                    await Task.Delay(1000);
                    pB.Image = imageList1.Images[0];
                    pictureBox1.Image = imageList1.Images[0];
                }
                else
                    openedBoxes++;

                LockUnlockPictureBoxes(true);
                index = 0;
                moves++;

                if (openedBoxes == 9)
                    EndProgram();
            }
        }

        private async void pictureBox2_Click(object sender, EventArgs e)
        {
            if (index == 0)
            {
                pictureBox2.Image = list2[2];

                pB = pictureBox2;

                index++;
            }

            else
            {
                pictureBox2.Image = list2[2];
                LockUnlockPictureBoxes(false);

                if (pB.Image != list2[2])
                {
                    await Task.Delay(1000);
                    pB.Image = imageList1.Images[0];
                    pictureBox2.Image = imageList1.Images[0];
                }
                else
                    openedBoxes++;

                LockUnlockPictureBoxes(true);
                index = 0;
                moves++;

                if (openedBoxes == 9)
                    EndProgram();
            }
        }

        private async void pictureBox3_Click(object sender, EventArgs e)
        {
            if (index == 0)
            {
                pictureBox3.Image = list2[3];

                pB = pictureBox3;

                index++;
            }

            else
            {
                pictureBox3.Image = list2[3];
                LockUnlockPictureBoxes(false);

                if (pB.Image != list2[3])
                {
                    await Task.Delay(1000);
                    pB.Image = imageList1.Images[0];
                    pictureBox3.Image = imageList1.Images[0];
                }
                else
                    openedBoxes++;

                LockUnlockPictureBoxes(true);
                index = 0;
                moves++;

                if (openedBoxes == 9)
                    EndProgram();
            }
        }

        private async void pictureBox4_Click(object sender, EventArgs e)
        {
            if (index == 0)
            {
                pictureBox4.Image = list2[4];

                pB = pictureBox4;

                index++;
            }

            else
            {
                pictureBox4.Image = list2[4];
                LockUnlockPictureBoxes(false);

                if (pB.Image != list2[4])
                {
                    await Task.Delay(1000);
                    pB.Image = imageList1.Images[0];
                    pictureBox4.Image = imageList1.Images[0];
                }
                else
                    openedBoxes++;

                LockUnlockPictureBoxes(true);
                index = 0;
                moves++;

                if (openedBoxes == 9)
                    EndProgram();
            }
        }

        private async void pictureBox5_Click(object sender, EventArgs e)
        {
            if (index == 0)
            {
                pictureBox5.Image = list2[5];

                pB = pictureBox5;

                index++;
            }

            else
            {
                pictureBox5.Image = list2[5];
                LockUnlockPictureBoxes(false);

                if (pB.Image != list2[5])
                {
                    await Task.Delay(1000);
                    pB.Image = imageList1.Images[0];
                    pictureBox5.Image = imageList1.Images[0];
                }
                else
                    openedBoxes++;

                LockUnlockPictureBoxes(true);
                index = 0;
                moves++;

                if (openedBoxes == 9)
                    EndProgram();
            }
        }

        private async void pictureBox6_Click(object sender, EventArgs e)
        {
            if (index == 0)
            {
                pictureBox6.Image = list2[6];

                pB = pictureBox6;

                index++;
            }

            else
            {
                pictureBox6.Image = list2[6];
                LockUnlockPictureBoxes(false);

                if (pB.Image != list2[6])
                {
                    await Task.Delay(1000);
                    pB.Image = imageList1.Images[0];
                    pictureBox6.Image = imageList1.Images[0];
                }
                else
                    openedBoxes++;

                LockUnlockPictureBoxes(true);
                index = 0;
                moves++;

                if (openedBoxes == 9)
                    EndProgram();
            }
        }

        private async void pictureBox7_Click(object sender, EventArgs e)
        {
            if (index == 0)
            {
                pictureBox7.Image = list2[7];

                pB = pictureBox7;

                index++;
            }

            else
            {
                pictureBox7.Image = list2[7];
                LockUnlockPictureBoxes(false);

                if (pB.Image != list2[7])
                {
                    await Task.Delay(1000);
                    pB.Image = imageList1.Images[0];
                    pictureBox7.Image = imageList1.Images[0];
                }
                else
                    openedBoxes++;

                LockUnlockPictureBoxes(true);
                index = 0;
                moves++;

                if (openedBoxes == 9)
                    EndProgram();
            }
        }

        private async void pictureBox8_Click(object sender, EventArgs e)
        {
            if (index == 0)
            {
                pictureBox8.Image = list2[8];

                pB = pictureBox8;

                index++;
            }

            else
            {
                pictureBox8.Image = list2[8];
                LockUnlockPictureBoxes(false);

                if (pB.Image != list2[8])
                {
                    await Task.Delay(1000);
                    pB.Image = imageList1.Images[0];
                    pictureBox8.Image = imageList1.Images[0];
                }
                else
                    openedBoxes++;

                LockUnlockPictureBoxes(true);
                index = 0;
                moves++;

                if (openedBoxes == 9)
                    EndProgram();
            }
        }

        private async void pictureBox9_Click(object sender, EventArgs e)
        {
            if (index == 0)
            {
                pictureBox9.Image = list2[9];

                pB = pictureBox9;

                index++;
            }

            else
            {
                pictureBox9.Image = list2[9];
                LockUnlockPictureBoxes(false);

                if (pB.Image != list2[9])
                {
                    await Task.Delay(1000);
                    pB.Image = imageList1.Images[0];
                    pictureBox9.Image = imageList1.Images[0];
                }
                else
                    openedBoxes++;

                LockUnlockPictureBoxes(true);
                index = 0;
                moves++;

                if (openedBoxes == 9)
                    EndProgram();
            }
        }

        private async void pictureBox10_Click(object sender, EventArgs e)
        {
            if (index == 0)
            {
                pictureBox10.Image = list2[10];

                pB = pictureBox10;

                index++;
            }

            else
            {
                pictureBox10.Image = list2[10];
                LockUnlockPictureBoxes(false);

                if (pB.Image != list2[10])
                {
                    await Task.Delay(1000);
                    pB.Image = imageList1.Images[0];
                    pictureBox10.Image = imageList1.Images[0];
                }
                else
                    openedBoxes++;

                LockUnlockPictureBoxes(true);
                index = 0;
                moves++;

                if (openedBoxes == 9)
                    EndProgram();
            }
        }

        private async void pictureBox11_Click(object sender, EventArgs e)
        {
            if (index == 0)
            {
                pictureBox11.Image = list2[11];

                pB = pictureBox11;

                index++;
            }

            else
            {
                pictureBox11.Image = list2[11];
                LockUnlockPictureBoxes(false);

                if (pB.Image != list2[11])
                {
                    await Task.Delay(1000);
                    pB.Image = imageList1.Images[0];
                    pictureBox11.Image = imageList1.Images[0];
                }
                else
                    openedBoxes++;

                LockUnlockPictureBoxes(true);
                index = 0;
                moves++;

                if (openedBoxes == 9)
                    EndProgram();
            }
        }

        private async void pictureBox12_Click(object sender, EventArgs e)
        {
            if (index == 0)
            {
                pictureBox12.Image = list2[12];

                pB = pictureBox12;

                index++;
            }

            else
            {
                pictureBox12.Image = list2[12];
                LockUnlockPictureBoxes(false);

                if (pB.Image != list2[12])
                {
                    await Task.Delay(1000);
                    pB.Image = imageList1.Images[0];
                    pictureBox12.Image = imageList1.Images[0];
                }
                else
                    openedBoxes++;

                LockUnlockPictureBoxes(true);
                index = 0;
                moves++;

                if (openedBoxes == 9)
                    EndProgram();
            }
        }

        private async void pictureBox13_Click(object sender, EventArgs e)
        {
            if (index == 0)
            {
                pictureBox13.Image = list2[13];

                pB = pictureBox13;

                index++;
            }

            else
            {
                pictureBox13.Image = list2[13];
                LockUnlockPictureBoxes(false);

                if (pB.Image != list2[13])
                {
                    await Task.Delay(1000);
                    pB.Image = imageList1.Images[0];
                    pictureBox13.Image = imageList1.Images[0];
                }
                else
                    openedBoxes++;

                LockUnlockPictureBoxes(true);
                index = 0;
                moves++;

                if (openedBoxes == 9)
                    EndProgram();
            }
        }

        private async void pictureBox14_Click(object sender, EventArgs e)
        {
            if (index == 0)
            {
                pictureBox14.Image = list2[14];

                pB = pictureBox14;

                index++;
            }

            else
            {
                pictureBox14.Image = list2[14];
                LockUnlockPictureBoxes(false);

                if (pB.Image != list2[14])
                {
                    await Task.Delay(1000);
                    pB.Image = imageList1.Images[0];
                    pictureBox14.Image = imageList1.Images[0];
                }
                else
                    openedBoxes++;

                LockUnlockPictureBoxes(true);
                index = 0;
                moves++;

                if (openedBoxes == 9)
                    EndProgram();
            }
        }

        private async void pictureBox15_Click(object sender, EventArgs e)
        {
            if (index == 0)
            {
                pictureBox15.Image = list2[15];

                pB = pictureBox15;

                index++;
            }

            else
            {
                pictureBox15.Image = list2[15];
                LockUnlockPictureBoxes(false);

                if (pB.Image != list2[15])
                {
                    await Task.Delay(1000);
                    pB.Image = imageList1.Images[0];
                    pictureBox15.Image = imageList1.Images[0];
                }
                else
                    openedBoxes++;

                LockUnlockPictureBoxes(true);
                index = 0;
                moves++;


                if (openedBoxes == 9)
                    EndProgram();
            }
        }

        private async void pictureBox16_Click(object sender, EventArgs e)
        {
            if (index == 0)
            {
                pictureBox16.Image = list2[16];

                pB = pictureBox16;

                index++;
            }

            else
            {
                pictureBox16.Image = list2[16];
                LockUnlockPictureBoxes(false);

                if (pB.Image != list2[16])
                {
                    await Task.Delay(1000);
                    pB.Image = imageList1.Images[0];
                    pictureBox16.Image = imageList1.Images[0];
                }
                else
                    openedBoxes++;

                LockUnlockPictureBoxes(true);
                index = 0;
                moves++;

                if (openedBoxes == 9)
                    EndProgram();
            }
        }

        private async void pictureBox17_Click(object sender, EventArgs e)
        {
            if (index == 0)
            {
                pictureBox17.Image = list2[17];

                pB = pictureBox17;

                index++;
            }

            else
            {
                pictureBox17.Image = list2[17];
                LockUnlockPictureBoxes(false);

                if (pB.Image != list2[17])
                {
                    await Task.Delay(1000);
                    pB.Image = imageList1.Images[0];
                    pictureBox17.Image = imageList1.Images[0];
                }
                else
                    openedBoxes++;

                LockUnlockPictureBoxes(true);
                index = 0;
                moves++;

                if (openedBoxes == 9)
                    EndProgram();
            }
        }

        //at the end of the game
        public void EndProgram()
        {
            player = new Player();
            seconds = Math.Round(stopwatch.Elapsed.TotalSeconds, 2);
            MessageBox.Show("Congratulations, you completed the game in " + moves+" moves for " + seconds + " seconds!", "Game finished", MessageBoxButtons.OK);
            player.time = seconds;
            player.move = moves;
            player.name = officialName;
            players.Add(player);

            stopwatch.Stop();
            FormLeaderboard leaderboardForm;

            DialogResult messageBox = MessageBox.Show("Is another player going to play the game?", "Continue the game", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (messageBox == DialogResult.Yes)
                StartForm();
            else
            {
                leaderboardForm = new FormLeaderboard(players);
                this.Close();
                leaderboardForm.Show();
            }
        }
    }
}
