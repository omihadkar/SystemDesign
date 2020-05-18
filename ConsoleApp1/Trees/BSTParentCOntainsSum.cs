using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Trees
{
    /// <summary>
    /// Verify whether Parent contains sum of it's child
    /// </summary>
    class BSTParentCOntainsSum
    {
        static void Main(string[] args)
        {
            BSTParentCOntainsSum a = new BSTParentCOntainsSum();

            /*Valid scenario*/
            Node root = a.createNewNode(12);
            root.Left = a.createNewNode(4);
            root.Left.Left = a.createNewNode(3);
            root.Left.Right = a.createNewNode(1);
            root.Right = a.createNewNode(8);
            root.Right.Right = a.createNewNode(8);

            Console.WriteLine("Parent contains sum of it's child : " + a.VerifySumOfParent(root));

            /*Invalid scenario*/
            root = a.createNewNode(12);
            root.Left = a.createNewNode(4);
            root.Left.Left = a.createNewNode(3);
            root.Left.Right = a.createNewNode(1);
            root.Right = a.createNewNode(18);
            root.Right.Right = a.createNewNode(8);

            Console.WriteLine("Parent contains sum of it's child : " + a.VerifySumOfParent(root));

            Console.ReadKey();
        }

        bool VerifySumOfParent(Node node)
        {
            if (node==null || ( node.Left==null && node.Right==null))
            {
                return true;
            }

            int leftValue = node.Left == null ? 0 : node.Left.Data;
            int rightValue = node.Right == null ? 0 : node.Right.Data;

            return leftValue + rightValue == node.Data && VerifySumOfParent(node.Left) && VerifySumOfParent(node.Right);

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
}
