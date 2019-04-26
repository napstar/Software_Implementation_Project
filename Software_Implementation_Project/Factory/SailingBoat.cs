using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Implementation_Project.Factory
{
    class SailingBoat : Boat
    {
        
        private string sailingType;

        public SailingBoat(string typeParam)
        {
            this.TypeofBoat = typeParam;
        }
        public SailingBoat(string typeParam,int sailingTypeParam)
        {
            this.TypeofBoat = typeParam;
            this.SailingType = Enum.GetName(typeof(sailingTypes), sailingTypeParam); ;
        }
        public SailingBoat()
        {
        }
        

        
        enum sailingTypes
        {
            Ketch = 1,
            Cutter = 2,
            Junk=3
        }
       

        public string SailingType
        {
            get
            {
                return sailingType;
            }

            set
            {
                 
                if (Enum.IsDefined(typeof(sailingTypes), value))
                {

                    this.sailingType = value; ;
                }
                else
                {
                    throw new Exception("Invalid Stern Type");
                }
            }
        }

        

        public   void showDetails()
        {
            BoatHelperClass.showDetails(this);
        }

        public override Boat GetBoat()
        {
            SailingBoat SB = new Factory.SailingBoat();

            return SB;
        }

        public override int GetEnumLength()
        {
            return Enum.GetNames(typeof(sailingTypes)).Length;
        }
        public override string GetEnumNameFromValue(int enumValue)
        {
            sailingTypes enumDisplayStatus = (sailingTypes)enumValue;
            string stringValue = enumDisplayStatus.ToString();
            return stringValue;
        }


    }
}
