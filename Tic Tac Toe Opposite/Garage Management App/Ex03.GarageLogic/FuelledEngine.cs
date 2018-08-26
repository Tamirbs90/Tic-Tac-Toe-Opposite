using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class FuelledEngine : Engine
    {
        private eTypeOfFuel m_TypeOfFuel;

        public override void AddEnergy(float i_EnergyToAdd, eTypeOfFuel i_TypeOfFuel)
        {
            if (m_CurrentAmountOfEnergy + i_EnergyToAdd <= m_MaximalAmountOfEnergy && i_TypeOfFuel == m_TypeOfFuel)
            {
                m_CurrentAmountOfEnergy += i_EnergyToAdd;
            }
        }

        public eTypeOfFuel TypeOfFuel
        {
            get { return m_TypeOfFuel; }
            set { m_TypeOfFuel = value; }
        }

        public override string ToString()
        {
            string engineDetails = string.Format("Amount of fuel left: {0} {1} Type Of Fuel: {2}", m_CurrentAmountOfEnergy, Environment.NewLine, m_TypeOfFuel.ToString());
            return engineDetails;
        }
    }
}
