using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Trees
{
    /// <summary>
    /// Find diagonal sum from Binary Search Tree
    /// </summary>
    class BSTDiagonalSum
    {
        public Dictionary<int, int> sumForLevel { get; set; }

        static void Main(string[] args)
        {
            BSTDiagonalSum a = new BSTDiagonalSum();
            
            Node root = a.createNewNode(2);
            root.Left = a.createNewNode(4);
            root.Left.Left= a.createNewNode(6);
            root.Right = a.createNewNode(3);
            root.Right.Right = a.createNewNode(1);
            root.Right.Left= a.createNewNode(5);
            root.Right.Left.Left= a.createNewNode(3);
            root.Right.Left.Right= a.createNewNode(2);
            root.Right.Left.Left.Left= a.createNewNode(1);
            a.FindDiagonalSumFromBST(root);
            Console.ReadKey();

        }

        void FindDiagonalSumFromBST(Node trees)
        {
            Queue<Node> nodeQueue = new Queue<Node>();
            sumForLevel = new Dictionary<int, int>();
            nodeQueue.Enqueue(trees);
            int index = 0;
            while (true)
            {
                int size = nodeQueue.Count;
                int sum = 0;

                while (size>0)
                {
                    var tempNode = nodeQueue.Dequeue();

                    while (tempNode!=null)
                    {
                        sum += tempNode.Data;

                        if (tempNode.Left!=null)
                        {
                            nodeQueue.Enqueue(tempNode.Left);
                        }

                        tempNode = tempNode.Right;
                    }
                    size--;
                }

                sumForLevel[index] = sum;
                index++;

                if (nodeQueue.Count==0)
                {
                    break;
                }
            }
            
        }

        public Node createNewNode(int val)
        {
            Node newNode = new Node();
            newNode.Data = val;
            newNode.Left = null;            
            newNode.Right = null;
            return newNode;
        }
    }

    public class Node
    {
        public int Data { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

    }
}
