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
    public partial class GameForm : Form
    {
        private Engine m_GameEngine= new Engine();
        private Cell[,] m_Board;
        private const int k_CellSize = 40;
        private const int k_InitialDistanceFromLeft = 5;

        public GameForm()
        {
            InitializeComponent();
        }

        public void Init(int i_BoardSize, int i_NumOfHumanPlayers, string i_Player1Name, string i_Player2Name)
        {
            m_GameEngine.Init(i_BoardSize, i_NumOfHumanPlayers, i_Player1Name, i_Player2Name);
            buildGameBoard();
            updateScoreProperties();
        }

        private void buildGameBoard()
        {
            m_Board = new Cell[m_GameEngine.BoardSize, m_GameEngine.BoardSize];
            int leftDistance = k_InitialDistanceFromLeft;
            int topDistance = 10; //initial distance from top

            for (int i = 0; i < m_GameEngine.BoardSize; i++)
            {
                for (int j = 0; j < m_GameEngine.BoardSize; j++)
                {
                    m_Board[i, j] = new Cell(i, j);
                    m_Board[i, j].TabStop = false;
                    m_Board[i, j].Top = topDistance;
                    m_Board[i, j].Left = leftDistance;
                    m_Board[i, j].Click += gameCell_Click;
                    Controls.Add(m_Board[i, j]);
                    leftDistance += k_CellSize;
                }

                topDistance += k_CellSize;
                leftDistance = k_InitialDistanceFromLeft;
            }

           this.Height += 30; // make a room to game score. 
        }

        private void gameCell_Click(object sender, EventArgs e)
        {
            Cell senderButton = sender as Cell;

            m_GameEngine.SetTile(senderButton.NumOfRow, senderButton.NumOfCol);
            m_GameEngine.UpdateUIComponents += updateGameCell;
            updateBoardProperties(senderButton.NumOfRow, senderButton.NumOfCol);
            if (m_GameEngine.CurrentPlayerType == "Computer" && !m_GameEngine.GameIsOver())
            {
                int[] rowAndCol = m_GameEngine.MakeComputerMove();
                updateBoardProperties(rowAndCol[0], rowAndCol[1]);
            }
            if (m_GameEngine.GameIsOver())
            {
                DialogResult result = showEndOfGameMessages();
                afterGameOptions(result);
            }
  
                updateScoreProperties();
        }

        private void updateScoreProperties()
        {
            Player1Label.Text = m_GameEngine.Player1Details();
            Player2Label.Text = m_GameEngine.Player2Details();
            if (m_GameEngine.CurrentPlayer == 0)
            {
                Player1Label.Font = new Font(Player1Label.Font, FontStyle.Bold);
                Player2Label.Font = new Font(Player2Label.Font, FontStyle.Regular);
            }
            else
            {
                Player2Label.Font = new Font(Player2Label.Font, FontStyle.Bold);
                Player1Label.Font = new Font(Player1Label.Font, FontStyle.Regular);
            }
        }

        private void updateBoardProperties(int i_NumOfRow, int i_NumOfCol)
        {
            m_GameEngine.InvokeUpdateUI(i_NumOfRow, i_NumOfCol);
            m_Board[i_NumOfRow, i_NumOfCol].Enabled = false;
            m_GameEngine.MoveToNextPlayer();
        }

        private void updateGameCell(int i_NumOfRow, int i_NumOfCol)
        {
            if (m_GameEngine.CurrentPlayer == 0)
            {
                m_Board[i_NumOfRow, i_NumOfCol].Text = "X";
            }
            else
            {
                m_Board[i_NumOfRow, i_NumOfCol].Text = "O";
            }
        }

        private DialogResult showEndOfGameMessages()
        {
            DialogResult result;

            if (m_GameEngine.ThereIsWinner())
            {
                m_GameEngine.SetWinnerProperties();
                result = MessageBox.Show("The winner is " + m_GameEngine.TheWinner +
                     "\n Would you like to play another round?", "A win", MessageBoxButtons.YesNo);
            }
            else
            {
               result = MessageBox.Show("Tie.\n Would you like to play another round?", "A tie",
                    MessageBoxButtons.YesNo);
            }

            return result;
        }

        private void afterGameOptions(DialogResult i_Result)
        {
            if (i_Result == DialogResult.Yes)
            {
                m_GameEngine.StartAnotherGame();
                foreach (Cell cell in m_Board)
                {
                    cell.Text = " ";
                    cell.Enabled = true;
                }
            }
            else
            {
                this.Close();
            }
        }
    }
}
