using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
    11110
    11010
    11000
    00000

   Question: Find Number of Islands.
     
     */
    public class NumberOfIslands
    {
        static void Main(string[] args)
        {
            char[,] grid = new char[5,5];

            grid[0, 0] = '1';
            grid[0, 1] = '1';
            grid[0, 2] = '0';
            grid[0, 3] = '0';
            grid[0, 4] = '0';

            grid[1, 0] = '1';
            grid[1, 1] = '1';
            grid[1, 2] = '0';
            grid[1, 3] = '0';
            grid[1, 4] = '0';

            grid[2, 0] = '0';
            grid[2, 1] = '0';
            grid[2, 2] = '1';
            grid[2, 3] = '0';
            grid[2, 4] = '0';


            grid[3, 0] = '0';
            grid[3, 1] = '0';
            grid[3, 2] = '0';
            grid[3, 3] = '1';
            grid[3, 4] = '1';

            grid[4, 0] = '0';
            grid[4, 1] = '0';
            grid[4, 2] = '0';
            grid[4, 3] = '1';
            grid[4, 4] = '1';

            Console.WriteLine(GetIslandCount(grid) );
            Console.ReadKey();

        }

       private  static int GetIslandCount(char [,] grid)
        {
            if(grid==null || grid.Length<=0)
            {
                return 0;
            }

            int islandCount = 0;

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(0); j++)
                {
                    if (grid[i,j]=='1')
                    {
                        islandCount++;
                        ChangeIslandtoWater(grid, i, j);
                    }
                }
            }
            return islandCount;
        }

        private static void ChangeIslandtoWater(char[,] grid, int i, int j)
        {
            if (i<0 || i>= grid.GetLength(0) || j<0 ||j>= grid.GetLength(0) || grid[i,j]=='0' )
            {
                return;
            }

            grid[i, j] = '0';
            ChangeIslandtoWater(grid, i + 1, j);
            ChangeIslandtoWater(grid, i - 1, j);
            ChangeIslandtoWater(grid, i, j + 1);
            ChangeIslandtoWater(grid, i, j - 1);
        }
    }
}
