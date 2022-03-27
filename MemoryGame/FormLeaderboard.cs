using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryGame
{
    public partial class FormLeaderboard : Form 
    {
        List<Player> players = new List<Player>();
        public FormLeaderboard()
        {
            InitializeComponent();
        }

        public FormLeaderboard(List<Player> players)
        {
            InitializeComponent();
            this.players = players;
        }

        private void FormLeaderboard_Load(object sender, EventArgs e)
        {
            AddItems();
        }

        public void AddItems()
        {
            players = players.OrderBy(o => o.time).ToList();

            for (int i = 1; i <= players.Count; i++)
            {
                string item = i.ToString() + ". " + players[i - 1].name + " - " + players[i - 1].time.ToString() + " seconds - " + players[i - 1].move.ToString()
                            + " moves - " ; 
                listBox1.Items.Add(item);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
