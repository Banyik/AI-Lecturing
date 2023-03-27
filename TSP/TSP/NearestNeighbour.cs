using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP
{
    class NearestNeighbour : Solver
    {
        City currentCity;
        State state;
        List<City> route = new List<City>();
        public NearestNeighbour(State state)
        {
            this.state = state;
            Solve(state);
        }
        void Solve(State state)
        {
            currentCity = state.Cities[0];
            state.Cities.Remove(currentCity);
            route.Add(currentCity);

            do
            {
                Operator currentOperator = GetOperator();
                if (currentOperator.IsExistingState(state))
                {
                    currentOperator.ApplyState(state);
                    currentCity = currentOperator.To;
                    route.Add(currentCity);
                }
            } while (!state.IsTargetState());

            state.Distance += Vector2.Distance(route[0].Position, route[route.Count - 1].Position);

            foreach (var city in route)
            {
                Console.WriteLine(city);
            }
            Console.WriteLine(state.Distance);
        }

        Operator GetOperator()
        {
            GenerateOperators(state, currentCity);
            Operator op = null;
            for (int i = 0; i < Operators.Count; i++)
            {
                if (op == null || Operators[i].GetDistance() < op.GetDistance())
                {
                    op = Operators[i];
                }
            }
            return op;
        }
    }
}
