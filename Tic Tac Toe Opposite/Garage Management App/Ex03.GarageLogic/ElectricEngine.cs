using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
   public class ElectricEngine : Engine
    {
        public override void AddEnergy(float i_EnergyToAdd, eTypeOfFuel i_TypeOfFuel)
        {
            if (m_CurrentAmountOfEnergy + i_EnergyToAdd <= m_MaximalAmountOfEnergy)
            {
                m_CurrentAmountOfEnergy += i_EnergyToAdd;
            }
        }

        public override string ToString()
        {
            string engineDetails = string.Format("Hours Of Battry left: {0}", m_CurrentAmountOfEnergy);
            return engineDetails;
        }
    }
}
