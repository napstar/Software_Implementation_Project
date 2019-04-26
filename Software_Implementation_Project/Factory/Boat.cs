using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Implementation_Project.Factory
{
    public   abstract class Boat 
    {
        string type_of_boat;
        string name_of_owner;
        string name_of_boat;
        int boat_length;
        int boat_draft;
        public   string NameOfOwner { get { return name_of_owner; } set { name_of_owner=value; } }
        public string NameOfBoat { get { return name_of_boat; } set { name_of_boat=value; } }
        public   string TypeofBoat { get { return type_of_boat; } set { type_of_boat = value; } }
        public   int BoatLength { get { return boat_length; } set { boat_length = value; } }
        public   int BoatDraft { get { return boat_draft; } set { boat_draft = value; } }
        public abstract Boat GetBoat();

        public abstract int GetEnumLength();
        public  abstract string GetEnumNameFromValue(int enumValue);
         
    }
}
