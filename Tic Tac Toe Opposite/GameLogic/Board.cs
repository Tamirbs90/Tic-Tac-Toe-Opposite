using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public class Board
    {
        private int m_BoardSize;
        private char[,] m_GameBoard;

        public int BoardSize
        {
            get { return m_BoardSize; }
            set { m_BoardSize = value; }
        }

        public void BuildBoard()
        {
            m_GameBoard = new char[m_BoardSize , m_BoardSize];
            for (int i = 0; i < m_BoardSize; i++)
            {
                for(int j = 0; j < m_BoardSize; j++)
                {
                    m_GameBoard[i, j] = ' ';
                }
            }
        }

        public bool SetTileAsX(int i_NumRow, int i_NumCol)
        {
            if (m_GameBoard[i_NumRow, i_NumCol] == ' ')
            {
                m_GameBoard[i_NumRow, i_NumCol] = 'X';

                return true;
            }

            return false;
        }

        public bool SetTileAsO(int i_NumRow, int i_NumCol)
        {
            if (m_GameBoard[i_NumRow, i_NumCol] == ' ')
            {
                m_GameBoard[i_NumRow, i_NumCol] = 'O';

                return true;
            }

            return false;
        }

        public bool IsHorizontalSequenceExists()
        {
            int countSequencesOfX = 0;
            int countSequencesOfO = 0;
            bool sequnceExists = false;

            for (int i = 0; i < m_BoardSize; i++)
            {
                for (int j = 0; j < m_BoardSize; j++)
                {
                    if (m_GameBoard[i, j] == 'X')
                    {
                        countSequencesOfX++;
                    }
                    else if (m_GameBoard[i, j] == 'O')
                    {
                        countSequencesOfO++;
                    }
                }

                if (countSequencesOfX == m_BoardSize || countSequencesOfO == m_BoardSize)
                {
                    sequnceExists = true;
                }
                else
                {
                    countSequencesOfX = 0;
                    countSequencesOfO = 0;
                }
            }

            return sequnceExists;
        }

        public bool IsVerticalSequenceExists()
        {
            int countSequencesOfX = 0;
            int countSequencesOfO = 0;
            bool sequnceExists = false;

            for (int j = 0; j < m_BoardSize; j++)
            {
                for (int i = 0; i < m_BoardSize; i++)
                {
                    if (m_GameBoard[i, j] == 'X')
                    {
                        countSequencesOfX++;
                    }
                    else if (m_GameBoard[i, j] == 'O')
                    {
                        countSequencesOfO++;
                    }
                }

                if (countSequencesOfX == m_BoardSize || countSequencesOfO == m_BoardSize)
                {
                    sequnceExists = true;
                }
                else
                {
                    countSequencesOfX = 0;
                    countSequencesOfO = 0;
                }
            }

            return sequnceExists;
        }

        public bool IsDiagonalSequenceExists()
        {
            return IsFirstDiagonalSequenceExists() || IsSecondDiagonalSequenceExist();
        }

        public bool IsFirstDiagonalSequenceExists()
        {
            int countSequencesOfX = 0;
            int countSequencesOfO = 0;

            for (int i = 0; i < m_BoardSize; i++)
            {
                if (m_GameBoard[i, i] == 'X')
                {
                    countSequencesOfX++;
                }
                else if (m_GameBoard[i, i] == 'O')
                {
                    countSequencesOfO++;
                }
            }

            return countSequencesOfX == m_BoardSize || countSequencesOfO == m_BoardSize;
        }

       public bool IsSecondDiagonalSequenceExist()
        {
            int countSequencesOfX = 0;
            int countSequencesOfO = 0;
            int j = m_BoardSize - 1;

            for (int i = 0; i < m_BoardSize; i++)
            {
                if (m_GameBoard[i, j] == 'X')
                {
                    countSequencesOfX++;
                }
                else if (m_GameBoard[i, j] == 'O')
                {
                    countSequencesOfO++;
                }

                j--;
            }

            return countSequencesOfX == m_BoardSize || countSequencesOfO == m_BoardSize;
        }

        public bool BoardIsFull()
        {
            bool isFull = true;

            for (int i = 0; i < m_BoardSize; i++)
            {
                for (int j = 0; j < m_BoardSize; j++)
                {
                    if (m_GameBoard[i, j] == ' ')
                    {
                        isFull = false;
                    }
                }
            }

            return isFull;
        }

        public void ClearBoard()
        {
            for (int i = 0; i < m_BoardSize; i++)
            {
                for (int j = 0; j < m_BoardSize; j++)
                {
                    m_GameBoard[i, j] = ' ';
                }
            }
        }
    }
}
