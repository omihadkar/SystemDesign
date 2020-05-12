using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Graph_Theory
{
    /// <summary>
    /// Linked List representation of Tree.
    /// MirrorNode is additional function for mirroring  tree.
    /// </summary>
    class Node
    {
        public string Data { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
    }

    class TreeUsingLinkedList
    {
        static Stack<Node> nodeStack = new Stack<Node>();

        static void Main(string[] args)
        {
            Node nd1 = new Node();
            nd1.Data = "Root";
            nd1.Left = new Node() { Data = "10" };
            nd1.Left.Left = new Node { Data = "11" };
            nd1.Left.Right = new Node { Data = "22" };
            nd1.Right = new Node() { Data = "20" };
            nd1.Right.Right = new Node() { Data = "21" };
            nd1.Right.Left = new Node() { Data = "12" };

            Console.WriteLine("================PreOrder===================");
            PreOrder(nd1);
            Console.WriteLine("=================PostOrder==================");
            PostOrder(nd1);
            Console.WriteLine("==================InOrder=================");
            InOrder(nd1);
            Console.WriteLine("===================================");
            MirrorNode(nodeStack);
            Console.ReadKey();
        }

        private static void MirrorNode(Stack<Node> nodeStack)
        {
            while (nodeStack.Count!=0)
            {
                var result= nodeStack.Pop();
                Console.WriteLine(result.Data);
            }
            
        }

        static void PreOrder(Node rootNode)
        {
            if(rootNode==null)
            {
                return;
            }
            nodeStack.Push(rootNode);
            Console.WriteLine(rootNode.Data);
            PreOrder(rootNode.Left);            
            PreOrder(rootNode.Right);
        }

        static void InOrder(Node rootNode)
        {
            if (rootNode == null)
            {
                return;
            }
            
            PreOrder(rootNode.Left);
            Console.WriteLine(rootNode.Data);
            PreOrder(rootNode.Right);
        }

        static void PostOrder(Node rootNode)
        {
            if (rootNode == null)
            {
                return;
            }

            PreOrder(rootNode.Left);            
            PreOrder(rootNode.Right);
            Console.WriteLine(rootNode.Data);
        }
    }
}
