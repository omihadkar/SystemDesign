using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Trees
{
    /// <summary>
    /// Tree with single node is having height as 0. For next level height is 1.
    /// </summary>
    class FindHeightOfBST
    {       

        static void Main(string[] args)
        {
            FindHeightOfBST a = new FindHeightOfBST();
            Node root = new Node();
            root = a.createNewNode(12);
            root.Left = a.createNewNode(4);
            root.Left.Left = a.createNewNode(15);
            root.Left.Right = a.createNewNode(10);
            root.Left.Right.Right = a.createNewNode(11);
            root.Right = a.createNewNode(20);
            root.Right.Right = a.createNewNode(23);
            root.Right.Right.Right = a.createNewNode(24);
            root.Right.Right.Right.Right = a.createNewNode(24);
            root.Right.Left = a.createNewNode(20);
           var result= a.CalculateHeight(root);
            Console.WriteLine("Height of BST is "+result);
            Console.ReadKey();
        }

        int CalculateHeight(Node node)
        {
            if (node==null)
            {
               return -1;
            }
            
            //This clause we can remove since we are handling null case of node above.
            if (ifLeafNode(node))
            {            
                return 0;
            }

            return maxOfNodes(CalculateHeight(node.Left), CalculateHeight(node.Right)) + 1;
        }

        private int maxOfNodes(int v1, int v2)
        {
            return v1 > v2 ? v1 : v2;
        }

        public Node createNewNode(int val)
        {
            Node newNode = new Node();
            newNode.Data = val;
            newNode.Left = null;
            newNode.Right = null;
            return newNode;
        }

        private bool ifLeafNode(Node node)
        {
            if (node.Left == null && node.Right == null)
            {
                return true;
            }
            return false;
        }
    }
}
