using System.Collections.Generic;


namespace UQAC_IA_TP2.sudoku.heuristics
{
    public class MinimumRemainingValueFunction<T> : VariableSelectionFunction<T>
    {
        public override List<Variable> Apply(List<Variable> variables, CSP<T> csp, Assignment<T> assignment)
        {
            variables.Sort(delegate(Variable var1, Variable var2)
            {
                var var1NbOfLegalValues = csp.variables[var1].Count();
                var var2NbOfLegalValues = csp.variables[var2].Count();
                return var1NbOfLegalValues.CompareTo(var2NbOfLegalValues);
            });
        
            return base.Apply(variables, csp, assignment);
        }
    }
}