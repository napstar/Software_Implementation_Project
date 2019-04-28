using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Implementation_Project.Factory
{
    public class BoatFactory
    {
        public int BuildBoatSubTypes(int boatType)
        {
            int subType = 0;
            subType = DisplayManager.getBoatSubTypes(boatType);
            return subType;
        }
        public int BuildBoatSubTypes(string strBoatType)
        {
            int subType = 0;
            try
            {
                int.TryParse(strBoatType, out subType);
                subType = DisplayManager.getBoatSubTypes(subType);
            }
            catch (Exception ex)
            {

                throw;
            }
            
            
            return subType;
        }
        public  Boat BuildBoat(int type)
        {
            int subType = 0;
            switch (type)
            {
                case 1:
                    
                    MotorBoat MB = new MotorBoat("MotorBoat");
                     
                    return MB;
                case 2:
                     
                    NarrowBoat NB = new NarrowBoat("NarrowBoat");
                    return NB;
                case 3:
                     
                    SailingBoat SB = new SailingBoat("Sailing");
                    return SB;
               
                  
                default:
                    return null;

            }
        }
        public static Boat BuildBoat(string  strBoatype)
        {
          
            try
            {
                 
                switch (strBoatype)
                {
                    case "MotorBoat":

                        MotorBoat MB = new MotorBoat("MotorBoat");

                        return MB;
                    case "NarrowBoat":

                        NarrowBoat NB = new NarrowBoat("NarrowBoat");
                        return NB;
                    case "Sailing":

                        SailingBoat SB = new SailingBoat("Sailing");
                        return SB;


                    default:
                        return null;

                }
            }
            catch (Exception ex)
            {

                throw;
            }

             
        }
    }
}
