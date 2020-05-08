using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class TreasureIsland
    {
        public Queue<int> rq { get; set; }
        public Queue<int> cq { get; set; }

        int sr = 0, sc = 0, r = 0, c = 0;
        bool reached_end = false;
        int[] dr = new int[4] { -1, 1, 0, 0 };
        int[] dc = new int[4] { 0, 0, 1, -1 };
        int R = 4, C = 4;
        int nodes_in_next_layer = 0;
        int nodes_left_in_layer = 0;
        int move_count = 0;

        bool[,] visited;
        Queue<(int, int)> coordinates = new Queue<(int, int)>();

        static void Main(string[] args)
        {
            char[,] grid = new char[4, 4];
            

            grid[0, 0] = 'O';
            grid[0, 1] = 'O';
            grid[0, 2] = 'O';
            grid[0, 3] = 'O';
            

            grid[1, 0] = '#';
            grid[1, 1] = 'O';
            grid[1, 2] = '#';
            grid[1, 3] = 'O';
            

            grid[2, 0] = 'O';
            grid[2, 1] = 'O';
            grid[2, 2] = 'O';
            grid[2, 3] = 'O';
            


            grid[3, 0] = 'E';
            grid[3, 1] = '#';
            grid[3, 2] = '#';
            grid[3, 3] = 'O';

            TreasureIsland island = new TreasureIsland();
            island.visited = new bool[4, 4];
            island.rq = new Queue<int>();
            island.cq = new Queue<int>();
            
            var result =island.Solve(grid);
            Console.WriteLine();
            Console.ReadKey();
            
        }


         int Solve (char [,] grid)
        {
            rq.Enqueue(sr);
            cq.Enqueue(sc);
            visited[sr,sc] = true;

            while(rq.Count>0)
            {
                r = rq.Dequeue();
                c = cq.Dequeue();
                if(grid[r,c]=='E')
                {
                    coordinates.Enqueue((r, c));
                    reached_end = true;
                    break;
                }
                explore_neighbours(r, c,grid);
                //nodes_left_in_layer--;
                //if(nodes_left_in_layer==0)
                //{
                //    nodes_left_in_layer = nodes_in_next_layer;
                //    nodes_in_next_layer = 0;
                //    move_count++;                    
                //}
                move_count++;
                //if(reached_end)
                //{
                //    return move_count;
                //}
            }
            return -1;
        }

        private void explore_neighbours(int r, int c, char[,] grid)
        {
            int rr, cc;
            for (int i = 0; i < 4; i++)
            {
                rr = r+dr[i];
                cc = c+dc[i];

                if (rr < 0 || cc < 0)
                {
                    continue;
                }
                    
                if(rr>=R || cc>=C)
                {
                    continue;
                }

                if(visited[rr,cc]==true)
                {
                    continue;
                }

                if(grid[rr,cc]=='#')
                {
                    continue;
                }

                rq.Enqueue(rr);
                cq.Enqueue(cc);
                visited[rr,cc] = true;
                coordinates.Enqueue((r, c));
               // nodes_in_next_layer++;
            }            
        }
    }
}
