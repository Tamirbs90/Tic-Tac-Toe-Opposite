using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Track : Vehicle
    {
        private bool m_IsCarryingDangerousMaterials;
        private float m_MaximalCarriageWeight;

        public Track()
        {
            AddWheels();
        }

        public override void SetVehicleEngine(bool i_IsElectricVehicle)
        {
            base.SetVehicleEngine(i_IsElectricVehicle);
            m_Engine.MaximalAmountOfEnergy = 130;
            ((FuelledEngine)m_Engine).TypeOfFuel = eTypeOfFuel.Soler;
        }

        public override void AddWheels()
        {
            for (int i = 0; i < (int)eNumOfWheels.Track; i++)
            {
                m_Wheels.Add(new Wheel((float)eMaximalAirPressure.Track));
            }
        }

        public override List<string> GetSpecificVheicleDetails()
        {
            List<string> vehicleDetails = new List<string>();
            vehicleDetails.Add("Maximal carriage wheight:");
            vehicleDetails.Add("Carries Dangerous materials? (1-yes, 2-no)");
            return vehicleDetails;
        }

        public override void SetSpecificDetails(List<string> i_Details)
        {
            if (i_Details[0] == "1")
            {
                IsCarryingDangerousMaterials = true;
            }
            else
            {
                IsCarryingDangerousMaterials = false;
            }
            
            MaximalCarriageWeight = int.Parse(i_Details[1]);
        }

        public bool IsCarryingDangerousMaterials
        {
            get { return m_IsCarryingDangerousMaterials; }
            set { m_IsCarryingDangerousMaterials = value; }
        }

        public float MaximalCarriageWeight
        {
            get { return m_MaximalCarriageWeight; }
            set { m_MaximalCarriageWeight = value; }
        }

        public override string ToString()
        {
            StringBuilder details = new StringBuilder();
            details.Append(base.ToString());
            if (m_IsCarryingDangerousMaterials)
            {
                details.AppendLine("doesnt contain dangerous materials" + Environment.NewLine);
            }
            else
            {
                details.AppendLine("contains dangerous materials" + Environment.NewLine);
            }

            details.AppendFormat("Maximal Carraige weight:", m_MaximalCarriageWeight);

            return details.ToString();
        }
    }
}
