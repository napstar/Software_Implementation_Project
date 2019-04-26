using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Implementation_Project.Factory
{
    class MotorBoat : Boat
    {

        private string driveType;
        public MotorBoat()
        {
           

        }
        public MotorBoat(string Param)
        {
            this.TypeofBoat = Param;

        }
        public MotorBoat(string boatTypeParam, int driveTypeParam)
        {
            this.TypeofBoat = boatTypeParam;
            this.DriveType = Enum.GetName(typeof(driveTypeEnum), driveTypeParam);
        }
        public string DriveType
        {
            get
            {
                return driveType;
            }

            set
            {
                driveType = value;
            }
        }

       

       
        enum driveTypeEnum
        {
            InboardDrives = 1,
            OutboardMotors = 2
        }
        

       
        public string getDriveTypeFromEnum(int driveTypeParam)
        {
            string strDriveType = string.Empty;
            if (Enum.IsDefined(typeof(driveTypeEnum), driveTypeParam))
            {
                strDriveType = Enum.GetName(typeof(driveTypeEnum), driveTypeParam);
                
            }
            else
            {
                throw new Exception("Invalid Drive Type");
            }
            return strDriveType;
        }
        public   void showDetails()
        {
            BoatHelperClass.showDetails(this);
        }

        public override Boat GetBoat()
        {
            MotorBoat MB = new Factory.MotorBoat();

            return MB;
        }

        public override int GetEnumLength()
        {
            return Enum.GetNames(typeof(driveTypeEnum)).Length;
        }

        public override string GetEnumNameFromValue(int enumValue)
        {
            driveTypeEnum enumDisplayStatus = (driveTypeEnum)enumValue;
            string stringValue = enumDisplayStatus.ToString();
            return stringValue;
        }
    }
}
