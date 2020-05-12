using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Graph_Theory
{
    public class FindPath
    {
        private static int[,] DIRS = { { 1, 0 }, { 0, 1 }, { -1, 0 }, { 0, -1 } };
        int nRow = 4;
        int nColumn = 4;

        public int minSteps(char[,] grid)
        {
            Queue<Point> q = new Queue<Point>();
            q.Enqueue(new Point(0, 0));
            grid[0, 0] = 'D'; // mark as visited
                              //for (int steps = 1; q.Count != 0; steps++)
                              //{

            int steps = 0;
            while (q.Count != 0)
            {
                steps++;
                for (int sz = q.Count; sz > 0; sz--)
                {
                    
                    Point p = q.Dequeue();

                    for (int dir = 0; dir < 4; dir++)
                    {
                        int r = p.r + DIRS[dir, 0];
                        int c = p.c + DIRS[dir, 1];

                        if (isSafe(grid, r, c))
                        {
                            if (grid[r, c] == 'X')
                            {
                                return steps;
                            }
                            grid[r, c] = 'D';
                            q.Enqueue(new Point(r, c));
                        }
                        //    }
                    }
                }
            }

            return -1;
        }

        private  bool isSafe(char[,] grid, int r, int c)
        {
            return r >= 0 && r < nRow && c >= 0 && c < nColumn && grid[r,c] != 'D';
        }

        public class Point
        {
           public int r, c;
           public  Point(int r, int c)
            {
                this.r = r;
                this.c = c;
            }
        }

         static void Main(String[] args)
        {
            char[,] grid =new char[,] {{'O', 'O', 'O', 'X'},
                         {'D', 'O', 'D', 'O'},
                         {'O', 'O', 'O', 'O'},
                         {'D', 'D', 'D', 'O'}};

            FindPath fp = new FindPath();
            Console.WriteLine(fp.minSteps(grid));
            Console.ReadKey();
        }
    }

}
