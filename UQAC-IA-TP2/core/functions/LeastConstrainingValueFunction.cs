using System;
using System.Collections.Generic;

namespace UQAC_IA_TP2.sudoku.heuristics
{
    public class LeastConstrainingValueFunction<T>
    {
        public static List<T> Apply(Variable<T> variable, CSP<T> csp)
        {
            var domain = new List<T>(variable.Domain);
            domain.Sort(delegate(T val1, T val2)
            {
                throw new Exception();
            });
            return null;
        }
    }
}