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
        private BoatNode head;
        public BoatNode(Factory.Boat d)
        {
            data = d;
            next = null;
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
            next = toAppend;
        }
        public void SetFirst(BoatNode toAppend)
        {
            head = toAppend;
            next = null;
        }
    }
}
