using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
   public class VehicleCreator
    {
        public enum eTypeOfVehicle
        {
            Car = 1,
            Motorcycle,
            Truck
        }

        public static Vehicle CreateNewVehicle(eTypeOfVehicle i_TypeOfVehicle, bool i_IsElectricVehicle)
        {
            Vehicle newVehicle;
            if (i_TypeOfVehicle == eTypeOfVehicle.Car)
            {
                newVehicle = new Car();
            }
            else if (i_TypeOfVehicle == eTypeOfVehicle.Motorcycle)
            {
                newVehicle = new Motorcycle();
            }
            else 
            {
                newVehicle = new Track();
            }

            newVehicle.SetVehicleEngine(i_IsElectricVehicle);
            return newVehicle;
        } 
    }
}
