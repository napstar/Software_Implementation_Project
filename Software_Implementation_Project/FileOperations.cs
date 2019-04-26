using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Implementation_Project
{
    class FileOperations
    {
        string path = @"C:\Users\Napstar\Documents\Visual Studio 2015\Projects\testmenu\testmenu\data.csv";
        public void writeToFile(bool update, List<string> data)
        {
            try
            {
                
                    //this an append
                    var result = string.Join(",", data);
                    //foreach (string item in data)
                    //{
                    //     System.IO.File.AppendAllText(path, item + Environment.NewLine);
                    //}
                    if (!File.Exists(path))
                    {
                       File.WriteAllLines(path, data);
                    }
                    else
                    {
                    //foreach (string item in data)
                    //{
                    //    File.AppendAllText(path, item);
                    //}
                    using (StreamWriter outputFile = new StreamWriter(path))
                    {
                        foreach (string line in data)
                        {
                            outputFile.WriteLine(line);
                        }
                            
                    }

                }
                    

                
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
        public void deleteFromFile(string strBoatName)
        {
            try
            {
             
                FileStream f = File.Open(path, FileMode.Open);
                TextReader reader = new StreamReader(f);
                string Row = string.Empty;
                List<string> strDataReturned = new List<string>();
                while ((Row = reader.ReadLine()) != null)
                {
                    //remove the commas from row of data
                    //split array at commas and put result into an array
                    string[] arrSplitRow = Row.Split(",".ToCharArray());
                    //convert the array to a string 
                    string result = String.Join(" ", arrSplitRow);
                    strDataReturned.Add(result);
                }
                reader.Close();
                f.Close();
                //iterate through the data remeove boat fromfile data
                for (int i = 0; i < strDataReturned.Count; i++)
                {
                    //get the first element in the list
                    string str = strDataReturned[i];
                    //data is delimeted by space,find the 1st occurance 
                    int index = str.IndexOf(' ');
                    //substring to get data,start at 0 and end  
                    //at the first index of the occurance of space
                    string strSubStr = str.Substring(0, str.IndexOf(" "));
                    //if the string matches boatname parameter remove from list
                    if (strSubStr == strBoatName)
                    {
                        strDataReturned.RemoveAt(i);
                    }

                }

                //add back the commas,and write that data
                List<string> r = new List<string>();
                for (int i = 0; i < strDataReturned.Count; i++)
                {
                    // var result = string.Join(",", item);
                    string[] arrSplitRow = strDataReturned[i].Split(" ".ToCharArray());
                    //convert the array to a string 
                    string result = String.Join(",", arrSplitRow);
                    r.Add(result);
                }

                writeToFile(false, r);
            }
            catch (Exception ex)
            {

                throw;
            }
           

        }

        public List<string> readDataFromFile()
        {
            List<string> strDataReturned = new List<string>();
            try
            {
                FileStream f = File.Open(path, FileMode.Open);
                TextReader reader = new StreamReader(f);
                string Row = string.Empty;
              
                while ((Row = reader.ReadLine()) != null)
                {
                    //remove the commas from row of data
                    //split array at commas and put result into an array
                    string[] arrSplitRow = Row.Split(",".ToCharArray());
                    //convert the array to a string 
                    string strResult = String.Join(",", arrSplitRow);
                    strDataReturned.Add(strResult);
                }
                reader.Close();
                f.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
            
            return strDataReturned;
        }

        public void displayAllRecords()
        {
            int spaceInUse = 0;

            try
            {
                //read data from file
                List<string> fileData = new List<string>();
                fileData = this.readDataFromFile();
                if (fileData.Count >= 1)
                {
                    for (int i = 0; i < fileData.Count; i++)
                    {
                        string currentRow = fileData[i];

                        Console.WriteLine(currentRow);
                        //length is the last item in string
                        //find the last occurance of " " in string
                        int index = currentRow.LastIndexOf(" ");
                        string strBoatLen = currentRow.Substring(index, currentRow.Length - index).Trim();
                        if (strBoatLen.Length>0)
                        {
                            int currentBoatLen = 0;
                            try
                            {
                                int.TryParse(strBoatLen, out currentBoatLen);
                                spaceInUse += currentBoatLen;
                            }
                            catch (Exception ex)
                            {

                                throw ex;
                            }
                        }
                    }

                    //print available space
                    Console.WriteLine("\nCurrent Available Space:   {0}",spaceInUse.ToString());
                }
            }
            catch (Exception ex )
            {

                throw ex;
            }
            

          
        }


    }
}
