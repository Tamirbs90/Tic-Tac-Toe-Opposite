using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Engine
    {
        protected float m_CurrentAmountOfEnergy;
        protected float m_MaximalAmountOfEnergy;

        public virtual void AddEnergy(float i_EnergyToAdd, eTypeOfFuel i_TypeOfFuel)
        {
        }

        public float CurrentAmountOfEnergy
        {
            get { return m_CurrentAmountOfEnergy; }
            set { m_CurrentAmountOfEnergy = value; }
        }

        public float MaximalAmountOfEnergy
        {
            get { return m_MaximalAmountOfEnergy; }
            set { m_MaximalAmountOfEnergy = value; }
        }
    }
}
