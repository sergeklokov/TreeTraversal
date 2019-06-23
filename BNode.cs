using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeTraversal
{
    // Binary Tree Node
    public class Node
    {
        public int item;

        public Node left;
        public Node right;

        public Node(int item)
        {
            this.item = item;
            left = right = null;
        }
    }

    // helper class to print Binary Tree
    public class NodeInfo
    {
        public Node node;
        public string Text;
        public int StartPos;
        public int Size { get { return Text.Length; } }
        public int EndPos
        {
            get {  return StartPos + Size; }
            set { StartPos = value - Size; }
        }
        public NodeInfo Parent, Left, Right;
    }
}
