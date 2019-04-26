using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Software_Implementation_Project
{
    public class Boat_old
    {
        private string Name_Of_Owner, Name_Of_Boat, type_Of_Boat;
        private int Boat_Length;

        public Boat_old()
        {

        }
        public string name_of_owner
        {
            get
            {
                return Name_Of_Owner;
            }

            set
            {
                Name_Of_Owner = value;
            }
        }

        public string name_of_boat
        {
            get
            {
                return Name_Of_Boat;
            }

            set
            {
                Name_Of_Boat = value;
            }
        }

        public string type_of_boat
        {
            get
            {
                return type_of_boat;
            }

            set
            {
                type_of_boat = value;
            }
        }

        public int boat_length
        {
            get
            {
                return boat_length;
            }

            set
            {
                boat_length = value;
            }
        }

        public void showObjectDetails(Boat_old boat)
        {
            Type type = typeof(Boat_old);
            string details = string.Empty;
            Dictionary<string, object> properties = new Dictionary<string, object>();
            foreach (PropertyInfo prop in type.GetProperties())
            {
                properties.Add(prop.Name, prop.GetValue(boat));
            }
           
            foreach (KeyValuePair<string, object> item in properties)
            {
                details += string.Format(" {0}= {1}", item.Key, item.Value) + "\n";
            }
            Console.WriteLine(details);
        }
    }
}
