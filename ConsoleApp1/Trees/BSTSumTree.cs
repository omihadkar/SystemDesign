using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Trees
{
    class BSTSumTree
    {
        int sum = 0;

        static void Main(string[] args)
        {
            BSTSumTree a = new BSTSumTree();

            Node root = new Node();
            root = a.createNewNode(120);
            root.Left = a.createNewNode(40);
            root.Left.Left = a.createNewNode(15);
            //root.Left.Left.Left = a.createNewNode(5);
            root.Left.Right = a.createNewNode(25);
            root.Right = a.createNewNode(20);
            root.Right.Right = a.createNewNode(20);

            var result= a.IsSumTree(root.Left);
            result+= a.IsSumTree(root.Right);
            if (root.Data==result)
            {
                Console.WriteLine("This is sum tree");
            }
            else
            {
                Console.WriteLine("This is not sum tree.");
            }

            if (a.IsSumTreeOptimized(root))
            {
                Console.WriteLine("This is sum tree");
            }
            else
            {
                Console.WriteLine("This is not sum tree.");
            }

            Console.ReadKey();
        }

        
        public Node createNewNode(int val)
        {
            Node newNode = new Node();
            newNode.Data = val;
            newNode.Left = null;
            newNode.Right = null;
            return newNode;
        }

        /// <summary>
        /// o(n-square) complexity
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        int IsSumTree(Node node)
        {
            if (node==null)
            {
                return 0;
            }

            if (ifLeafNode(node))
            {
                return node.Data;
            }

            sum = node.Data;

            sum += IsSumTree(node.Left);
            sum += IsSumTree(node.Right);

            return sum;
        }

        /// <summary>
        /// O(N) complexity. In some cases this solution doesn't work. Not sure.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        bool IsSumTreeOptimized(Node node)
        {
            if (node==null || ifLeafNode(node))
            {
                return true;
            }

            int leftSum = 0;
            int rightSum = 0;

            if (IsSumTreeOptimized(node.Left) && IsSumTreeOptimized(node.Right))
            {
                
                if (node.Left==null)
                {
                    leftSum = 0;
                }
                else if (ifLeafNode(node.Left))
                {
                    leftSum = node.Left.Data;
                }
                else
                {
                    leftSum = 2 * node.Left.Data;
                }

                if (node.Right == null)
                {
                    rightSum = 0;
                }
                else if (ifLeafNode(node.Right))
                {
                    rightSum = node.Right.Data;
                }
                else
                {
                    rightSum = 2 * node.Right.Data;
                }

                if (node.Data==leftSum+rightSum)
                {
                    return true;
                }                
            }
            return false;
        }

        private bool ifLeafNode(Node node)
        {
            if (node.Left==null && node.Right==null)
            {
                return true;
            }
            return false;
        }
    }
}
