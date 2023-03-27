using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP
{
    class Operator
    {
        City from;
        City to;

        public Operator(City from, City to)
        {
            this.from = from;
            this.to = to;
        }

        internal City From { get => from; set => from = value; }
        internal City To { get => to; set => to = value; }

        public bool IsExistingState(State state)
        {
            if(From != To && state.Cities.Contains(To))
            {
                return true;
            }
            return false;
        }

        public State ApplyState(State state)
        {
            State newState = state;
            newState.Distance += GetDistance();
            newState.Cities.Remove(To);
            return newState;
        }

        public float GetDistance()
        {
            return Vector2.Distance(From.Position, To.Position);
        }

    }
}
