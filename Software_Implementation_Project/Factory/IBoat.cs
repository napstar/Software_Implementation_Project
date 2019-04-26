using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Implementation_Project.Factory
{
    public interface IBoat
    {
            string name_of_owner { get; set; }
            string name_of_boat { get; set; }
            string type_of_boat { get; set; }
            int boat_length { get; set; }
            int boat_draft { get; set; }
        IBoat GetBoat();
        int GetEnumLength();

    }
}
