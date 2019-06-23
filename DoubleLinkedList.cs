using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeTraversal
{
    // Doubly Linked List (not a tree really)
    public class DoubleLinkedList
    {
        public DllNode root;

        public void AddNode(DllNode node)
        {
            if (root == null)
                root = node;
            else
            {
                var lastNode = FindLastNode(root);
                lastNode.next = node;
                node.prev = lastNode;
            }
        }

        private DllNode FindLastNode(DllNode node)
        {
            if (node.next != null)
                return FindLastNode(node.next);
            else
                return node;
        }

        internal void Print(DllNode node)
        {
            if (node == null)
            {
                Console.WriteLine(" Done.");
                return;
            }

            Console.Write(node.item + " ");
            Print(node.next);
        }
    }
}