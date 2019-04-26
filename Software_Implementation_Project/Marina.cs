using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Implementation_Project
{
     public  class Marina
    {
        /*
         * https://stackoverflow.com/questions/5236486/adding-items-to-end-of-linked-list
         * https://stackoverflow.com/questions/1432818/remove-node-from-single-linked-list
         */
        /*
        * this class functions as the Linked List object for storing boats 
        */
        private static int marinaLength = 150;
        private static BoatNode head;
        private static BoatNode current;
        private Factory.BoatFactory BoatFactory;

        public Marina()
        {
            head = null;
            BoatFactory = new Factory.BoatFactory();
        }
        public   int MarinaLength
        {
            get
            {
                return marinaLength;
            }


        }

        public   BoatNode Head
        {
            get
            {
                return head;
            }

            set
            {
                head = value;
            }
        }

        public   BoatNode Current
        {
            get
            {
                return current;
            }

            set
            {
                current = value;
            }
        }

        

        public   void ClearAllMarinaItems()
        {
            //empties the marina
            BoatNode tempNode = Head;
            BoatNode currentBoatNode = Head;
            BoatNode previousBoatNode = null;

            while (tempNode != null)
            {
                currentBoatNode = tempNode;
                if (previousBoatNode != null)
                {
                    previousBoatNode.SetNext(currentBoatNode.GetNext());
                }
                else
                {
                    Head.SetNext(null);
                }
               
                previousBoatNode = currentBoatNode;
                tempNode.SetNext(tempNode.GetNext());
                break;
            }
        }
        public   void DeleteBoat( )
        {
            try
            {
                string strNameOfBoatToDelete = string.Empty;
                FileOperations fp = new FileOperations();
                List<string> currentmarina = new List<string>();
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

                //clear marina
                ClearAllMarinaItems();
                //load data from file
                LoadDataFromFile();
                BoatNode temp = head, prev = null;

                // If head node itself holds the key to be deleted 
                if (temp != null && temp.GetItemData().NameOfBoat.ToUpper() == strNameOfBoatToDelete.ToUpper())
                {
                    head = temp.GetNext(); // Changed head 
                                           // Unlink the node from linked list 
                                           //prev.next = temp.next;
                   // prev.SetNext(temp.GetNext());
                   
                    
                    currentmarina = convertMarinaToList();
                    fp.writeToFile(true, currentmarina);
                    listAllBoats();
                    return;
                }

                // Search for the key to be deleted, keep track of the 
                // previous node as we need to change temp.next 
                while (temp != null && temp.GetItemData().NameOfBoat.ToUpper() != strNameOfBoatToDelete.ToUpper())
                {
                    string currentBoatName = temp.GetItemData().NameOfBoat.ToUpper();
                    Console.WriteLine(currentBoatName);
                    if (currentBoatName.ToUpper() != strNameOfBoatToDelete.ToUpper())
                    {
                        prev = temp;
                        temp = temp.GetNext();
                    }
                     
                }
                   

                // If key was not present in linked list 
                if (temp == null)
                {
                    return;
                }
                

                // Unlink the node from linked list 
                //prev.next = temp.next;
                prev.SetNext(temp.GetNext());
                
               
                currentmarina = convertMarinaToList();
                fp.writeToFile(true,currentmarina);
                listAllBoats();
            }
            catch (Exception ex)
            {

                DisplayManager.displayMessage(ex.Message);
            }
          
        }
        public void listAllBoats()
        {
            //clear marina
            ClearAllMarinaItems();
            //load from file 
            LoadDataFromFile();
            //print
            string sb = string.Empty;
           sb= this.PrintElements();
            DisplayManager.displayMessage(sb);
        }
     
        public   int getCurrentCapacityMarinaLength()
        {

            int total = 0;
            try
            {
                BoatNode _current = Head;
                //if (marina ==null)
                //{
                //    throw new Exception("Null Marina Object passed to getOutStandingMarinaLength ");
                //}
                if (_current != null)
                {
                    int currentBoatLen=_current.GetItemData().BoatLength;
                    total += currentBoatLen;
                    while (_current.GetNext() != null)
                    {
                        _current = _current.GetNext();
                        total += _current.GetItemData().BoatLength;
                       
                        
                    }
                }


            }
            catch (Exception ex)
            {

                DisplayManager.displayMessage(ex.ToString());
            }
            finally
            {

            }

            return total;
        }
        public   List<string> convertMarinaToList()
        {
            List<string> list = new List<string>();
           
            BoatNode current = head;
            
            while (current != null)
            {
                string data = string.Empty;
                //nameof boat
                data+=(current.GetItemData().NameOfBoat + ",");
                //owner
                data += (current.GetItemData().NameOfOwner + ",");
                // draft
                data+=(current.GetItemData().BoatDraft.ToString() + ",");
                //get boat type
                string boatType = current.GetItemData().TypeofBoat;
                data += (boatType + ",");
                switch (boatType)
                {
                    case "MotorBoat":
                        //MotorBoat
                       // sb.Append("MotorBoat" + " ");                       
                        Factory.MotorBoat TempMB = new Factory.MotorBoat("MotorBoat");
                        TempMB = (Factory.MotorBoat)current.GetItemData();
                        data += (TempMB.BoatLength.ToString() + ",");
                        data += (TempMB.DriveType + ",");                      
                        break;
                    case "NarrowBoat":
                        //NarrowBoat
                        //sb.Append("NarrowBoat" + " ");
                        Factory.NarrowBoat TempNB = new Factory.NarrowBoat("NarrowBoat");
                        TempNB = (Factory.NarrowBoat)current.GetItemData();
                        data += (TempNB.BoatLength + ",");
                        data += (TempNB.SternType + ",");
                        break;
                    case "Sailing":
                        //Sailing
                        // sb.Append("Sailing" + " ");
                        Factory.SailingBoat TempSB = new Factory.SailingBoat("Sailing");
                        TempSB = (Factory.SailingBoat)current.GetItemData();
                        data += (TempSB.BoatLength + ",");
                        data += (TempSB.SailingType + ",");
                        break;
                    default:
                        break;
                }
                //add to list
                //sb.AppendLine(data);
                list.Add(data);
                //get next
                current = current.GetNext();
            }
            return list;
        }
        public   void addBoatToMarina(Factory.Boat _boat)
        {
            try
            {
                //boat length cannot exceed marina Length
                if (_boat.BoatLength > marinaLength)
                {
                    throw new Exception("Boat length Exceeds Length of marina");
                }
                //do we have enough space for this boat in the marina
                //get marina
                 LoadDataFromFile();
                int currentCapacity = getCurrentCapacityMarinaLength();
                if ((marinaLength - currentCapacity) > _boat.BoatLength || marinaLength == 0)
                {
                    AddToEnd(_boat);
                    //write to file
                    
                    //FileOperations fp = new FileOperations();
                    //fp.writeToFile()
                }
                else
                {
                    throw new Exception("Cannot add " + _boat.NameOfBoat + " to the marina as it will not fit");
                }

            }
            catch (Exception ex)
            {

                throw(ex);

            }

        }
        private   void AddToEnd(Factory.Boat x)
        {
            //BoatNode current = marina.head;
            BoatNode current = head;

            
            if (current == null)
            {
                head = new BoatNode(x);
                head.SetNext(null);
            }           
            else
            {
                while (current.GetNext() != null)
                {
                    current = current.GetNext();
                }
                   

                // add new node at the end
                BoatNode toAppend = new BoatNode(x);
                current.SetNext(toAppend);
            }



        }
        private   string PrintElements()
        {
            BoatNode current = Head;
            StringBuilder sb = new StringBuilder();
            if (current==null)
            {
                // sb.AppendLine(current.GetItemData().NameOfBoat);
                sb.AppendLine("No Data in Marina");
            }
            else 
            {
                //sb.AppendLine(current.GetItemData().NameOfBoat);
                sb.Append(current.GetItemData().NameOfBoat).Append(",");
                sb.Append(current.GetItemData().NameOfOwner).Append(",");
                sb.Append(current.GetItemData().BoatDraft.ToString()).Append(",");
                sb.Append(current.GetItemData().BoatLength.ToString()).Append(",");
                string strBoatType = string.Empty;
                strBoatType = current.GetItemData().TypeofBoat.ToString();
                //sb.Append(current.GetItemData().strBoatType).Append(",");
                switch (strBoatType)
                {
                    case "MotorBoat":
                        Factory.MotorBoat MB = (Factory.MotorBoat)current.GetItemData();
                        sb.Append(MB.TypeofBoat).Append(",");
                        sb.Append(MB.DriveType).Append(",");
                        break;



                    case "NarrowBoat":
                        Factory.NarrowBoat NB = (Factory.NarrowBoat)current.GetItemData();
                        sb.Append(NB.TypeofBoat).Append(",");
                        sb.Append(NB.SternType).Append(",");

                        break;
                    case "Sailing":
                        Factory.SailingBoat SB = (Factory.SailingBoat)current.GetItemData();
                        sb.Append(SB.TypeofBoat).Append(",");
                        sb.Append(SB.SailingType).Append(",");

                        break;


                    default:
                        break;
                }
                sb.AppendLine("");
                while (current.GetNext() != null)
                {
                    current = current.GetNext();
                    sb.Append(current.GetItemData().NameOfBoat).Append(",");
                    sb.Append(current.GetItemData().NameOfOwner).Append(",");
                    sb.Append(current.GetItemData().BoatDraft.ToString()).Append(",");
                     sb.Append(current.GetItemData().BoatLength.ToString()).Append(",");
                      strBoatType = string.Empty;
                    strBoatType = current.GetItemData().TypeofBoat.ToString();
                    //sb.Append(current.GetItemData().strBoatType).Append(",");
                    switch (strBoatType)
                    {
                        case "MotorBoat":
                            Factory.MotorBoat MB = (Factory.MotorBoat)current.GetItemData();
                            sb.Append(MB.TypeofBoat).Append(",");
                            sb.Append(MB.DriveType).Append(",");
                            break;



                        case "NarrowBoat":
                            Factory.NarrowBoat NB = (Factory.NarrowBoat)current.GetItemData();
                            sb.Append(NB.TypeofBoat).Append(",");
                            sb.Append(NB.SternType).Append(",");

                            break;
                        case "Sailing":
                            Factory.SailingBoat SB = (Factory.SailingBoat)current.GetItemData();
                            sb.Append(SB.TypeofBoat).Append(",");
                            sb.Append(SB.SailingType).Append(",");
                           
                            break;


                        default:
                            break;
                    }
                   // sb.Append(current.GetItemData().BoatLength.ToString());
                    sb.AppendLine("");
                }
            }
            
           


            //add current marina capacity
            string strMarina = "The current marina capacity is:";
            int currentMarinaCapacity = 0;
            currentMarinaCapacity = getCurrentCapacityMarinaLength();
            strMarina += currentMarinaCapacity.ToString();
            sb.AppendLine("\n\n"+strMarina);
            return sb.ToString();


        }
        public   void LoadDataFromFile()
        {
           Marina marina = new Software_Implementation_Project.Marina();
            ClearAllMarinaItems();
            try
            {

                FileOperations fileOps = new Software_Implementation_Project.FileOperations();
                List<string> fileList = new List<string>();
                Factory.Boat boat = null;
                fileList = fileOps.readDataFromFile();
                if (fileList.Count < 1)
                {
                    // throw new Exception("No data was returned from file");
                }
                else
                {
                    foreach (string item in fileList)
                    {
                        //split array at commas and put result into an array
                        string[] arrSplitRow = item.Split(",".ToCharArray());
                        //create boat based on type 
                        string strBoatType = arrSplitRow[3];
                        string strBoatLen = arrSplitRow[4];
                        string strBoatDraft=arrSplitRow[2];
                        switch (strBoatType)
                        {
                            case "NarrowBoat":
                             //   boat = Factory.BoatFactory.BuildBoat(2);
                                Factory.NarrowBoat NB =(Factory.NarrowBoat)BoatFactory.BuildBoat(strBoatType);
                                int boatSubType = BoatFactory.BuildBoatSubTypes(strBoatType);
                                NB.TypeofBoat = strBoatType;
                                
                                NB.NameOfBoat = arrSplitRow[0];
                                NB.NameOfOwner = arrSplitRow[1];
                                int boatLen = 0;
                                int boatDraft = 0;
                                try
                                {
                                    int.TryParse(strBoatLen, out boatLen);
                                    NB.BoatLength = boatLen;
                                }
                                catch (Exception ex)
                                {

                                    NB.BoatLength = -1;

                                }
                                try
                                {
                                    int.TryParse(strBoatDraft, out boatDraft);
                                    NB.BoatDraft = boatDraft;
                                }
                                catch (Exception ex)
                                {
                                    NB.BoatDraft = 1;
                                }
                                NB.SternType = arrSplitRow[5];
                                boat = NB;
                                break;

                            case "Sailing":
                                boat = BoatFactory.BuildBoat(3);
                                Factory.SailingBoat SB = (Factory.SailingBoat)(BoatFactory.BuildBoat(strBoatType));
                                SB.TypeofBoat = strBoatType;
                                SB.TypeofBoat = strBoatType;
                                SB.NameOfBoat = arrSplitRow[0];
                                SB.NameOfOwner = arrSplitRow[1];
                                boatLen = 0;
                                try
                                {
                                    int.TryParse(strBoatLen, out boatLen);
                                    SB.BoatLength = boatLen;
                                }
                                catch (Exception ex)
                                {

                                    SB.BoatLength = -1;

                                }
                                try
                                {
                                    int.TryParse(strBoatDraft, out boatDraft);
                                    SB.BoatDraft = boatDraft;
                                }
                                catch (Exception ex)
                                {
                                    SB.BoatDraft = 1;
                                }
                                SB.SailingType = arrSplitRow[5];
                                boat = SB;
                                break;
                            case "MotorBoat":
                                boat = BoatFactory.BuildBoat(strBoatType);
                                Factory.MotorBoat MB = (Factory.MotorBoat)(BoatFactory.BuildBoat(strBoatType));
                                
                                MB.TypeofBoat = strBoatType;
                                MB.NameOfBoat = arrSplitRow[0];
                                MB.NameOfOwner = arrSplitRow[1];
                                MB.DriveType = arrSplitRow[5];
                                try
                                {
                                    int.TryParse(strBoatLen, out boatLen);
                                    MB.BoatLength = boatLen;
                                }
                                catch (Exception ex)
                                {

                                    MB.BoatLength = -1;

                                }
                                try
                                {
                                    int.TryParse(strBoatDraft, out boatDraft);
                                    MB.BoatDraft = boatDraft;
                                }
                                catch (Exception ex)
                                {
                                    MB.BoatDraft = 1;
                                }
                                boat = MB;
                                break;
                            default:
                                break;
                        }
                        //end of switch
                        // marina.addBoatToMarina(boat);
                        if (boat!=null)
                        {
                            AddToEnd(boat);
                        }
                        
                    }
                    //end of foreach loop
                }
            }
            catch (Exception ex)
            {

                DisplayManager.displayInvalidInputMessage(ex.ToString());
            }


            //return Marina;

        }
    }
}
