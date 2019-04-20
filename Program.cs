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
            BinaryTree tree = new BinaryTree();
            PopulateBinaryTreeWithValues(tree);

            tree.Print(tree.root);

            Console.WriteLine();

            BNode lca = tree.findLCA(4, 5);
            if (lca != null)
                Console.WriteLine("LCA(4,5) = " + lca.item);
            else
                Console.WriteLine("LCA(4,5) not present");

            lca = tree.findLCA(4, 10);
            if (lca != null)
                Console.WriteLine("LCA(4,10) = " + lca.item);
            else
                Console.WriteLine("LCA(4,10) not present");

            Console.WriteLine();
            Console.WriteLine("Print inorder");
            tree.PrintInorder(tree.root);

            var dll = new DoubleLinkedList();
            PopulateDoubleLinkedListWValues(dll);
            dll.Print(dll.root);

            Console.WriteLine();
            Console.WriteLine("Print Binary Tree converted (Inorder) to Double Linked List");
            var dll2 = new DoubleLinkedList();
            tree.ConvertBTreeToDllInorder(tree.root, dll2);
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
            tree.root = new BNode(1);

            tree.root.left = new BNode(2);
            tree.root.left.left = new BNode(4);
            tree.root.left.right = new BNode(5);

            tree.root.right = new BNode(3);
            tree.root.right.left = new BNode(6);
            tree.root.right.right = new BNode(7);

            tree.root.left.left.left = new BNode(8);
            tree.root.left.right.left = new BNode(9);
            tree.root.left.right.left = new BNode(10);
        }
    }
}
