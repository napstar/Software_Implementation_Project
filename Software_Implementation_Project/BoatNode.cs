using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Implementation_Project
{
    public class BoatNode
    {
        /*
         * https://stackoverflow.com/questions/5236486/adding-items-to-end-of-linked-list
         */
        private Factory.Boat data;
        private BoatNode next;
         
        public BoatNode(Factory.Boat d)
        {
            data = d;
            next = null;
        }
        public BoatNode(Factory.Boat d,BoatNode nextBoat)
        {
            data = d;
            next = nextBoat;
        }
        
        public BoatNode()
        {
        }

        public Factory.Boat GetItemData()
        {
            return data;
        }

        public BoatNode GetNext()
        {
            return next;
        }

        public void SetNext(BoatNode toAppend)
        {
            this.next = toAppend;
        }
        
        public void ClearData(BoatNode toAppend)
        {
           
            toAppend.data = null;
           // toAppend.next = null;
        }
    }
}
