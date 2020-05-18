using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Trees
{
    class SumOfLeafNodes
    {
        static int sum;

        static void Main(string[] args)
        {
            SumOfLeafNodes a = new SumOfLeafNodes();
            Node root = new Node();
            root = a.createNewNode(120);
            root.Left = a.createNewNode(40);
            root.Left.Left = a.createNewNode(15);

            root.Left.Right = a.createNewNode(25);
            root.Right = a.createNewNode(20);
            root.Right.Right = a.createNewNode(20);

            a.CalculateLeafNodeSum(root);
            Console.WriteLine("Sum of leaf node is "+sum);
            Console.ReadKey();

        }

        void CalculateLeafNodeSum(Node node)
        {
            if (node==null)
            {
                return ;
            }

            if (ifLeafNode(node))
            {
                sum+= node.Data;
                return;
                
            }

            CalculateLeafNodeSum(node.Left);
            CalculateLeafNodeSum(node.Right);            
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
