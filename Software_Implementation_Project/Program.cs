using Software_Implementation_Project.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Implementation_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            //diplays main menu and
            int user_Input = 0;
            MarinaMaintenanceObj MarinaMaintenanceObject = new Software_Implementation_Project.MarinaMaintenanceObj();
           Marina Marina = new Software_Implementation_Project.Marina();
            
            do
            {
                try
                {
                    user_Input = DisplayManager.displayHeaderMenu();
                    FileOperations FP = new Software_Implementation_Project.FileOperations();
                    switch (user_Input)
                    {
                        case 1:
                            Console.WriteLine("Add new boat");
                            Boat _boat = MarinaMaintenanceObject.createBoat(Marina);
                            if (_boat != null)
                            {
                                try
                                {
                                    int currentMarinaCapacity = 0;
                                    currentMarinaCapacity = Marina.getCurrentCapacityMarinaLength();
                                    int availableCapacity = MarinaMaintenanceObject.marinaLength - currentMarinaCapacity;
                                    if (_boat.BoatLength > availableCapacity)
                                    {
                                        throw new Exception("The boat, " + _boat.NameOfBoat.ToUpper() + " has a length of " + _boat.BoatLength.ToString() + ".\nThis exceeds the marina capacity and cannot fit into fit into the marina");
                                    }
                                    //bool proceed = MarinaMaintenanceObject.calculateBoatResrvation(_boat);
                                    //if (proceed)
                                    //{
                                        Marina.ClearAllMarinaItems();
                                    //add new boat to marina
                                        Marina.addBoatToMarina(_boat);
                                        List<string> listData = new List<string>();
                                    listData = Marina.convertMarinaToList();
                                        //write to  file
                                     
                                        FP.writeToFile(true, listData);

                                    //}

                                }
                                catch (Exception ex)
                                {

                                    DisplayManager.displayInvalidInputMessage(ex.Message);
                                }
                                finally
                                {
                                    DisplayManager.displayInvalidInputMessage("\n\nPress Enter to go back to main menu");
                                    Console.ReadLine();
                                    DisplayManager.clearScreen();
                                }


                            }
                            else
                            {
                                //Error in creeating boat
                                try
                                {
                                    throw new Exception("");
                                }
                                catch (Exception ex)
                                {

                                    DisplayManager.displayInvalidInputMessage("Error in creating boat.Please Try again.\n\n");
                                    DisplayManager.displayInvalidInputMessage(ex.Message + "\n\n");
                                    DisplayManager.displayInvalidInputMessage("Press Any Key to go back to main menu");
                                    Console.ReadLine();
                                    DisplayManager.clearScreen();
                                }

                            }
                            break;
                        case 2:
                            string strNameOfBoatToDelete = string.Empty;
                            while (true)
                            {
                                DisplayManager.displayMessage("Enter the name of the boat you to delete");
                                strNameOfBoatToDelete = DisplayManager.getUserInputStr();
                                if (!string.IsNullOrEmpty(strNameOfBoatToDelete))
                                {
                                    break;
                                }
                                else
                                {
                                    DisplayManager.displayMessage("Please Enter the name of the boat you to delete");
                                }
                            }
                            int index=Marina.FindItemByName(strNameOfBoatToDelete);
                            Marina.DeleteBoat(index);
                            List<string> data = new List<string>();
                            data = Marina.convertMarinaToList();
                            //write to  file
                            
                            FP.writeToFile(true, data);
                            DisplayManager.displayInvalidInputMessage("Press Any key to go back to main menu");
                            Console.ReadLine();
                            DisplayManager.clearScreen();
                            break;
                        case 3:
                            Console.WriteLine("display all boats");
                            Marina.listAllBoats();
                            DisplayManager.displayInvalidInputMessage("Press any key to go back to main menu");
                            Console.ReadLine();
                            DisplayManager.clearScreen();
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {

                    DisplayManager.displayMessage(ex.Message);
                    DisplayManager.displayInvalidInputMessage("\n\nPress any key to go back to main menu");
                            Console.ReadLine();
                            DisplayManager.clearScreen();
                }
                
            } while (user_Input != 4);
        }
     
        static int displayMenu()
        {
            int retVal = 0;
            string menuText =
                "\nWELCOME TO MARINA BERTH BOOKING SYSTEM.\n" +
                "What do you want to do?\n" +
                "1. Record a new booking.\n" +
                "2. Delete a Booking.\n" +
                "3. Display All Records.\n" +//and available marina space
                "4. Exit Application."
                 ;
           
            try
            {
                DisplayManager.drawRectangle(menuText, ConsoleColor.White, ConsoleColor.DarkBlue);
                string strInput = Console.ReadLine();
                int.TryParse(strInput, out retVal);
            }
            catch (Exception ex)
            {
                string message = "Please enter an valid number";
                DisplayManager.displayInvalidInputMessage(message);
            }
            return retVal;
        }
    }
}
