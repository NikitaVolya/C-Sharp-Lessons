using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice6
{
    class Airplane
    {
        public string Name { get; set; }
        public string Manufacture {  get; set; }
        public ushort CreationYear { get; set; }
        public string Type { get; set; }

        public Airplane(string name, string manufacture, ushort creationYear, string type)
        {
            Name = name;
            Manufacture = manufacture;
            CreationYear = creationYear;
            Type = type;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
