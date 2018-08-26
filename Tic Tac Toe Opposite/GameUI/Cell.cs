using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameUI
{
    public class Cell : Button
    {
        private int m_NumOfRow;
        private int m_NumOfCol;

        public Cell(int i_NumOfRow, int i_NumOfCol)
        {
            m_NumOfRow = i_NumOfRow;
            m_NumOfCol = i_NumOfCol;
            this.Height = 40;
            this.Width = 40;
        }

        public int NumOfRow
        {
            get { return m_NumOfRow; }
            set { m_NumOfRow = value; }
        }

        public int NumOfCol
        {
            get { return m_NumOfCol; }
            set { m_NumOfCol = value; }
        }
    }
}
