using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Graph_Theory
{
    class BreadthFirstSearchAdjacencyListIterative
    {
        private int n;
        private int[] prev;
        private List<List<Edge>> graph;

        public BreadthFirstSearchAdjacencyListIterative(List<List<Edge>> graph)
        {
            if (graph == null) throw new Exception("Graph can not be null");
            n = graph.Count;
            this.graph = graph;
        }

        static void Main(string[] args)
        {
            int n = 13;

            List<List<Edge>> graph = createEmptyGraph(n);

            addUnweightedUndirectedEdge(graph, 0, 7);
            addUnweightedUndirectedEdge(graph, 0, 9);
            addUnweightedUndirectedEdge(graph, 0, 11);
            addUnweightedUndirectedEdge(graph, 7, 11);
            addUnweightedUndirectedEdge(graph, 7, 6);
            addUnweightedUndirectedEdge(graph, 7, 3);
            addUnweightedUndirectedEdge(graph, 6, 5);
            addUnweightedUndirectedEdge(graph, 3, 4);
            addUnweightedUndirectedEdge(graph, 2, 3);
            addUnweightedUndirectedEdge(graph, 2, 12);
            addUnweightedUndirectedEdge(graph, 12, 8);
            addUnweightedUndirectedEdge(graph, 8, 1);
            addUnweightedUndirectedEdge(graph, 1, 10);
            addUnweightedUndirectedEdge(graph, 10, 9);
            addUnweightedUndirectedEdge(graph, 9, 8);

            var solver = new BreadthFirstSearchAdjacencyListIterative(graph);

            int start = 10, end = 5;
            List<int> path = solver.reconstructPath(start, end);
            Console.WriteLine($"The shortest path from {start} to {end} is: {formatPath(path)}");


        }

        private static String formatPath(List<int> path)
        {
            StringBuilder str= new StringBuilder();

            foreach (var item in path)
            {
                str.Append(item + "-->");
            }

            return str.ToString();
        }


        public List<int> reconstructPath(int start, int end)
        {
            List<int> path = new List<int>();
            bfsearch(start);

            //Traverse array of prev based on index.
            //starting index would be end variable value.
            //Then current index value will be your next index .
            //Again get value from index and repeat above step [i.e. setting current index value as your next index]
            var current = end;
            while (!current.Equals(start))
            {
                path.Add(current);
                current = prev[current];
            }

            path.Add(start);

            path.Reverse();
            //for (Integer at = end; at != null; at = prev[at]) path.add(at);
            //Collections.reverse(path);
            //if (path.get(0) == start) return path;
            //path.clear();
            return path;
        }


        private void bfsearch(int start)
        {
            prev = new int[n];
            bool[] visited = new bool[n];
            Queue<int> queu = new Queue<int>();

            queu.Enqueue(start);

            visited[start] = true;

            while(queu.Count!=0)
            {
                int node = queu.Dequeue();

                var edges = graph[node];

                foreach (var item in edges)
                {
                    if(!visited[item.to])
                    {
                        visited[item.to] = true;
                        queu.Enqueue(item.to);
                        prev[item.to] = node;                        
                    }
                }

            }

        }

        public static void addDirectedEdge(List<List<Edge>> graph, int u, int v, int cost)
        {
            graph[u].Add(new Edge(u, v, cost));            
        }

        public static void addUndirectedEdge(List<List<Edge>> graph, int u, int v, int cost)
        {
            addDirectedEdge(graph, u, v, cost);
            addDirectedEdge(graph, v, u, cost);
        }

        public static void addUnweightedUndirectedEdge(List<List<Edge>> graph, int u, int v)
        {
            addUndirectedEdge(graph, u, v, 1);
        }

        private static List<List<Edge>> createEmptyGraph(int n)
        {
            List<List<Edge>> edgeList = new List<List<Edge>>();
            for (int i = 0; i < n; i++)
            {
                edgeList.Add(new List<Edge>());
            }

            return edgeList;
        }
    }
}
