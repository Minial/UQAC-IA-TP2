using System.Collections.Generic;

namespace UQAC_IA_TP2.sudoku.heuristics
{
    public class LeastConstrainingValueFunction<T> : ValueOrderingFunction<T>
    {
        public override Domain<T> Apply(Variable variable, Domain<T> domain, CSP<T> csp, Assignment<T> assignment)
        {
            string a = null;
            return base.Apply(variable, domain, csp, assignment);
        }
    }
}