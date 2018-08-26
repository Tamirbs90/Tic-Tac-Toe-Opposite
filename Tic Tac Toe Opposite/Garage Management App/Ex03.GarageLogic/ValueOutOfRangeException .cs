using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;
        private float m_MinValue;
        private string m_ErrorMsg;

        public float MaxValue
        {
            get { return m_MaxValue; }
        }

        public float MinValue
        {
            get { return m_MinValue; }
        }

        public override string Message
        {
            get { return m_ErrorMsg; }
        }

        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue, string i_Msg = "An Error occured while trying to insert a value out of the range ")
        {
            m_MaxValue = i_MaxValue;
            m_MinValue = i_MinValue;
            m_ErrorMsg = string.Format("{0}{1}", i_Msg, Environment.NewLine);
        }
    }
}