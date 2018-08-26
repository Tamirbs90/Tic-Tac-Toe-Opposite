using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public class Player
    {
        private string m_Name;
        private string m_Type;
        private int m_NumOfPoints;

        public Player(string i_Name, string i_Type)
        {
            m_Name = i_Name;
            m_Type = i_Type;
        }

        public int NumOfPoints
        {
           get { return m_NumOfPoints; }
           set { m_NumOfPoints = value; }
        }

        public string Type
        {
            get { return m_Type; }
            set { m_Type = value; }
        }

        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        public override string ToString()
        {
            return string.Format("{0} : {1}", Name, NumOfPoints);
        }
    }
}
