using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeTraversal
{
    // Binary Tree Node
    public class BNode
    {
        public int item;

        public BNode left;
        public BNode right;

        public BNode(int item)
        {
            this.item = item;
            left = null;
            right = null;
        }
    }

    // helper class to print Binary Tree
    public class BNodeInfo
    {
        public BNode node;
        public string Text;
        public int StartPos;
        public int Size { get { return Text.Length; } }
        public int EndPos
        {
            get {  return StartPos + Size; }
            set { StartPos = value - Size; }
        }
        public BNodeInfo Parent, Left, Right;
    }
}
