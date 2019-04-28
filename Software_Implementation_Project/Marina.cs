using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Implementation_Project
{
     public   class Marina
    {
        /*
         * https://stackoverflow.com/questions/5236486/adding-items-to-end-of-linked-list
         * https://stackoverflow.com/questions/1432818/remove-node-from-single-linked-list
         */
        /*
        * this class functions as the Linked List object for storing boats 
        */
        private   int marinaLength = 150;
        private BoatNode head ;
        //private BoatNode next;
        private int count ;
        private   Factory.BoatFactory BoatFactory;

        public Marina()
        {
            head = null;
            BoatFactory = new Factory.BoatFactory();
            count = 0;
        }
        public int MarinaLength
        {
            get
            {
                return marinaLength;
            }


        }

        public BoatNode Head
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

        public int Count
        {
            get
            {
                return count;
            }

            set
            {
                count = value;
            }
        }


        public void Add(int index,BoatNode b)
        {
            if (index<0)
            {
                throw new IndexOutOfRangeException("Index cannot be less than zero");
            }
            if (index>count)
            {
                index = count;
            }
            //get head
            BoatNode current = this.Head;
            if (Count==0 || index==0)
            {
                this.Head = b;
            }
            else
            {
                for (int i = 0; i < index-1; i++)
                {
                    current = current.GetNext();
                }
               // BoatNode nextBoat = new Software_Implementation_Project.BoatNode(b, current.GetNext());
                current.SetNext(b);
            }
            this.Count++;
        }
        public void AddToEnd(Factory.Boat boat)
        {
            BoatNode node = new Software_Implementation_Project.BoatNode(boat);
            Add(this.Count, node);
        }
        public void DeleteBoat(int index)
        {
            if (index<0)
            {
                throw new IndexOutOfRangeException("Index for delete boat is out of range");
            }
            
            BoatNode currentBoat = this.head;
            if (index>Count)
            {
                index = Count - 1;
            }
            if (index==0)
            {
                this.Head = currentBoat.GetNext();
                
            }
            else
            {
                for (int i = 0; i < index-1; i++)
                {
                    currentBoat = currentBoat.GetNext();
                }
                currentBoat.SetNext(currentBoat.GetNext().GetNext());
               
            }
            count--;
        }
        public void ClearAllMarinaItems()
        {
            this.Head = new BoatNode();
            // this.Head.SetNext(null);
            this.count = 0;
        }
        public int FindItemByName(string boatName)
        {
            int result = 0;
            BoatNode currentBoat = this.head;
            if (Count<1)
            {
                LoadDataFromFile();
            }
            if (currentBoat.GetItemData().NameOfBoat.ToUpper()==boatName.ToUpper())
            {
                result = 0;
                return result ;
            }
            for (int i = 1; i <= Count-1; i++)
            {
                currentBoat = currentBoat.GetNext();
                if (currentBoat.GetItemData().NameOfBoat.ToUpper() == boatName.ToUpper())
                {
                    result= i;
                }
            }
            return result;
        }
        //public   void ClearAllMarinaItems()
        //{
        //    //empties the marina
        //    BoatNode tempNode = head;
        //    BoatNode currentBoatNode = head;
        //    BoatNode previousBoatNode = null;

        //    while (tempNode != null)
        //    {
        //        currentBoatNode = tempNode;
        //        if (previousBoatNode != null)
        //        {
        //            previousBoatNode.SetNext(currentBoatNode.GetNext());
        //        }
        //        else
        //        {
        //            //head.SetFirst(null);
        //            //head.SetNext(null);
        //            //string srtt = "";
        //            head.ClearData(head);
        //        }

        //        previousBoatNode = currentBoatNode;
        //        tempNode.SetNext(tempNode.GetNext());
        //        break;
        //    }
        //}
        //public   void DeleteBoat( )
        //{
        //    try
        //    {
        //        string strNameOfBoatToDelete = string.Empty;
        //        FileOperations fp = new FileOperations();
        //        BoatFactory = new Factory.BoatFactory();
        //        List<string> currentmarina = new List<string>();
        //        while (true)
        //        {
        //            DisplayManager.displayMessage("Enter the name of the boat you to delete");
        //            strNameOfBoatToDelete = DisplayManager.getUserInputStr();
        //            if (!string.IsNullOrEmpty(strNameOfBoatToDelete))
        //            {
        //                break;
        //            }
        //            else
        //            {
        //                DisplayManager.displayMessage("Please Enter the name of the boat you to delete");
        //            }
        //        }

        //        //clear marina
        //        ClearAllMarinaItems();
        //        //load data from file
        //        LoadDataFromFile();
        //        BoatNode temp = head, prev = null;

        //        // If head node itself holds the key to be deleted 
        //        if (temp != null && temp.GetItemData().NameOfBoat.ToUpper() == strNameOfBoatToDelete.ToUpper())
        //        {
        //            head = temp.GetNext(); // Changed head 
        //                                   // Unlink the node from linked list 
        //                                   //prev.next = temp.next;
        //           // prev.SetNext(temp.GetNext());


        //            currentmarina = convertMarinaToList();
        //            fp.writeToFile(true, currentmarina);
        //            listAllBoats();
        //            return;
        //        }

        //        // Search for the key to be deleted, keep track of the 
        //        // previous node as we need to change temp.next 
        //        while (temp != null && temp.GetItemData().NameOfBoat.ToUpper() != strNameOfBoatToDelete.ToUpper())
        //        {
        //            string currentBoatName = temp.GetItemData().NameOfBoat.ToUpper();
        //            Console.WriteLine(currentBoatName);
        //            if (currentBoatName.ToUpper() != strNameOfBoatToDelete.ToUpper())
        //            {
        //                prev = temp;
        //                temp = temp.GetNext();
        //            }

        //        }


        //        // If key was not present in linked list 
        //        if (temp == null)
        //        {
        //            return;
        //        }


        //        // Unlink the node from linked list 
        //        //prev.next = temp.next;
        //        prev.SetNext(temp.GetNext());


        //        currentmarina = convertMarinaToList();
        //        fp.writeToFile(true,currentmarina);
        //        listAllBoats();
        //    }
        //    catch (Exception ex)
        //    {

        //        DisplayManager.displayMessage(ex.Message);
        //    }

        //}
        public  void listAllBoats()
        {
            //clear marina
            ClearAllMarinaItems();
            //load from file 
            if (this.Count<1)
            {
                LoadDataFromFile();
            }
          
            //print
            string sb = string.Empty;
           sb= PrintElements();
            //get current marina length
            sb += "\n\n Current marina capacity :"+getCurrentCapacityMarinaLength().ToString();
            DisplayManager.displayMessage(sb);
        }
     
        public  int getCurrentCapacityMarinaLength()
        {

            int total = 0;
            try
            {
                BoatNode _current = head;
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
        public  List<string> convertMarinaToList()
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
        public  void addBoatToMarina(Factory.Boat _boat)
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

        private string PrintElements()
        {
            int result = 0;
            BoatNode currentBoat = this.head;
            StringBuilder sb = new StringBuilder();
            if (currentBoat!=null)
            {
                //print curent boat
                sb.Append(currentBoat.GetItemData().NameOfBoat).Append(",");
                sb.Append(currentBoat.GetItemData().NameOfOwner).Append(",");
                sb.Append(currentBoat.GetItemData().BoatDraft.ToString()).Append(",");
                sb.Append(currentBoat.GetItemData().BoatLength.ToString()).Append(",");
                string strBoatType = string.Empty;
                strBoatType = currentBoat.GetItemData().TypeofBoat.ToString();
                //sb.Append(current.GetItemData().strBoatType).Append(",");
                switch (strBoatType)
                {
                    case "MotorBoat":
                        Factory.MotorBoat MB = (Factory.MotorBoat)currentBoat.GetItemData();
                        sb.Append(MB.TypeofBoat).Append(",");
                        sb.Append(MB.DriveType).Append(",");
                        break;



                    case "NarrowBoat":
                        Factory.NarrowBoat NB = (Factory.NarrowBoat)currentBoat.GetItemData();
                        sb.Append(NB.TypeofBoat).Append(",");
                        sb.Append(NB.SternType).Append(",");

                        break;
                    case "Sailing":
                        Factory.SailingBoat SB = (Factory.SailingBoat)currentBoat.GetItemData();
                        sb.Append(SB.TypeofBoat).Append(",");
                        sb.Append(SB.SailingType).Append(",");

                        break;


                    default:
                        break;
                }
                //remove last index of ,
            }
            sb.AppendLine("");
            if (currentBoat.GetNext()!=null)
            {
                for (int i = 1; i < Count; i++)
                {
                    currentBoat = currentBoat.GetNext();
                    sb.Append(currentBoat.GetItemData().NameOfBoat).Append(",");
                    sb.Append(currentBoat.GetItemData().NameOfOwner).Append(",");
                    sb.Append(currentBoat.GetItemData().BoatDraft.ToString()).Append(",");
                    sb.Append(currentBoat.GetItemData().BoatLength.ToString()).Append(",");
                    string strBoatType = string.Empty;
                    strBoatType = currentBoat.GetItemData().TypeofBoat.ToString();
                    //sb.Append(current.GetItemData().strBoatType).Append(",");
                    switch (strBoatType)
                    {
                        case "MotorBoat":
                            Factory.MotorBoat MB = (Factory.MotorBoat)currentBoat.GetItemData();
                            sb.Append(MB.TypeofBoat).Append(",");
                            sb.Append(MB.DriveType).Append(",");
                            break;



                        case "NarrowBoat":
                            Factory.NarrowBoat NB = (Factory.NarrowBoat)currentBoat.GetItemData();
                            sb.Append(NB.TypeofBoat).Append(",");
                            sb.Append(NB.SternType).Append(",");

                            break;
                        case "Sailing":
                            Factory.SailingBoat SB = (Factory.SailingBoat)currentBoat.GetItemData();
                            sb.Append(SB.TypeofBoat).Append(",");
                            sb.Append(SB.SailingType).Append(",");

                            break;


                        default:
                            break;
                    }
                    sb.AppendLine("");
                }
            }

            return sb.ToString(); ;
        }
        //private    void AddToEnd(Factory.Boat x)
        //{
        //    //BoatNode current = marina.head;
        //    BoatNode current = head;


        //    if (current == null)
        //    {
        //        head = new BoatNode(x);
        //        head.SetNext(null);
        //    }           
        //    else
        //    {
        //        while (current.GetNext() != null)
        //        {
        //            current = current.GetNext();
        //        }


        //        // add new node at the end
        //        BoatNode toAppend = new BoatNode(x);
        //        current.SetNext(toAppend);
        //    }



        //}
        //private  string PrintElements()
        //{
        //    BoatNode current = head;
        //    StringBuilder sb = new StringBuilder();
        //    if (current==null)
        //    {
        //        // sb.AppendLine(current.GetItemData().NameOfBoat);
        //        sb.AppendLine("No Data in Marina");
        //    }
        //    else 
        //    {
        //        //sb.AppendLine(current.GetItemData().NameOfBoat);
        //        sb.Append(current.GetItemData().NameOfBoat).Append(",");
        //        sb.Append(current.GetItemData().NameOfOwner).Append(",");
        //        sb.Append(current.GetItemData().BoatDraft.ToString()).Append(",");
        //        sb.Append(current.GetItemData().BoatLength.ToString()).Append(",");
        //        string strBoatType = string.Empty;
        //        strBoatType = current.GetItemData().TypeofBoat.ToString();
        //        //sb.Append(current.GetItemData().strBoatType).Append(",");
        //        switch (strBoatType)
        //        {
        //            case "MotorBoat":
        //                Factory.MotorBoat MB = (Factory.MotorBoat)current.GetItemData();
        //                sb.Append(MB.TypeofBoat).Append(",");
        //                sb.Append(MB.DriveType).Append(",");
        //                break;



        //            case "NarrowBoat":
        //                Factory.NarrowBoat NB = (Factory.NarrowBoat)current.GetItemData();
        //                sb.Append(NB.TypeofBoat).Append(",");
        //                sb.Append(NB.SternType).Append(",");

        //                break;
        //            case "Sailing":
        //                Factory.SailingBoat SB = (Factory.SailingBoat)current.GetItemData();
        //                sb.Append(SB.TypeofBoat).Append(",");
        //                sb.Append(SB.SailingType).Append(",");

        //                break;


        //            default:
        //                break;
        //        }
        //        sb.AppendLine("");
        //        while (current.GetNext() != null)
        //        {
        //            current = current.GetNext();
        //            sb.Append(current.GetItemData().NameOfBoat).Append(",");
        //            sb.Append(current.GetItemData().NameOfOwner).Append(",");
        //            sb.Append(current.GetItemData().BoatDraft.ToString()).Append(",");
        //             sb.Append(current.GetItemData().BoatLength.ToString()).Append(",");
        //              strBoatType = string.Empty;
        //            strBoatType = current.GetItemData().TypeofBoat.ToString();
        //            //sb.Append(current.GetItemData().strBoatType).Append(",");
        //            switch (strBoatType)
        //            {
        //                case "MotorBoat":
        //                    Factory.MotorBoat MB = (Factory.MotorBoat)current.GetItemData();
        //                    sb.Append(MB.TypeofBoat).Append(",");
        //                    sb.Append(MB.DriveType).Append(",");
        //                    break;



        //                case "NarrowBoat":
        //                    Factory.NarrowBoat NB = (Factory.NarrowBoat)current.GetItemData();
        //                    sb.Append(NB.TypeofBoat).Append(",");
        //                    sb.Append(NB.SternType).Append(",");

        //                    break;
        //                case "Sailing":
        //                    Factory.SailingBoat SB = (Factory.SailingBoat)current.GetItemData();
        //                    sb.Append(SB.TypeofBoat).Append(",");
        //                    sb.Append(SB.SailingType).Append(",");

        //                    break;


        //                default:
        //                    break;
        //            }
        //           // sb.Append(current.GetItemData().BoatLength.ToString());
        //            sb.AppendLine("");
        //        }
        //    }




        //    //add current marina capacity
        //    string strMarina = "The current marina capacity is:";
        //    int currentMarinaCapacity = 0;
        //    currentMarinaCapacity = getCurrentCapacityMarinaLength();
        //    strMarina += currentMarinaCapacity.ToString();
        //    sb.AppendLine("\n\n"+strMarina);
        //    return sb.ToString();


        //}
        public   void LoadDataFromFile()
        {
          // Marina marina = new Software_Implementation_Project.Marina();
           
            try
            {

                FileOperations fileOps = new Software_Implementation_Project.FileOperations();
                BoatFactory = new Factory.BoatFactory();
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
                                boat = Factory.BoatFactory.BuildBoat(strBoatType);

                                //Factory.NarrowBoat NB =(Factory.NarrowBoat)BoatFactory.BuildBoat(strBoatType);
                                boat = Factory.BoatFactory.BuildBoat(strBoatType);
                                Factory.NarrowBoat NB = (Factory.NarrowBoat)boat;
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
                                //boat = BoatFactory.BuildBoat(3);
                                boat = Factory.BoatFactory.BuildBoat(strBoatType);
                                Factory.SailingBoat SB = (Factory.SailingBoat)boat;
                              //  Factory.SailingBoat SB = (Factory.SailingBoat)(BoatFactory.BuildBoat(strBoatType));
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
                                //  boat = BoatFactory.BuildBoat(strBoatType);
                                // Factory.MotorBoat MB = (Factory.MotorBoat)(BoatFactory.BuildBoat(strBoatType));
                                boat = Factory.BoatFactory.BuildBoat(strBoatType);
                                Factory.MotorBoat MB = (Factory.MotorBoat)boat;
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
