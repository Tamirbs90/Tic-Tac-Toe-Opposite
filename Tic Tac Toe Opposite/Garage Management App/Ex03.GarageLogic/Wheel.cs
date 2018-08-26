using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_ManufucturerName;
        private float m_CurrentAirPressure;
        private float m_MaximalAirPressure;

        public Wheel(float i_MaximalAirPressure)
        {
            m_MaximalAirPressure = i_MaximalAirPressure;
        }

        public void InflateWheel(float i_AirToAdd)
        {
            if (m_CurrentAirPressure + i_AirToAdd <= m_MaximalAirPressure)
            {
                m_CurrentAirPressure += i_AirToAdd;
            }
        }

        public string ManufucturerName
        {
            get { return m_ManufucturerName; }
            set { m_ManufucturerName = value; }
        }

        public float CurrentAirPressure
        {
            get { return m_CurrentAirPressure; }
            set { m_CurrentAirPressure = value; }
        }

        public float MaximalAirPressure
        {
            get { return m_MaximalAirPressure; }
            set { m_MaximalAirPressure = value; }
        }

        public override string ToString()
        {
            string details = string.Format("current Air Pressure: {0} {1} name of manufecturer: {2}", m_CurrentAirPressure, Environment.NewLine, m_ManufucturerName);
            return details;
        }
    }
}
