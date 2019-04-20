using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeTraversal
{
    class BinaryTree
    {
        // Root ot the Binary Tree
        public BNode root;
        public static bool v1 = false;
        public static bool v2 = false;

        // Lowest Common Ancestor (LCA)
        // This function returns pointer to LCA of two given
        // values n1 and n2.
        //
        // v1 is set as true by this function if n1 is found
        // v2 is set as true by this Function if n2 is found
        public virtual BNode findLCAUtil(BNode node, int n1, int n2)
        {
            // Base case
            if (node == null)
                return null;

            //Store result in temp, in case of key match so that we can search for other key also.
            BNode temp = null;

            // If either n1 or n2 matches with root's key, report the presence
            // by setting v1 or v2 as true and return root (Note that if a key
            // is ancestor of other, then the ancestor key becomes LCA)
            if (node.item == n1)
            {
                v1 = true;
                temp = node;
            }

            if (node.item == n2)
            {
                v2 = true;
                temp = node;
            }

            // Look for keys in left and right subtrees
            BNode left_lca = findLCAUtil(node.left, n1, n2);
            BNode right_lca = findLCAUtil(node.right, n1, n2);

            if (temp != null)
                return temp;

            // IF both of the above calls return Non—NULL, then one key
            // is present in once subtree and other is present in other,
            // So this node is the LCA
            if (left_lca != null && right_lca != null)
                return node;

            // Otherwise check if left subtree or right subtree is LCA
            return (left_lca != null) ? left_lca : right_lca;
        }

        // Finds lca of n1 and n2 under the subtree rooted with ‘node’
        public virtual BNode findLCA(int n1, int n2)
        {
            // Initialize n1 and n2 as not visited
            v1 = false;
            v2 = false;

            // Find lca of n1 and n2 using the technique discussed above
            BNode lca = findLCAUtil(root, n1, n2);

            // Return LCA only if both n1 and n2 are present in tree
            if (v1 && v2)
                return lca;

            return null;
        }

        // how to print binary tree in console: 
        // https://stackoverflow.com/questions/36311991/c-sharp—display-a—binary—search-tree—in-console/36313190

        public void Print(BNode root, string textFormat = "0", int spacing = 1, int topMargin = 2, int leftMargin = 2)
        {
            if (root == null) return;
            int rootTop = Console.CursorTop + topMargin;
            var last = new List<BNodeInfo>();
            var next = root;
            for (int level = 0; next != null; level++)
            {
                var item = new BNodeInfo
                {
                    node = next,
                    Text = next.item.ToString(textFormat)
                };

                if (level < last.Count)
                {
                    item.StartPos = last[level].EndPos + spacing;
                    last[level] = item;
                }
                else
                {
                    item.StartPos = leftMargin;
                    last.Add(item);
                }

                if (level > 0)
                {
                    item.Parent = last[level - 1];
                    if (next == item.Parent.node.left)
                    {
                        item.Parent.Left = item;
                        item.EndPos = Math.Max(item.EndPos, item.Parent.StartPos - 1);
                    }
                    else
                    {
                        item.Parent.Right = item;
                        item.StartPos = Math.Max(item.StartPos, item.Parent.EndPos + 1);
                    }
                }

                next = next.left ?? next.right;

                for (; next == null; item = item.Parent)
                {
                    int top = rootTop + 2 * level;
                    Print(item.Text, top, item.StartPos);

                    if (item.Left != null)
                    {
                        Print("/", top + 1, item.Left.EndPos);
                        Print("_", top, item.Left.EndPos + 1, item.StartPos);
                    }
                    if (item.Right != null)
                    {
                        Print("_", top, item.EndPos, item.Right.StartPos - 1);
                        Print("\\", top + 1, item.Right.StartPos - 1);
                    }

                    if (--level < 0) break;

                    if (item == item.Parent.Left)
                    {
                        item.Parent.StartPos = item.EndPos + 1;
                        next = item.Parent.node.right;
                    }
                    else
                    {
                        if (item.Parent.Left == null)
                            item.Parent.EndPos = item.StartPos - 1;
                        else
                            item.Parent.StartPos += (item.StartPos - 1 - item.Parent.EndPos) / 2;
                    }
                }
            }

            Console.SetCursorPosition(0, rootTop + 2 * last.Count - 1);
        }

        public void Print(string s, int top, int left, int right = -1)
        {
            Console.SetCursorPosition(left, top);
            if (right < 0) right = left + s.Length;
            while (Console.CursorLeft < right) Console.Write(s);
        }

        // Traverse binary tree inorder
        public void PrintInorder(BNode node)
        {
            if (node == null)
                return;

            PrintInorder(node.left); /* first recur on left child */

            Console.Write(node.item + " "); /* then print the data of node */

            PrintInorder(node.right); /* now recur on right child */
        }

        public void ConvertBTreeToDllInorder(BNode node, DoubleLinkedList dllTree)
        {
            if (node == null)
                return;

            ConvertBTreeToDllInorder(node.left, dllTree); /* first recur on left child */

            var dllNode = new DllNode(node.item);
            dllTree.AddNode(dllNode);

            ConvertBTreeToDllInorder(node.right, dllTree);  // now recur on right child
        }
    }
}
