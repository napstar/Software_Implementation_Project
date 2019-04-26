using Software_Implementation_Project.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Implementation_Project
{ /* this class functions are the Node the object to be inserted in to the Marina Linked List object
         * https://codereview.stackexchange.com/questions/158704/queue-implementation-using-linked-list
         * https://social.technet.microsoft.com/wiki/contents/articles/51479.c-implementation-of-stack-and-queue-using-linked-list.aspx
         * https://stackoverflow.com/questions/5236486/adding-items-to-end-of-linked-list
        */
    public class Node_old
    {
        public IBoat Data;
        public Node_old Next;
        public Node_old(IBoat data)
        {
            Data = data;
        }
    }

    public class Queue
    {
        private Node_old _head;
        private Node_old _tail;
        private int _count = 0;
        public Queue()
        {
        }
        public void Enqueue(IBoat data)
        {
            Node_old _newNode = new Node_old(data);
            if (_head == null)
            {
                _head = _newNode;
                _tail = _head;
            }
            else
            {
                _tail.Next = _newNode;
                _tail = _tail.Next;
            }
            _count++;
        }
        public IBoat Dequeue()
        {
            IBoat _result = null;
            if (_head == null)
            {
                throw new Exception("Queue is Empty");
            }
            _result = _head.Data;
            _head = _head.Next;
            return _result;
        }
        public int Count
        {
            get
            {
                return this._count;
            }
        }
        public void  addToLast(IBoat data_param,Node_old nodeObj)
        {
            Node_old _newNode = new Node_old(data_param);
            if (_head == null)
            {
                _head = _newNode;
                _tail = _head;
            }
            else
            {
                while (_newNode.g)
                {

                }
            }
        }
        public Node_old GetNext()
        {
            return _tail;
        }
        public string PrintElements()
        {
            var node = _head;
            string[] elements = new string[_count];
            int i = 0;
            if (node != null)
            {
                while (node != null)
                {
                    elements[i++] = node.Data.name_of_boat;
                    node = node.Next;
                }
                return string.Join(" ", elements);
            }

            return ("No Data");
        }
    }
}
