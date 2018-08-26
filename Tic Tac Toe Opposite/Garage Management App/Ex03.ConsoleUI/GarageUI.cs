using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class GarageUI
    {
        public enum eMenuOptions
        {
            EnterVehicle = 1,
            ShowGarageVehicles,
            changeStatus,
            BlowWheelsToMaximum,
            FuelVehicle,
            chargeVehicle,
            ShowSpecificVehicleInformation
        }

	   protected const string k_ExceptionInvalidEmptyOrNullInput = "ERROR! Please enter license plate";
        protected const string k_ExceptionNotNumber = "ERROR! Please enter number";
        protected const string k_ExceptionVehicleDoesNotExist = "ERROR! Vehicle doesn't exist";
        protected const string k_ExceptionInvalidInput = "ERROR! Please enter valid input";
	   protected const string k_ExceptionNotAnEnum = "ERROR! Please enter number in range";
        private const int k_afterExeptionTime = 3000;
        private string m_StartMenu = string.Format(@"Choose one of the following options:
										1) Enter a vehicle.
										2) Show garage vehicles.
										3) Change vehicle status.
										4) Blowing wheels to maximum.
										5) Refuel vehicle.
										6) Charge electric vehicle
										7) Show specific vehicle information.");

        private Garage m_GarageLogic = new Garage();

        public void StartGarage()
        {
            do
            {
                try
                {
                    printMenu();
                    getAndExecutetUserChoice();
                }
                catch (ValueOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                    Thread.Sleep(k_afterExeptionTime);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    Thread.Sleep(k_afterExeptionTime);
                }
                catch (KeyNotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                    Thread.Sleep(k_afterExeptionTime);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    Thread.Sleep(k_afterExeptionTime);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                    Thread.Sleep(k_afterExeptionTime);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Thread.Sleep(k_afterExeptionTime);
                }            
            }
            while (true);
        }

        private void getAndExecutetUserChoice()
        {
            string userChoiceStr;
            int userChoiceNum;

            userChoiceStr = Console.ReadLine();
            if (!int.TryParse(userChoiceStr, out userChoiceNum))
            {
                throw new FormatException(k_ExceptionNotNumber);
            }

            switch (userChoiceNum)
            {
                case (int)eMenuOptions.EnterVehicle:
                    createAndAddNewVehicle();
                    break;
                case (int)eMenuOptions.ShowGarageVehicles:
                    showLicenseList();
                    break;
                case (int)eMenuOptions.changeStatus:
                    changeStatus();
                    break;
                case (int)eMenuOptions.BlowWheelsToMaximum:
                    inflateVehicleWheels();
                    break;
                case (int)eMenuOptions.FuelVehicle:
                    fuelVehicle();
                    break;
                case (int)eMenuOptions.chargeVehicle:
                    chargeVehicle();
                    break;
                case (int)eMenuOptions.ShowSpecificVehicleInformation:
                    showVehicleInformation();
                    break;
                default:
                    throw new ValueOutOfRangeException(1, Enum.GetNames(typeof(eMenuOptions)).Length, k_ExceptionVehicleDoesNotExist);
            }
        }

        private void printMenu()
        {
            Console.Clear();
            Console.WriteLine(m_StartMenu);
        }

        private void createAndAddNewVehicle()
        {
            string licensePlateNumber;
            bool isVehicleExist;
            Vehicle newVehicle;

            licensePlateNumber = getLicenseInput();
            isVehicleExist = m_GarageLogic.DoesVehicleExist(licensePlateNumber);

            if (!isVehicleExist)
            {
                newVehicle = creatNewVehicle();
                fillVehicleDetails(newVehicle, licensePlateNumber);
                m_GarageLogic.AddVehicleToGarage(newVehicle);
                Console.Clear();
                Console.WriteLine("Vehicle entered to garage");
                Thread.Sleep(k_afterExeptionTime);
            }
            else
            {
                m_GarageLogic.ChangeStateOfVehicle(licensePlateNumber, StateOfVehicle.CurrentlyFixed);
                Console.WriteLine("The vehicle exist in the garage. The status is: CurrentlyFixed");
                Thread.Sleep(k_afterExeptionTime);
            }
        }

        private Vehicle creatNewVehicle()
        {
            int i = 1;
            int vehicleTypeNum;
            int engineTypeNum;
            string vehicleTypeStr;
            string isElectricVehicleStr;
            bool isElectricVehicle = false;
            Vehicle newVehicle;

            Console.Clear();
            Console.WriteLine("Please enter the vehicle type:");
            foreach (string vehicleType in Enum.GetNames(typeof(VehicleCreator.eTypeOfVehicle)))
            {
                Console.WriteLine(string.Format("{0}) {1}", i, vehicleType));
                i++;
            }

            vehicleTypeStr = Console.ReadLine();

            if (!int.TryParse(vehicleTypeStr, out vehicleTypeNum))
            {
                throw new FormatException(k_ExceptionNotNumber);
            }
            else if (!Enum.IsDefined(typeof(VehicleCreator.eTypeOfVehicle), vehicleTypeNum))
            {
                throw new ValueOutOfRangeException(1, Enum.GetNames(typeof(VehicleCreator.eTypeOfVehicle)).Length);
            }

            Console.WriteLine("Is the Vehcile Electric? (1- yes, 2- no)");
            isElectricVehicleStr = Console.ReadLine();
            if (!int.TryParse(isElectricVehicleStr, out engineTypeNum))
            {
                throw new FormatException(k_ExceptionNotNumber);
            }

            if (engineTypeNum > 2 && engineTypeNum < 1)
            {
                throw new ValueOutOfRangeException(1, 2);
            }

            if (engineTypeNum == 1)
            {
                isElectricVehicle = true;
            }

            newVehicle = VehicleCreator.CreateNewVehicle((VehicleCreator.eTypeOfVehicle)vehicleTypeNum, isElectricVehicle);

            return newVehicle;
        }

        private void fillVehicleDetails(Vehicle i_Vehicle, string i_RegistrationPlate)
        {
            int i = 1;
            string currAmountEnergyStr;
            float currAirPressure;
            string currWheelStr;
            string currPressureStr;
            float currAmountEnergyFloat;
            Console.WriteLine("Name Of Owner:");
            i_Vehicle.OwnerName = Console.ReadLine();
            checkString(i_Vehicle.OwnerName);

            i_Vehicle.RegistrationPlate = i_RegistrationPlate;

            Console.WriteLine("Model name:");
            i_Vehicle.ModelName = Console.ReadLine();
            checkString(i_Vehicle.ModelName);

            Console.WriteLine("Owner phone number:");
            i_Vehicle.OwnerPhone = Console.ReadLine();
            checkString(i_Vehicle.OwnerPhone);

            foreach (Wheel wheel in i_Vehicle.Wheels)
            {
                Console.WriteLine("Wheel {0} manufucturer:", i);
                currWheelStr = Console.ReadLine();
                checkString(currWheelStr);
                wheel.ManufucturerName = currWheelStr;

                Console.WriteLine("Wheel {0} air pressure:", i);
                currPressureStr = Console.ReadLine();
                if (!float.TryParse(currPressureStr, out currAirPressure))
                {
                    throw new FormatException(k_ExceptionNotNumber);
                }

                if (currAirPressure > wheel.MaximalAirPressure)
                {
                    throw new ValueOutOfRangeException(0, wheel.MaximalAirPressure, k_ExceptionNotAnEnum);
                }

                wheel.CurrentAirPressure = currAirPressure;
                i++;
            }

            Console.WriteLine("Current Amount of Energy: ");
            currAmountEnergyStr = Console.ReadLine();
            if (!float.TryParse(currAmountEnergyStr, out currAmountEnergyFloat))
            {
                throw new FormatException(k_ExceptionNotNumber);
            }

            if (i_Vehicle.Engine.MaximalAmountOfEnergy < currAmountEnergyFloat)
            {
                throw new ValueOutOfRangeException(0, i_Vehicle.Engine.MaximalAmountOfEnergy, k_ExceptionNotAnEnum);

            }

            i_Vehicle.Engine.CurrentAmountOfEnergy = currAmountEnergyFloat;

            List<string> specificQuestions = i_Vehicle.GetSpecificVheicleDetails();
            List<string> answers = new List<string>();

            foreach (string question in specificQuestions)
            {
                Console.WriteLine(question);
                string answer = Console.ReadLine();
                answers.Add(answer);
            }

            i_Vehicle.SetSpecificDetails(answers);
        }

        private void showLicenseList()
        {
            StateOfVehicle userStateChoice;
            List<string> licenseList = new List<string>();

            userStateChoice = getFilterChoiceInput();

            licenseList = m_GarageLogic.CreateLicenseListByStateOfVehicle(userStateChoice);
            Console.Clear();
            Console.WriteLine(string.Format("The status of the vehicle - {0}:{1}", userStateChoice.ToString(), Environment.NewLine));
            foreach(string licenseNumber in licenseList)
            {
                Console.WriteLine(licenseNumber);
            }

            Thread.Sleep(k_afterExeptionTime);
        }

        private StateOfVehicle getFilterChoiceInput()
        {
            printFilterChoices();

            StateOfVehicle userChoice;
            string userChoiceStr;
            int userChoiceNumber;

            userChoiceStr = Console.ReadLine();

            if (!int.TryParse(userChoiceStr, out userChoiceNumber))
            {
                throw new FormatException(k_ExceptionNotNumber);
            }
            else if (Enum.IsDefined(typeof(StateOfVehicle), userChoiceNumber))
            {
                userChoice = (StateOfVehicle)userChoiceNumber;
            }
            else
            {
                throw new ValueOutOfRangeException(1, Enum.GetValues(typeof(StateOfVehicle)).Length); 
            }

            return userChoice;
        }

        private void printFilterChoices()
        {
            StringBuilder filterChoices = new StringBuilder("Please choose which cars you want to see:" + Environment.NewLine);
            int i = 1;

            foreach (StateOfVehicle vehicleState in Enum.GetValues(typeof(StateOfVehicle)))
            {
                filterChoices.AppendFormat("{0}) {1},{2}", i, vehicleState.ToString(), Environment.NewLine);
                i++;
            }

            Console.Clear();
            Console.Write(filterChoices);
        }

        private string getLicenseInput()
        {
            string licensePlateNumber;

            Console.Clear();
            Console.WriteLine("Please enter the vehicle license Plate Number");
            licensePlateNumber = Console.ReadLine().Trim();
            checkString(licensePlateNumber);
            
            return licensePlateNumber;
        }

        private void checkString(string i_UserInput)
        {
            if (string.IsNullOrEmpty(i_UserInput))
            {
                throw new ArgumentNullException(k_ExceptionInvalidEmptyOrNullInput);
            }
        }

        private void changeStatus()
        {
            string licensePlateNumber;
            string newStatusStr;
            int newStatusNumber;
            StateOfVehicle status;

            licensePlateNumber = getLicenseInput();
            if (!m_GarageLogic.DoesVehicleExist(licensePlateNumber))
            {
                throw new Exception(k_ExceptionVehicleDoesNotExist);
            }

            Console.Clear();
            Console.WriteLine(vehicleStatesMenu());
            newStatusStr = Console.ReadLine();

            if (!int.TryParse(newStatusStr, out newStatusNumber))
            {
                throw new FormatException(k_ExceptionNotNumber); 
            }
            else if (Enum.IsDefined(typeof(StateOfVehicle), newStatusNumber))
            {
                status = (StateOfVehicle)newStatusNumber;
                m_GarageLogic.ChangeStateOfVehicle(licensePlateNumber, status);
                Console.Clear();
                Console.WriteLine("Vehicle status changed successfully");
                Thread.Sleep(k_afterExeptionTime);
            }
            else
            {
                throw new ArgumentException(k_ExceptionInvalidInput);
            }
        }

        private string vehicleStatesMenu()
        {
            StringBuilder vehicleStatus = new StringBuilder();
            int i = 1;

            vehicleStatus.AppendLine("Please enter a new status:");
            foreach (string condition in Enum.GetNames(typeof(StateOfVehicle)))
            {
                vehicleStatus.AppendLine(string.Format("{0}){1}", i, condition));
                i++;
            }

            return vehicleStatus.ToString();
        }

        private void inflateVehicleWheels()
        {
            string licensePlateNumber;
            licensePlateNumber = getLicenseInput();

            if (!m_GarageLogic.DoesVehicleExist(licensePlateNumber))
            {
                throw new Exception(k_ExceptionVehicleDoesNotExist);
            }
            
            m_GarageLogic.InflateVehicleWheels(licensePlateNumber);
            Console.Clear();
            Console.WriteLine("Wheels inflated to max");
            Thread.Sleep(k_afterExeptionTime);
        }

        private void fuelVehicle()
        {
            string licensePlateNumber;
            float additionalEnergy;
            eTypeOfFuel fuelType;
            licensePlateNumber = getLicenseInput();
            checkIfVehicleExists(licensePlateNumber);
            checkIfFuelledVehicle(licensePlateNumber);
            fuelType = getFuelTypeInput(licensePlateNumber);
            if (!m_GarageLogic.IsTypeOfFuelMatch(licensePlateNumber, fuelType))
            {
                throw new ArgumentException("Selected fuel type doesnt match");
            }

            additionalEnergy = getAdditionalEnergyInput();
            m_GarageLogic.AddEnergyToVehicle(licensePlateNumber, additionalEnergy, fuelType);
            Console.Clear();
            Console.WriteLine("Vehicle refuled");
            Thread.Sleep(k_afterExeptionTime);
        }

        private eTypeOfFuel getFuelTypeInput(string i_LicensePlateNumbe)
        {
            string fuelTypeStr;
            StringBuilder fuelTypeQuestion = new StringBuilder(string.Format("Please enter the fuel type:" + Environment.NewLine));
            int fuelTypeNumber;
            int i = 1;
            eTypeOfFuel fuelType;

            foreach (string typeOfFul in Enum.GetNames(typeof(eTypeOfFuel)))
            {
                fuelTypeQuestion.AppendLine(string.Format("{0}) {1} ", i, typeOfFul));
                i++;
            }

            Console.Clear();
            Console.Write(fuelTypeQuestion.ToString());

            fuelTypeStr = Console.ReadLine();
            if (!int.TryParse(fuelTypeStr, out fuelTypeNumber))
            {
                throw new FormatException(k_ExceptionNotNumber);
            }
            else if (Enum.IsDefined(typeof(eTypeOfFuel), fuelTypeNumber))
            {
                fuelType = (eTypeOfFuel)fuelTypeNumber;
            }
            else
            {
                throw new ArgumentException(k_ExceptionInvalidInput);
            }

            return fuelType;
        }

        private float getAdditionalEnergyInput()
        {
            string additionalEnergyStr;
            float additionalEnergyNum;

            Console.Clear();
            Console.WriteLine("Please enter how much energy to add to the vehicle");
            additionalEnergyStr = Console.ReadLine();

            if (!float.TryParse(additionalEnergyStr, out additionalEnergyNum))
            {
                throw new FormatException(k_ExceptionNotNumber);
            }

            return additionalEnergyNum;
        }

        private void showVehicleInformation()
        {
            string vehicleLicensePlateNumber;

            Console.Clear();
            vehicleLicensePlateNumber = getLicenseInput();
            checkIfVehicleExists(vehicleLicensePlateNumber);
            Console.WriteLine(m_GarageLogic.GetVehicleDetails(vehicleLicensePlateNumber));
            Thread.Sleep(k_afterExeptionTime);
        }
     
        private void chargeVehicle()
        {
            string licensePlateNumber;
            float additionalEnergy;

            licensePlateNumber = getLicenseInput();
            checkIfVehicleExists(licensePlateNumber);
            checkIfElectricVehicle(licensePlateNumber);
            additionalEnergy = getAdditionalEnergyInput();
            m_GarageLogic.AddEnergyToVehicle(licensePlateNumber, additionalEnergy, eTypeOfFuel.Octan95);
            Console.Clear();
            Console.WriteLine("Vehicle charged");
            Thread.Sleep(k_afterExeptionTime);
        }

        private void checkIfVehicleExists(string i_LicensePlateNumber)
        {
            if (!m_GarageLogic.DoesVehicleExist(i_LicensePlateNumber))
            {
                throw new Exception(k_ExceptionVehicleDoesNotExist);
            }
        }

        private void checkIfFuelledVehicle(string i_LicensePlateNumber)
        {
            if (m_GarageLogic.IsElectricVehicle(i_LicensePlateNumber))
            {
                throw new InvalidOperationException("Vehicle is Electric");
            }
        }

        private void checkIfElectricVehicle(string i_LicensePlateNumber)
        {
            if (!m_GarageLogic.IsElectricVehicle(i_LicensePlateNumber))
            {
                throw new InvalidOperationException("Vehicle is not Electric");
            }
        }
    }
}
