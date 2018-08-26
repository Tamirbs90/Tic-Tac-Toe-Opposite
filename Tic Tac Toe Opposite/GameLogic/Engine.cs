using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public delegate void UIComponentsUpdater(int i_NumOfRow, int i_NumOfCol);

    public class Engine
    {
        private List<Player> m_Players = new List<Player>();
        private Board m_Board = new Board();
        private string m_WinnerPlayerName;
        private int m_CurrentPlayer = 0;
        public event UIComponentsUpdater UpdateUIComponents;

        public string TheWinner
        {
            get { return m_WinnerPlayerName; }
        }

        public int CurrentPlayer
        {
            get { return m_CurrentPlayer; }
        }

        public string CurrentPlayerName
        {
            get { return m_Players[m_CurrentPlayer].Name; }
        }

        public string CurrentPlayerType
        {
            get { return m_Players[m_CurrentPlayer].Type; }
        }

        public int BoardSize
        {
            get { return m_Board.BoardSize; }
            set { m_Board.BoardSize = value; }
        }

        public bool SetTile(int i_NumOfRow, int i_NumOfCol)
        { 
            if (m_CurrentPlayer == 0)
            { 
                return m_Board.SetTileAsX(i_NumOfRow, i_NumOfCol);
            }

            return m_Board.SetTileAsO(i_NumOfRow, i_NumOfCol);
        }

        public void SetWinnerProperties()
        {
            m_WinnerPlayerName = m_Players[m_CurrentPlayer].Name;
            m_Players[m_CurrentPlayer].NumOfPoints++;
        }

        public string Player1Details()
        {
            return m_Players[0].ToString();
        }

        public string Player2Details()
        {
            return m_Players[1].ToString();
        }

        public void MoveToNextPlayer()
        {
            if (m_CurrentPlayer == 0)
            {
                m_CurrentPlayer++;
            }
            else
            {
                m_CurrentPlayer = 0;
            }
        }

        public void StartAnotherGame()
        {
            m_CurrentPlayer = 0;
            m_Board.ClearBoard();
        }

        public void Init(int i_BoardSize, int i_NumberOfHumenPlayers, string i_Player1Name, string i_Player2Name)
        {
            m_Board.BoardSize = i_BoardSize;
            m_Board.BuildBoard();
            setPlayers(i_NumberOfHumenPlayers, i_Player1Name, i_Player2Name);
        }

        private void setPlayers(int i_NumberOfHumenPlayers, string i_Player1Name, string i_Player2Name)
        {
            m_Players.Add(new Player(i_Player1Name, "Human"));

            if (i_NumberOfHumenPlayers == 1)
            {
                m_Players.Add(new Player(i_Player2Name, "Computer"));
            }
            else
            {
                m_Players.Add(new Player(i_Player2Name, "Human"));
            }
        }

        public int[] MakeComputerMove()
        {
            bool completed = false;
            Random random = new Random();
            int[] rowAndColSelected = new int[2];

            while (!completed)
            {
                rowAndColSelected[0] = random.Next(0, BoardSize); //  row
                rowAndColSelected[1] = random.Next(0, BoardSize); //col
                completed = SetTile(rowAndColSelected[0], rowAndColSelected[1]);
            }

            return rowAndColSelected;
        }

        public bool GameIsOver()
        {
            return ThereIsWinner() || GameIsTied();
        }

        public bool ThereIsWinner()
        {
            return m_Board.IsDiagonalSequenceExists() || m_Board.IsHorizontalSequenceExists() ||
                 m_Board.IsVerticalSequenceExists();
        }

        public bool GameIsTied()
        {
            return m_Board.BoardIsFull()
                && !m_Board.IsDiagonalSequenceExists()
                && !m_Board.IsHorizontalSequenceExists()
                && !m_Board.IsVerticalSequenceExists();
        }

        public void InvokeUpdateUI(int i_NumOfRow, int i_NumOfCol)
        {
            UpdateUIComponents.Invoke(i_NumOfRow, i_NumOfCol);
        }
    }
}
