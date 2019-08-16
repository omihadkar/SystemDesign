using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class MSExam
    {
        static void Main(string[] args)
        {
            powerJump("11111");
        }

        public static int powerJump(string game)
        {
            if (game.Length<0 || game.Length>100000)
            {
                return 0;
            }
            var arr = game.ToCharArray();

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i]!='0' )
                {
                    if (arr[i] != '1')
                    {
                        return 0;
                    }                    
                }
            }

            var finalJump = 1;
            char firstChar = arr[0];
            int jump = 1;
            for (int i = 1; i < arr.Length; i++)
            {
                
                if (arr[i]!=firstChar)
                {
                    jump++;

                    if (finalJump<jump)
                    {
                        finalJump = jump;
                    }
                }
                else
                {
                    jump = 1;
                }
            }

            return finalJump;
        }

        public virtual string get()
        {
            Console.WriteLine("P");
            return "Parent";

        }
    }

    class MSEXam1:MSExam
    {
        public override string get()
        {
            Console.WriteLine("Child");
            return "Child";

        }
    }
}
