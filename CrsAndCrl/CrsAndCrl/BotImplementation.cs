using System;
using System.Collections.Generic;
using System.Text;

namespace CrsAndCrl
{
    class BotImplementation
    {
        int[,] table;
        public BotImplementation(int[,] table_)
        {
            table = table_;
        }

        public int[] SimulateTurn()
        {
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    if (table[y, x] == 170173)
                    {
                        int[] temp = new int[2];
                        temp[0] = y;
                        temp[1] = x;
                        return temp;
                    }
                }
            }
            return null;
        }
    }
}
