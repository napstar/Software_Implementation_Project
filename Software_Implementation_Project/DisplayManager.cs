using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Implementation_Project
{
    public class DisplayManager
    {
        public static int displayHeaderMenu()
        {
           // Console.Clear();
            string menuText =
            "\nWELCOME TO MARINA BERTH BOOKING SYSTEM.\n" +
            "What do you want to do?\n" +
            "1. Record a new booking.\n" +
            "2. Delete a Booking.\n" +
            "3. Display All Records.\n" +//and available marina space
            "4. Exit Application.";
            //Console.WriteLine(menuText);
            drawRectangle(menuText, ConsoleColor.White, ConsoleColor.DarkBlue);
            int userInput = DisplayManager.getUserInput();
            if (userInput<1 || userInput>4)
            {
                throw new ArgumentException("Please Enter an option between 1 and 4");
            }
            return userInput;
        }

        internal static int getBoatSubTypes(int type)
        {
            string subMenuType = "";
            string subTypeMessage = string.Empty;
            int retVal = 0;
            switch (type)
            {
                case 1:
                    //"MotorBoat"
                    subTypeMessage = "\n Please Select an Option \n"+
                                    "1. Inboard Drive \n"+
                                    "2. OutboardMotors \n";
                     while(true)
                    {
                        //displayMessage(subTypeMessage);
                        drawRectangle(subTypeMessage, ConsoleColor.White, ConsoleColor.DarkBlue);
                        subMenuType = DisplayManager.getUserInputStr();
                        if (!string.IsNullOrEmpty(subMenuType))
                        {
                            try
                            {
                                int.TryParse(subMenuType, out retVal);
                                Factory.MotorBoat MB = new Factory.MotorBoat();
                                int enumLen = MB.GetEnumLength();
                                if (retVal > enumLen || retVal< 1)
                                {
                                    throw new ArgumentOutOfRangeException("Invalid Option for Drive Types; Please Choose an option between 1 and "+enumLen);
                                }
                                else
                                {
                                    break;
                                }
                               
                            }
                            catch (Exception ex)
                            {
                                DisplayManager.displayMessage(ex.Message);
                                 
                            }
                            
                           
                        }
                    }
                    break;
                case 2:
                    // "NarrowBoat"
                    subTypeMessage = "\n Please Select an Option \n" +
                                     "1. Traditional stern\n"+ 
                                     "2. Cruiser stern    \n" +
                                     "3. Semi-traditional stern \n";
                    while (true)
                    {
                        drawRectangle(subTypeMessage, ConsoleColor.White, ConsoleColor.DarkBlue);
                        subMenuType = DisplayManager.getUserInputStr();
                        if (!string.IsNullOrEmpty(subMenuType))
                        {
                            try
                            {
                                int.TryParse(subMenuType, out retVal);
                                Factory.NarrowBoat NB = new Factory.NarrowBoat();
                                int enumLen = NB.GetEnumLength();
                                if (retVal > enumLen || retVal < 1)
                                {
                                    throw new ArgumentOutOfRangeException("Invalid Option for Stern Types; Please Choose an option between 1 and " + enumLen);
                                }
                                else
                                {
                                    break;
                                }
                            }
                            catch (Exception ex)
                            {
                                DisplayManager.displayMessage(ex.Message);

                            }

                        }
                    }
                    break;

                case 3:
                    //Sailing
                    subTypeMessage = "\n Please Select an Option \n" +
                                  "1. Ketch\n" +
                                  "2. Cutter  \n" +
                                  "3. Junk \n";
                    while (true)
                    {
                        drawRectangle(subTypeMessage, ConsoleColor.White, ConsoleColor.DarkBlue);
                        subMenuType = DisplayManager.getUserInputStr();
                        if (!string.IsNullOrEmpty(subMenuType))
                        {
                            try
                            {
                                int.TryParse(subMenuType, out retVal);
                                Factory.SailingBoat SB = new Factory.SailingBoat();
                                int enumLen = SB.GetEnumLength();
                                if (retVal > enumLen || retVal < 1)
                                {
                                    throw new ArgumentOutOfRangeException("Invalid Option for Stern Types; Please Choose an option between 1 and " + enumLen);
                                }
                                else
                                {
                                    break;
                                }
                            }
                            catch (Exception ex)
                            {

                                DisplayManager.displayMessage(ex.Message);
                            }

                        }
                    }
                    break;
                default:
                    break;
            }
            return retVal;
        }

        public static int displayBoatTypesMenu()
        {
            // Console.Clear();
            string menuText =
            "\n"+
            "1. Narrow.\n" +
            "2. Sailing.\n" +
            "3. Motor.\n" //and available marina space
            ;
            //Console.WriteLine(menuText);
            drawRectangle(menuText, ConsoleColor.White, ConsoleColor.DarkBlue);
            int userInput = DisplayManager.getUserInput();
            if (userInput<1 || userInput>3)
            {
                throw new ArgumentException("Please choose an option between 1 and 3");
            }
            return userInput;
        }
        

        private static void displayImportantMessage(string message)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        public static void displayMessage(string message)
        {
            
            Console.WriteLine(message);
           
        }
        public static void clearScreen()
        {
            Console.Clear();
        }
        public static string getUserInputStr()
        {

            string retVal = Console.ReadLine();



            return retVal;
        }
        public static int getUserInput()
        {
            int retVal = -1;
            string strInput = Console.ReadLine();
            try
            {
                int.TryParse(strInput, out retVal);
            }
            catch (Exception ex)
            {
                string message = "Please enter an valid number";
                DisplayManager.displayInvalidInputMessage(message);
            }
            finally
            {

            }

            return retVal;
        }
        public static void exitApplication()
        {
            GC.Collect();
            Environment.Exit(0);
        }
        public static void displayInvalidInputMessage(string message)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        

     
        public static void drawRectangle(string message, ConsoleColor foreGndColor, ConsoleColor backGndColor)
        {
            Console.BackgroundColor = backGndColor;
            Console.ForegroundColor = foreGndColor;
            int txtWidth = message.Length - 2, height = 3;

            for (int j = 1; j <= txtWidth - 60; j++)
            {

                Console.Write("*");

            }
            Console.WriteLine(message.PadLeft(150));
            for (int j = 1; j <= txtWidth - 60; j++)
            {

                Console.Write("*");

            }
            Console.WriteLine("");

            Console.ResetColor();
            Console.WriteLine("Type in an option");
        }
      
    }

}
