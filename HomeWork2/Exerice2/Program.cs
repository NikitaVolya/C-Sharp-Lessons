﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Створіть додаток, який відображає кількість значень у масиві менше заданого параметра користувачем. 
//   Наприклад, кількість значень менших, ніж 7 (7 введено користувачем з клавіатури).

namespace Exercice2
{
    internal class Program
    {
        static int loverNums(int[] nums, int target)
        {
            int rep = 0;

            foreach (var num in nums)
                if (num <  target)
                    rep++;

            return rep;
        }

        static void Main(string[] args)
        {
        }
    }
}
