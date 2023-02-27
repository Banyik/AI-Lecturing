using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerOfHanoi
{
    class Pole
    {
        List<int> discs = new List<int>();
        string name;

        public Pole(List<int> discs, string name)
        {
            Discs = discs;
            Name = name;
        }

        public List<int> Discs { get => discs; set => discs = value; }
        public string Name { get => name; set => name = value; }
    }
}
