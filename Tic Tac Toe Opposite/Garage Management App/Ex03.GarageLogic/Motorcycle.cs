using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        private eTypeOfLicense m_TypeOfLicense;
        private int m_EngineVolume;

        public Motorcycle()
        {
            AddWheels();
        }

        public override void SetVehicleEngine(bool i_IsElectricVehicle)
        {
            base.SetVehicleEngine(i_IsElectricVehicle);
            if (i_IsElectricVehicle)
            {
                m_Engine.MaximalAmountOfEnergy = 1.6f;
            }
            else
            {
                m_Engine.MaximalAmountOfEnergy = 5.5f;
                ((FuelledEngine)m_Engine).TypeOfFuel = eTypeOfFuel.Octan95;
            }
        }

        public override void AddWheels()
        {
            for (int i = 0; i < (int)eNumOfWheels.Motorcycle; i++)
            {
                m_Wheels.Add(new Wheel((float)eMaximalAirPressure.Motorcycle));
            }
        }

        public override List<string> GetSpecificVheicleDetails()
        {
            List<string> vehicleDetails = new List<string>();
            vehicleDetails.Add("Type of license: " + Environment.NewLine + " 1)A1 " + Environment.NewLine + " 2)B1 " + Environment.NewLine + "3)AA " + Environment.NewLine + " 4) BB");
            vehicleDetails.Add("Engine volume:");
            return vehicleDetails;
        }

        public override void SetSpecificDetails(List<string> i_Details)
        {
            TypeOfLiscene = (eTypeOfLicense)int.Parse(i_Details[0]);
            EngineVolume = int.Parse(i_Details[1]);
        }

        public eTypeOfLicense TypeOfLiscene
        {
            get { return m_TypeOfLicense; }
            set { m_TypeOfLicense = value; }
        }

        public int EngineVolume
        {
            get { return m_EngineVolume; }
            set { m_EngineVolume = value; }
        }

        public override string ToString()
        {
            StringBuilder details = new StringBuilder();
            details.Append(base.ToString());
            details.AppendFormat("Type Of license: {0}{1}", Enum.GetName(typeof(eTypeOfLicense), m_TypeOfLicense), Environment.NewLine);
            details.AppendFormat("Engine colume: {0}{1}", m_EngineVolume, Environment.NewLine);
            return details.ToString();
        }
    }
}
