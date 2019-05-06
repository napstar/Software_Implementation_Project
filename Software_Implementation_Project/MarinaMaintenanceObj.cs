using Software_Implementation_Project.Factory;
using System;


namespace Software_Implementation_Project
{
    public   class MarinaMaintenanceObj
    {
        public readonly int marinaLength = 150;
        private decimal rate = 10;
        public   Marina Marina = null;
        private BoatFactory BoatFactory = null;
        public MarinaMaintenanceObj()
        {
           this.Marina = new Marina();
            this.BoatFactory = new Factory.BoatFactory();
        }
        public  Boat createBoat()
        {
            int boatLen = 0;
            int boatType =0;
            int boatDraft = 0;
            string strBoatOwner = string.Empty;
            string strBoatName = string.Empty;
             

            Boat Boat = null;

            while (true)
            {
                Console.WriteLine("Enter Boat Length");
                string strBoatLength = Console.ReadLine();
                if (!string.IsNullOrEmpty(strBoatLength))
                {

                    int.TryParse(strBoatLength, out boatLen);

                }
                if (boatLen < 1)
                {
                    Console.WriteLine("Boat Length Cannot be less tha 1 meter");
                }
                if (boatLen > marinaLength || boatLen < 1)
                {
                    Console.WriteLine("Boat Length Cannot be Greater than Marina Length or less than 1 meter");
                }
                //else if(boatLen>(Marina.getCurrentCapacityMarinaLength()-Marina.MarinaLength))
                else if (boatLen > ( marinaLength -Marina.getCurrentCapacityMarinaLength()))
                {
                    throw new ArgumentException("The current marina capacity of "+Marina.getCurrentCapacityMarinaLength().ToString()+" will not be enough to accomodate this boat");
                }
                else
                {
                    break;
                }
            }
            while (true)
            {
                Console.WriteLine("Enter Boat Draft");
                string strBoatDraft = Console.ReadLine();
                if (!string.IsNullOrEmpty(strBoatDraft))
                {

                    int.TryParse(strBoatDraft, out boatDraft);

                }
                if (boatDraft < 1)
                {
                    Console.WriteLine("Boat Draft Cannot be less tha 1 meter");
                }
                if (boatDraft > 5 || boatDraft < 1)
                {
                    Console.WriteLine("Boat Draft Cannot be Greater than 5 meters or less than 1 meter");
                }
                else
                {
                    break;
                }
            }
            //check reservation here
            bool proceed = calculateBoatResrvation();
            if (proceed)
            {
                while (true)
                {
                    Console.WriteLine("Enter Boat Owner");
                    strBoatOwner = Console.ReadLine();
                    if (!string.IsNullOrEmpty(strBoatOwner))
                    {
                        break;
                    }
                }

                while (true)
                {
                    Console.WriteLine("Enter Boat Name");
                    strBoatName = Console.ReadLine();
                    if (!string.IsNullOrEmpty(strBoatName))
                    {
                        break;
                    }
                }







                Console.WriteLine("Choose Boat Type:");
                while (true)
                {
                    try
                    {
                        boatType = DisplayManager.displayBoatTypesMenu();
                        break;
                    }
                    catch (Exception ex)
                    {

                        DisplayManager.displayMessage(ex.Message);
                    }

                }


                switch (boatType)
                {
                    case 1:

                        MotorBoat MB = (Factory.MotorBoat)BoatFactory.BuildBoat(boatType);
                        int mbSubtype = BoatFactory.BuildBoatSubTypes(boatType);
                        MB.DriveType = MB.GetEnumNameFromValue(mbSubtype);
                        Boat = MB;
                        break;
                    case 2:

                        // NarrowBoat NB = new NarrowBoat("NarrowBoat", boatType);
                        NarrowBoat NB =(Factory.NarrowBoat)BoatFactory.BuildBoat(boatType);
                        int nbSubtype = BoatFactory.BuildBoatSubTypes(boatType);
                        NB.SternType = NB.GetEnumNameFromValue(nbSubtype);
                        Boat = NB;
                        break;
                    case 3:

                        //SailingBoat SB = new SailingBoat("Sailing", boatType);
                        SailingBoat SB  =(Factory.SailingBoat)BoatFactory.BuildBoat(boatType);
                        int sbSubtype = BoatFactory.BuildBoatSubTypes(boatType);
                        SB.SailingType = SB.GetEnumNameFromValue(sbSubtype);
                        Boat = SB;
                        break;

                    default:
                        break;
                }

                if (Boat != null)
                {
                    Boat.BoatLength = boatLen;
                    Boat.NameOfBoat = strBoatName;
                    Boat.NameOfOwner = strBoatOwner;
                    Boat.BoatDraft = boatDraft;
                    Factory.BoatHelperClass.showDetails(Boat);
                }
            }
            else
            {
                throw new Exception("User terminated Booking transaction");
            }
            
               
           
            
            
             
           
                
            

            return Boat;
        }
        
        public bool calculateBoatResrvation()
        {
            bool proceed= false;
            string strStartDate = string.Empty;
            string strEndDate = string.Empty;
            DateTime startDate = new DateTime();
            DateTime endDate = new DateTime();

            while (true)
            {
                DisplayManager.displayMessage("Please Enter The Start Date For Reservation:");
                strStartDate  = DisplayManager.getUserInputStr();
                if (!string.IsNullOrEmpty(strStartDate))
                {
                    try
                    {
                          startDate = DateTime.Parse(strStartDate);
                          break;
                    }
                    catch (Exception )
                    {
                        DisplayManager.displayMessage("Invalid date for start date");


                    }
                    finally
                    {

                    }
                     
                   
                }
                else
                {
                    DisplayManager.displayMessage("Please Enter a value for start date");
                }
                
            }
            while (true)
            {
                DisplayManager.displayMessage("Please Enter The End Date For Reservation:");
                try
                {
                    strEndDate = DisplayManager.getUserInputStr();
                    if (!string.IsNullOrEmpty(strEndDate))
                    {

                        endDate = DateTime.Parse(strEndDate);
                        //check if start date is greater than end date
                        if (startDate > endDate)
                        {
                            throw new InvalidOperationException("Start Date cannot be greater than End date");
                        }
                        else
                        {
                            //calculate date difference
                            double totalDays = (endDate - startDate).TotalDays;
                            try
                            {
                                decimal _totalDays = 0;
                                decimal.TryParse(totalDays.ToString(), out _totalDays);
                                //are both days the same
                                if (startDate.Date==endDate.Date)
                                {
                                    _totalDays = 1;
                                }

                                string strAmt = Factory.BoatHelperClass.FormatCurrency((_totalDays * rate), "GBP");
                                string message = "The total cost for the period ('" + startDate.ToShortDateString() + "') to '";
                                message += endDate.ToShortDateString() + "('"+ _totalDays.ToString() +"days')  is :" + strAmt;
                                message += "\n\n Do you wish to proceed(Press Y to Proceed or N to Cancel)";
                               

                                while (true)
                                {
                                    DisplayManager.displayMessage(message);
                                    string ans = DisplayManager.getUserInputStr();
                                    if (string.IsNullOrEmpty(ans))
                                    {
                                        throw new InvalidOperationException("Please Enter a valid answer in order to proceed");
                                    }
                                    if (ans.ToUpper() == "Y")
                                    {
                                        proceed = true;
                                        break;
                                    }
                                    else if (ans.ToUpper()=="N")
                                    {
                                        break;
                                    }
                                    else
                                    {

                                    }

                                }
                                break;
                            }
                            catch (Exception ex)
                            {
                                DisplayManager.displayMessage(ex.Message.ToString());

                            }
                            
                        }
                    }
                    else
                    {
                        DisplayManager.displayMessage("Please Enter a value for End date");
                    }
                }
                catch (Exception ex)
                {

                    DisplayManager.displayMessage(ex.Message.ToString());
                }
               
            }

           
           
            return proceed;
        }
        
       
    }
}
