using System;
using System.Collections.Generic;

namespace UQAC_IA_TP2.sudoku.heuristics
{
    public class DegreeHeuristicFunction<T> : VariableSelectionFunction<T>
    {
        public override List<Variable> Apply(List<Variable> variables, CSP<T> csp, Assignment<T> assignment)
        {
            variables.Sort(delegate(Variable var1, Variable var2)
            {
                throw new NotImplementedException();
            });
        
            return base.Apply(variables, csp, assignment);
        }
    }
}