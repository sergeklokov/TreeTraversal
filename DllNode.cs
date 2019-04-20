using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeTraversal
{
    // Doubly Linked List Node
    public class DllNode
    {
        public int item;
        public DllNode prev;
        public DllNode next;
        public DllNode(int item)
        {
            this.item = item;
            prev = null;
            next = null;
        }
    }
}
