using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected string m_ModelName;
        private string m_RegistrationPlate;
        private string m_OwnerName;
        private string m_OwnerPhone;
        private float m_EnergyPercentRemained;
        protected bool m_IsElectricVehicle;
        protected Engine m_Engine;
        private StateOfVehicle m_StateOfVehicle = StateOfVehicle.CurrentlyFixed;
        protected List<Wheel> m_Wheels = new List<Wheel>();

        public abstract void AddWheels();

        public virtual void SetVehicleEngine(bool i_IsElectricVehicle)
        {
            if (i_IsElectricVehicle)
            {
                m_Engine = new ElectricEngine();
            }
            else
            {
                m_Engine = new FuelledEngine();
            }
        }

        public void InflateWheels() 
        {
            foreach (Wheel wheel in m_Wheels)
            {
                wheel.InflateWheel(wheel.MaximalAirPressure - wheel.CurrentAirPressure);
            }
        }

        public void AddEnergy(float i_EnergyToAdd, eTypeOfFuel i_TypeOfFuel)  
        {
            m_Engine.AddEnergy(i_EnergyToAdd, i_TypeOfFuel);
        }

        public virtual List<string> GetSpecificVheicleDetails()
        {
            throw new NotImplementedException();
        }

        public virtual void SetSpecificDetails(List<string> i_Details)
        {
        }

        public override string ToString()
        {
            StringBuilder vehicleDetails = new StringBuilder();
            int i = 1;

            vehicleDetails.AppendLine("Vehicle information:");
            vehicleDetails.AppendFormat("License Number: {0}{1}", m_RegistrationPlate, Environment.NewLine);
            vehicleDetails.AppendFormat("Owner name: {0}{1}", m_OwnerName, Environment.NewLine);
            vehicleDetails.AppendFormat("Model name: {0}{1}", m_ModelName, Environment.NewLine);
            vehicleDetails.Append(m_Engine.ToString());
            vehicleDetails.AppendFormat("Energy percent remained: {0}{1}", m_EnergyPercentRemained, Environment.NewLine);
            foreach(Wheel wheel in m_Wheels)
            {
                vehicleDetails.AppendFormat("Wheel {0}", i);
                vehicleDetails.AppendLine(wheel.ToString());
            }

            return vehicleDetails.ToString();
        }

        public StateOfVehicle StateOfVehicle // option 3
        {
            get { return m_StateOfVehicle; }
            set { m_StateOfVehicle = value; }
        }

        public string ModelName
        {
            get { return m_ModelName; }
            set { m_ModelName = value; }
        }

        public string OwnerName
        {
            get { return m_OwnerName; }
            set { m_OwnerName = value; }
        }

        public string RegistrationPlate
        {
            get { return m_RegistrationPlate; }
            set { m_RegistrationPlate = value; }
        }

        public string OwnerPhone
        {
            get { return m_OwnerPhone; }
            set { m_OwnerPhone = value; }
        }

        public bool IsElectricVehicle
        {
            get { return m_IsElectricVehicle; }
            set { m_IsElectricVehicle = value; }
        }

        public float EnergeyPerecentRemaind
        {
            get { return (m_Engine.CurrentAmountOfEnergy / m_Engine.MaximalAmountOfEnergy) * 100; }
            set { m_EnergyPercentRemained = value; }
        }

        public List<Wheel> Wheels
        {
            get { return m_Wheels; }
        }

        public Engine Engine
        {
            get { return m_Engine; }
        }
    }
}
