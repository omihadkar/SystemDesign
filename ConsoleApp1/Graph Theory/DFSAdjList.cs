using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Graph_Theory
{

   public class Edge
    {
        
        public int from, to, cost;

        public Edge(int from, int to, int cost)
        {
            this.from = from;
            this.to = to;
            this.cost = cost;
        }
    }
    class DFSAdjList
    {
        

        static void Main(string[] args)
        {
            // Create a fully connected graph
            //           (0)
            //           / \
            //        5 /   \ 4
            //         /     \
            // 10     <   -2  >
            //   +->(2)<------(1)      (4)
            //   +--- \       /
            //         \     /
            //        1 \   / 6
            //           > <
            //           (3)

            int numNodes = 5;
            Dictionary<int, List<Edge>> edgeList = new Dictionary<int, List<Edge>>();
            addEdgeList(edgeList, 0, 1, 4);
            addEdgeList(edgeList, 0, 2, 5);
            addEdgeList(edgeList, 1, 2, -2);
            addEdgeList(edgeList, 1, 3, 6);
            addEdgeList(edgeList, 2, 3, 1);
            addEdgeList(edgeList, 2, 2, 10);

            Console.WriteLine("Node count is " +DFS(0, new bool[numNodes], edgeList));
            Console.WriteLine("Node count is " + DFS(4, new bool[numNodes], edgeList));
            Console.WriteLine("Node count is " + DFS(1, new bool[numNodes], edgeList));
            Console.ReadKey();

        }

        static long DFS(int at, bool [] visited,Dictionary<int,List<Edge>> edgeList)
        {
            if(visited[at]==true)
            {
                return 0L;
            }
            Console.WriteLine(at);

            visited[at] = true;
            long count = 1;

            if (edgeList.ContainsKey(at))
            {
                var edges = edgeList[at];

                foreach (var edge in edges)
                {
                    
                    count += DFS(edge.to, visited, edgeList);
                }
            }
             

            return count;

        }

        static void addEdgeList(Dictionary<int, List<Edge>> edgeList,int from,int to,int cost)
        {
            
            if (!edgeList.ContainsKey(from))
            {
                edgeList.Add(from, new List<Edge> { new Edge(from, to, cost) });
            }
            else
            {
                var element = edgeList[from];
                element.Add(new Edge(from, to, cost));
            }
        }
    }
}
