using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeTraversal
{
    class Program
    {
        // various Tree Traversals demo
        // by Serge Klokov
        //
        // c# implementation of operations with binary tree
        // and with ..
        //
        // find lowest common ancestor of
        // n1 and n2 using one traversal of binary tree
        // It also handles cases even when n1 and n2 are not there in Tree

        //
        //      1
        //   2    3
        // 4  5  6  7
        //

        static void Main(string[] args)
        {
            // populate tree
            var bTreee = new BinaryTree();
            PopulateBinaryTreeWithValues(bTreee);

            bTreee.Print(bTreee.root);
            Console.WriteLine();

            Console.WriteLine("Max depth of a tree: " + bTreee.maxDepth(bTreee.root));
            Console.WriteLine();

            Console.WriteLine("Lowest Common Ancestor - LCA");
            Node lca = bTreee.findLCA(6, 7);
            if (lca != null)
            {
                Console.WriteLine("LCA(6,7) = " + lca.item);
                Console.WriteLine("Max depth of node {0} = {1}", lca.item, bTreee.maxDepth(lca));
            }
            else
            {
                Console.WriteLine("LCA(4,5) not present");
            }
            Console.WriteLine();

            lca = bTreee.findLCA(4, 5);
            if (lca != null)
            {
                Console.WriteLine("LCA(4,5) = " + lca.item);
                Console.WriteLine("Max depth of node {0} = {1}", lca.item, bTreee.maxDepth(lca));
            }
            else
            {
                Console.WriteLine("LCA(4,5) not present");
            }
            Console.WriteLine();

            lca = bTreee.findLCA(4, 10);
            if (lca != null)
                Console.WriteLine("LCA(4,10) = " + lca.item);
            else
                Console.WriteLine("LCA(4,10) not present");
            Console.WriteLine();

            Console.WriteLine("Print inorder");
            bTreee.PrintInorder(bTreee.root);
            Console.WriteLine(System.Environment.NewLine);

            var dll = new DoubleLinkedList();
            PopulateDoubleLinkedListWValues(dll);
            Console.Write("Simple Doubly Linked List: ");
            dll.Print(dll.root);
            Console.WriteLine();

            Console.WriteLine("Print Binary Tree converted (Inorder) to Double Linked List");
            var dll2 = new DoubleLinkedList();
            bTreee.ConvertBTreeToDllInorder(bTreee.root, dll2);
            dll2.Print(dll2.root);

            Console.WriteLine("Press any key..");
            Console.ReadKey();
        }

        private static void PopulateDoubleLinkedListWValues(DoubleLinkedList dllTree)
        {
            dllTree.AddNode(new DllNode(1)); // first "root"
            dllTree.AddNode(new DllNode(2));
            dllTree.AddNode(new DllNode(3));
            dllTree.AddNode(new DllNode(4));
        }

        private static void PopulateBinaryTreeWithValues(BinaryTree tree)
        {
            tree.root = new Node(1);

            tree.root.left = new Node(2);
            tree.root.left.left = new Node(4);
            tree.root.left.right = new Node(5);

            tree.root.right = new Node(3);
            tree.root.right.left = new Node(6);
            tree.root.right.right = new Node(7);

            tree.root.left.left.left = new Node(8);
            tree.root.left.right.left = new Node(9);
            tree.root.left.right.left = new Node(10);
        }
    }
}
