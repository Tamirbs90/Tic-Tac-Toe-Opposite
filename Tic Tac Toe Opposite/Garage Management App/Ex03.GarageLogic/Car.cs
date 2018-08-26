using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private eColor m_ColorOfCar;
        private eNumOfDoors m_NumOfDoors;

        public Car() 
        {
            AddWheels();
        }

        public override void SetVehicleEngine(bool i_IsElectricVehicle)
        {
            base.SetVehicleEngine(i_IsElectricVehicle);
            if (i_IsElectricVehicle)
            {
                m_Engine.MaximalAmountOfEnergy = 2.8f;
            }
            else
            {
                m_Engine.MaximalAmountOfEnergy = 50;
                ((FuelledEngine)m_Engine).TypeOfFuel = eTypeOfFuel.Octan98;
            }
        }

        public override void AddWheels()
        {
            for (int i = 0; i < (int)eNumOfWheels.Car; i++)
            {
                m_Wheels.Add(new Wheel((float)eMaximalAirPressure.Car));
            }
        }

        public override List<string> GetSpecificVheicleDetails()
        {
            List<string> vehicleDetails = new List<string>();
            vehicleDetails.Add("Car color:" + Environment.NewLine + " 1) Green " + Environment.NewLine + " 2) Silver " + Environment.NewLine + " 3) White " + Environment.NewLine + " 4) Black" + Environment.NewLine);
            vehicleDetails.Add("Number of doors: (1-5) ");
            return vehicleDetails;
        }

        public override void SetSpecificDetails(List<string> i_Details)
        {
            ColorOfCar = (eColor)int.Parse(i_Details[0]);
            NumOfDoors = (eNumOfDoors)int.Parse(i_Details[1]);
        }

        public eColor ColorOfCar
        {
            get { return m_ColorOfCar; }
            set { m_ColorOfCar = value; }
        }

        public eNumOfDoors NumOfDoors
        {
            get { return m_NumOfDoors; }
            set { m_NumOfDoors = value; }
        }

        public override string ToString()
        {
            StringBuilder details = new StringBuilder();
            details.Append(base.ToString());
            details.AppendFormat("color of car: {0}{1}", Enum.GetName(typeof(eColor), m_ColorOfCar), Environment.NewLine);
            details.AppendFormat("number of doors: {0}{1}", Enum.GetName(typeof(eNumOfDoors), m_NumOfDoors), Environment.NewLine);
            return details.ToString();
        }
    }
}
