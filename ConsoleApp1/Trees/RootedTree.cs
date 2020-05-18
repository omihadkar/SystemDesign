using ConsoleApp1.Graph_Theory;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Trees
{
    /// <summary>
    /// Create a rooted tree  from existing provided tree.
    /// </summary>
    class RootedTreeBFS
    {
        static void Main(string[] args)
        {
            List<List<int>> graph = createGraph(9);
            addUndirectedEdge(graph, 0, 1);
            addUndirectedEdge(graph, 2, 1);
            addUndirectedEdge(graph, 2, 3);
            addUndirectedEdge(graph, 3, 4);
            addUndirectedEdge(graph, 5, 3);
            addUndirectedEdge(graph, 2, 6);
            addUndirectedEdge(graph, 6, 7);
            addUndirectedEdge(graph, 6, 8);

            RootedTreeBFS rtb = new RootedTreeBFS();
            var root= rtb.RouteTree(graph, 6);
            Console.WriteLine(root);



        }

        TreeNode RouteTree(List<List<int>> g, int rootId)
        {
            var root = new TreeNode() { Id = rootId, ParentNode = null, ChildNodes = new List<TreeNode>() };
            return BuildTree(root, g);
        }

        private TreeNode BuildTree(TreeNode root, List<List<int>> g)
        {
            var graphList = g[root.Id];

            for (int i = 0; i < graphList.Count; i++)
            {

                if (root.ParentNode!=null && graphList[i]==root.ParentNode.Id)
                {
                    continue;
                }
                var child = new TreeNode() { Id = graphList[i], ParentNode = root,ChildNodes=new List<TreeNode>() };
                root.ChildNodes.Add(child);

                BuildTree(child, g);                               
            }

            return root;
        }


        /*Testing*/
        // Create a graph as a adjacency list
        private static List<List<int>> createGraph(int n)
        {
            List<List<int>> graph = new List<List<int>>();
            for (int i = 0; i < n; i++)
            {
                graph.Add(new List<int>());                
            }
            return graph;
        }

        private static void addUndirectedEdge(List<List<int>> graph, int from, int to)
        {
            graph[from].Add(to);
            graph[to].Add(from);
        }

    }

    class TreeNode
    {
        public int Id { get; set; }
        public TreeNode ParentNode { get; set; }
        public List<TreeNode> ChildNodes { get; set; }

    }
}
