using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class SeatingArrangement
    {
        static StringBuilder result = new StringBuilder();
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int seatNo = int.Parse(Console.ReadLine());
                if (seatNo > 0 && seatNo < 109)
                {
                    GetSeatDetail(seatNo);
                }
            }
            Console.ReadKey();

        }

        private static void GetSeatDetail(int seatNo)
        {
            int sumValue = 13;
            int compartmentNo = seatNo % 12 == 0 ? seatNo / 12 - 1 : seatNo / 12;
            for (int i = 0; i < compartmentNo; i++)
            {
                sumValue += 24;
            }
            int oppositeseat = sumValue - seatNo;
            string windowtype = getWindowType(oppositeseat);
            Console.WriteLine(result.AppendFormat("{0} {1}", oppositeseat, windowtype));
            result.Clear();
        }

        private static string getWindowType(int oppositeseat)
        {
            switch (oppositeseat % 12)
            {
                case 1:
                case 6:
                case 7:
                case 0:
                    return "WS";
                case 2:
                case 11:
                case 5:
                case 8:
                    return "MS";
                case 3:
                case 10:
                case 4:
                case 9:
                    return "AS";
            }
            return "";
        }
    }
}