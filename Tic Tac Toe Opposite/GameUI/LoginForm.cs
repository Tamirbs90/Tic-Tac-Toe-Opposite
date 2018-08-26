using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameLogic;


namespace GameUI
{
    public partial class LoginForm : Form
    {
        private bool m_OneHumanPlayer = true;

        public LoginForm()
        {
            InitializeComponent();
        }

        public int BoardSize
        {
            get { return (int)NudRows.Value; }
        }

        public string Player1Name
        {
            get { return Player1TextBox.Text; }
        }

        public string Player2Name
        {
            get { return Player2TextBox.Text; }
        }

        public bool isOneHumanPlayer
        {
            get { return m_OneHumanPlayer; }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void player2CheckBox_click(object sender, EventArgs e)
        {
            if (Player2CheckBox.Checked)
            {
                Player2TextBox.Enabled = true;
                m_OneHumanPlayer=false;
                Player2TextBox.Clear();
            }
            else
            {
                m_OneHumanPlayer = true;
                Player2TextBox.Text = "Computer";
                Player2TextBox.Enabled = false;
            }
        }

        private void NudCols_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nudCols = sender as NumericUpDown;

            NudRows.Value = nudCols.Value;
        }

        private void NudRows_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nudRows = sender as NumericUpDown;

            NudCols.Value = nudRows.Value;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (Player1TextBox.Text == string.Empty)
            {
                MessageBox.Show("Please enter player 1 name");
            }
            else if (Player2TextBox.Text == string.Empty)
            {
                MessageBox.Show("Please enter player 2 name");
            }
            else
            {
                this.Hide();
                GameForm gameForm = new GameForm();
                gameForm.Init(BoardSize, isOneHumanPlayer ? 1 : 2, Player1Name, Player2Name);
                gameForm.ShowDialog();
                this.Close();
            }
        }
    }
}
