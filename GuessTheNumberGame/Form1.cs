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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int min, max;
            if (!int.TryParse(txtBoxMin.Text, out min) || !int.TryParse(txtBoxMax.Text, out max))
            {
                MessageBox.Show("Please enter valid minimum and maximum values.");
                return;
            }
            string diff = comboBox1.SelectedItem.ToString();
            switch (diff)
            {
                case "Easy":
                    Difficulty.diff = "Easy";
                    break;
                case "Medium":
                    Difficulty.diff = "Medium";
                    break;
                case "Hard":
                    Difficulty.diff = "Hard";
                    break;
            }
            Difficulty.min = min;
            Difficulty.max = max;

            Form2 f2 = new Form2();
            this.Hide();
            f2.ShowDialog();
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
