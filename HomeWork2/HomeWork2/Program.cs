using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

//Створіть додаток, який відображає кількість парних, непарних, унікальних елементів масиву.

namespace Exercice1
{
    internal class Program
    {
        static Dictionary<int, int> getCountDict(int[] nums)
        {
            Dictionary<int, int> numsDict = new Dictionary<int, int>();

            foreach (int num in nums)
            {
                if (numsDict.ContainsKey(num))
                    numsDict[num]++;
                else
                    numsDict[num] = 1;
            }

            return numsDict;
        }

        static int pairNums(int[] nums)
        {
            Dictionary<int, int> countDict = getCountDict(nums);

            int rep = 0;
            foreach (KeyValuePair<int, int> item in countDict)
                if (item.Value % 2 == 0)
                    rep++;

            return rep;
        }

        static int notPairNums(int[] nums)
        {
            Dictionary<int, int> countDict = getCountDict(nums);

            int rep = 0;
            foreach (KeyValuePair<int, int> item in countDict)
                if (item.Value % 2 != 0)
                    rep++;

            return rep;
        }

        static int uniqueNums(int[] nums)
        {
            Dictionary<int, int> countDict = getCountDict(nums);

            int rep = 0;
            foreach (KeyValuePair<int, int> item in countDict)
                if (item.Value == 1)
                    rep++;

            return rep;
        }


        static void Main(string[] args)
        {
            int[] nums = { 1, 2, 1, 5, 3, 2, 1, 2, 5};

            Console.WriteLine($"Pair nums: {pairNums(nums)}");
            Console.WriteLine($"Not pair nums: {notPairNums(nums)}");
            Console.WriteLine($"Unique nums: {uniqueNums(nums)}");

            Console.ReadKey();
        }
    }
}
