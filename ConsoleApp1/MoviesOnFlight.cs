using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
   public class MoviesOnFlight
    {
        /*
            You are on a flight and wanna watch two movies during this flight.
            You are given List<Integer> movieDurations which includes all the movie durations.
            You are also given the duration of the flight which is d in minutes.
            Now, you need to pick two movies and the total duration of the two movies is less than or equal to (d - 30min).

            Find the pair of movies with the longest total duration and return they indexes. If multiple found, return the pair with the longest movie.         
         */
        static void Main(string[] args)
        {
            List<int> orgMoviesOnDuration = new List<int> { 90, 85, 75, 60, 120, 150, 125 };
            List<int> moviesOnDuration= new List<int> { 90, 85, 75, 60, 120, 150, 125 };
            moviesOnDuration.Sort();
            int d = 250;
            int left = 0;
            int right = 0;
            int leftIndex = 0;
            int rightIndex = 0;
            int result = 0;

            for (int i = 0; i < moviesOnDuration.Count-1; i++)
            {
                for (int j = i; j < moviesOnDuration.Count - 1; j++)
                {
                    var total = moviesOnDuration[i] + moviesOnDuration[j];
                    if (result<total&& total<(d-30))
                    {
                        left = moviesOnDuration[i];
                        leftIndex = i;
                        right = moviesOnDuration[j];
                        rightIndex = j;
                        result = moviesOnDuration[i] + moviesOnDuration[j];
                    }
                }
            }

            Console.WriteLine(left+" "+right );
            Console.WriteLine("Indexes are "+ orgMoviesOnDuration.IndexOf(left) + " and  " + orgMoviesOnDuration.IndexOf(right));
            Console.WriteLine("Final result "+ result);
            Console.ReadKey();

        }
    }
}
