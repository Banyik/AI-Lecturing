using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerOfHanoi
{
    class State : ICloneable
    {
        List<Pole> poles = new List<Pole>();
        int discCount;

        internal List<Pole> Poles { get => poles; set => poles = value; }
        public int DiscCount { get => discCount; set => discCount = value; }

        public State(List<Pole> poles, int discCount)
        {
            this.Poles = poles;
            this.DiscCount = discCount;
        }

        public void SetStartingState(int poleCount)
        {
            for (int i = 0; i < poleCount; i++)
            {
                Poles.Add(new Pole(new List<int>(), $"Pole {i}"));
            }
            for (int i = DiscCount; i > 0; i--)
            {
                Poles[0].Discs.Add(i);
            }
        }

        public bool IsTargetReached()
        {
            return Poles[Poles.Count - 1].Discs.Count == DiscCount;
        }

        public override string ToString()
        {
            string value = "";
            foreach (var pole in Poles)
            {
                string discs = "";
                if (pole.Discs.Count > 0)
                {
                    foreach (var disc in pole.Discs)
                    {
                        discs += $"{disc}, ";
                    }
                    discs = discs.TrimEnd(',', ' ');
                }
                else
                {
                    discs = "None";
                }
                value += $"{pole.Name}; Discs: {discs}\n";
            }
            value += "---------------";
            return value;
        }

        public object Clone()
        {
            State newState = new State(new List<Pole>(), discCount);
            for (int i = 0; i < Poles.Count; i++)
            {
                newState.Poles.Add((Pole)poles[i].Clone());
            }
            return newState;
        }

        public override bool Equals(object obj)
        {
            if(!(obj is State))
            {
                return false;
            }
            State other = obj as State;
            if(other.DiscCount != this.DiscCount)
            {
                return false;
            }
            for (int i = 0; i < this.Poles.Count; i++)
            {
                if(Poles[i].Discs.SequenceEqual(other.Poles[i].Discs) == false)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
