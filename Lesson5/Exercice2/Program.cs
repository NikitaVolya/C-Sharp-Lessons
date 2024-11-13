using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

//Завдання 2
//Створіть класи для відображення різних геометричних
//фігур: трикутника, прямокутника, квадрата. Використо-
//вуйте механізми просторів імен.


namespace Triangle
{

    class Figure
    {
        private int[] sides;
        public int[] Sides
        {
            set
            {
                if (sides == null)
                    sides = new int[3];
                if (value.Length != 3)
                    throw new ArgumentException("Size of sides is 3");
                value.CopyTo(sides, 0);
            }
            get
            {
                int[] rep = new int[3];
                sides.CopyTo(rep, 0);
                return rep;
            }
        }
        Figure()
        {
            sides = null;
        }
        Figure(int[] pSides)
        {
            Sides = pSides;
        }

        int getPerimetr()
        {
            if (sides == null)
                return 0;
            return sides[0] + sides[1] + sides[2];
        }
    }

    
}

namespace Exercice2
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
