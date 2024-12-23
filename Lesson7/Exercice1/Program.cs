﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Створіть клас Human, який міститиме інформацію про
//людину. За допомогою механізму спадкування реалізуй-
//те клас Builder (містить інформацію про будівельника),
//клас Sailor (містить інформацію про моряка), клас Pilot
//(містить інформацію про льотчика).
//Кожен із класів повинен містити необхідні для роботи
//методи.

namespace Exercice1
{
    abstract class  Human
    {
        public Human(string full_name)
        {
            FullName = full_name;
        }

        public string FullName { get; set; }

        public override string ToString()
        {
            return "Human: " + FullName;
        }
    }

    class Builder : Human
    {
        public Builder(string specialty, string full_name) : base(full_name)
        {
            Specialty = specialty;
        }

        public string Specialty { get; set; }

        public override string ToString()
        {
            return "Builder: " + FullName + " | " + Specialty;
        }
    }

    class Sailor : Human
    {
        public Sailor(string ship_name, string full_name) : base(full_name) 
        {
            ShipName = ship_name;
        }

        public string ShipName { get; set; }

        public override string ToString()
        {
            return "Sailor: " + FullName + " | Ship name: " + ShipName;
        }
    }

    class Pilot : Human
    {
        public Pilot(string airplane_flight, string full_name) : base(full_name)
        {
            AirplaneFlight = airplane_flight;
        }

        public string AirplaneFlight { get; set; }

        public override string ToString()
        {
            return "Pilot: " + FullName + " | " + AirplaneFlight;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Builder builder = new Builder("multi-storey buildings", "Sergey Kostine");
            Console.WriteLine(builder);
            Pilot pilot = new Pilot("Ukraine -> USA", "Faudhel Duvale");
            Console.WriteLine(pilot);
            Console.Read();
        }
    }
}
