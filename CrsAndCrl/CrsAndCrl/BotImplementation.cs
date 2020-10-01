using System;
using System.Collections.Generic;
using System.Text;

namespace CrsAndCrl
{
    class BotImplementation
    {
        int[,] table;
        bool CrossOrCircle;

        Random rnd = new Random();
        public BotImplementation(int[,] table_, bool CrossOrCircle_)
        {
            table = table_;
            CrossOrCircle = CrossOrCircle_;
        }

        public int CheckTheRole()
        {
            if (CrossOrCircle)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public string[,] CheckTheEmptiesCells()
        {
            string[,] empties = new string[3, 3];

            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    if (table[y, x] == 170173)
                    {
                        empties[y, x] = y.ToString() + x.ToString();
                    }
                }
            }
            return empties;
        }

        public void CreateNewDecision()
        {

        }

        public int[] SimulateTurn()
        {
            int[] result = new int[2];

            if (CheckTheEmptiesCells().GetLength(2) == 8)
            {
                result[0] = rnd.Next(0, 3);
                result[1] = rnd.Next(0, 3);
                return result;
            }



            return null;
        }
    }
}
