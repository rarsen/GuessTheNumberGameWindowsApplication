using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuessTheNumberGame
{
    public partial class Form2 : Form
    {
        private int timeLimit;
        private int num;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Random rand = new Random();
            num = rand.Next(Difficulty.min, Difficulty.max);
            switch (Difficulty.diff)
            {
                case "Easy":
                    timeLimit = 70;
                    break;
                case "Medium":
                    timeLimit = 60;
                    break;
                case "Hard":
                    timeLimit = 40;
                    break;
            }
            lbltimer.Text = timeLimit.ToString();
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = "Guess";
            int guess;
            if (!int.TryParse(txtBoxGuess.Text, out guess))
            {
                lblletssee.Text = "Invalid input! Please enter a number.";
                return;
            }

            if (guess > num)
            {
                lblletssee.Text = "Guess Lower!";
            }
            else if (guess < num)
            {
                lblletssee.Text = "Guess Higher!";
            }
            else if (guess == num)
            {
                MessageBox.Show("YOU WON!", "Winner", MessageBoxButtons.OK, MessageBoxIcon.Information);
                timer1.Stop();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timeLimit--;
            lbltimer.Text = timeLimit.ToString();
            if (timeLimit == 0)
            {
                MessageBox.Show("You lost time's up!", "Loser",MessageBoxButtons.OK,MessageBoxIcon.Information);
                timer1.Stop();
            }
        }
    }
}
