using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private List<Vehicle> m_Vehicles = new List<Vehicle>();

        public void AddVehicleToGarage(Vehicle i_Vehicle)
        {
            m_Vehicles.Add(i_Vehicle);
        }

        public void ChangeStateOfVehicle(string i_VehicleRegistrationPlate, StateOfVehicle i_NewState) // option 3
        {
            foreach (Vehicle vehicle in m_Vehicles)
            {
                if (vehicle.RegistrationPlate == i_VehicleRegistrationPlate)
                {
                    vehicle.StateOfVehicle = i_NewState;
                }
            }
        }

        public void InflateVehicleWheels(string i_VehicleRegistrationPlate) // option 4
        {
            foreach(Vehicle vehicle in m_Vehicles)
            {
                if (vehicle.RegistrationPlate == i_VehicleRegistrationPlate)
                {
                    vehicle.InflateWheels();
                }
            }
        }

        public void AddEnergyToVehicle(string i_VehicleRegistrationPlate, float i_AmountOfEnergyToAdd, eTypeOfFuel i_TypeOfFuel)
        {
            foreach(Vehicle vehicle in m_Vehicles)
            {
                if (vehicle.RegistrationPlate == i_VehicleRegistrationPlate)
                {
                    vehicle.AddEnergy(i_AmountOfEnergyToAdd, i_TypeOfFuel);
                }
            }
        }

        public List<string> CreateLicenseListByStateOfVehicle(StateOfVehicle i_VehicleState)
        {
            List<string> licenseNumbers = new List<string>();
            foreach (Vehicle vehicle in m_Vehicles)
            {
                if (vehicle.StateOfVehicle == i_VehicleState)
                {
                    licenseNumbers.Add(vehicle.RegistrationPlate);
                }
            }

            return licenseNumbers;
        }

        public bool DoesVehicleExist(string i_RegistrationPlate)
        {
            bool isExists = false;

            foreach (Vehicle vehicle in m_Vehicles)
            {
                if (vehicle.RegistrationPlate == i_RegistrationPlate)
                {
                    isExists = true;
                    break;
                }
            }

            return isExists;
        }

        public bool IsElectricVehicle(string i_RegistrationPlate)
        {
            bool isElectric = false;

            foreach (Vehicle vehicle in m_Vehicles)
            {
                if (vehicle.RegistrationPlate == i_RegistrationPlate)
                {
                    if (vehicle.IsElectricVehicle)
                    {
                        isElectric = true;
                    }
                }
            }

            return isElectric;
        }

        public bool IsTypeOfFuelMatch(string i_RegistrationNumber, eTypeOfFuel i_FuelType)
        {
            bool isMatch = false;

            foreach (Vehicle vehicle in m_Vehicles)
            {
                if (vehicle.RegistrationPlate == i_RegistrationNumber)
                {
                    if(((FuelledEngine)vehicle.Engine).TypeOfFuel == i_FuelType)
                    {
                        isMatch = true;
                    }
                }
            }

            return isMatch;
        }

        public string GetVehicleDetails(string i_LicensePlateNumber)
        {
            string vehicleDetails = string.Empty;
            foreach (Vehicle vehicle in m_Vehicles)
            {
                if (vehicle.RegistrationPlate == i_LicensePlateNumber)
                {
                    vehicleDetails = vehicle.ToString();
                }
            }

            return vehicleDetails;
        }
    }
}
