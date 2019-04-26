using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Implementation_Project.Factory
{
    public class NarrowBoat : Boat 
    {
        
        //traditional stern, cruiser stern and semi-traditional stern.
        private string sternType;
        string enumValue = string.Empty;
        public NarrowBoat()
        {
        }

        enum SternTypes
        {
            traditionalstern=1,
            cruiserstern=2,
            semi_traditional_stern=3
        }
       
        public NarrowBoat(string boatTypeParam):base()
        {
            this.TypeofBoat = boatTypeParam;
        }
        public NarrowBoat(string boatTypeParam,int sternTypeParam) : base()
        {
            this.TypeofBoat = boatTypeParam;
            this.SternType = Enum.GetName(typeof(SternTypes), sternTypeParam); ;
        }
       
        

        public string SternType
        {
            get
            {
                return sternType;
            }

            set
            {
                sternType = value;
                if (Enum.IsDefined(typeof(SternTypes), value))
                {

                    this.sternType = value; ;
                }
                else
                {
                    throw new Exception("Invalid Stern Type");
                }
            }
        }

       

        public  void showDetails()
        {
            BoatHelperClass.showDetails(this);
        }

        public override Boat GetBoat()
        {
            NarrowBoat NB = new Factory.NarrowBoat();
            return NB;
        }

        public override int GetEnumLength()
        {
            return Enum.GetNames(typeof(SternTypes)).Length;
        }

        public override string GetEnumNameFromValue(int enumValue)
        {
            SternTypes enumDisplayStatus = (SternTypes)enumValue;
            string stringValue = enumDisplayStatus.ToString();
            return stringValue;
        }
    }
}
