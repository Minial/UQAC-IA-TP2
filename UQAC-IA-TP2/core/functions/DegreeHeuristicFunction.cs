using System;
using System.Collections.Generic;
using System.Linq;

namespace UQAC_IA_TP2.core.functions
{
    public class DegreeHeuristicFunction<T>
    {

        public static List<Variable<T>> Apply(List<Variable<T>> variables, CSP<T> csp)
        {
            variables.Sort(delegate(Variable<T> var1, Variable<T> var2)
            {
                var nbOfConstraintsVar1 = CountConstraints(var1, csp.constraints);
                var nbOfConstraintsVar2 = CountConstraints(var2, csp.constraints);
                return nbOfConstraintsVar1.CompareTo(nbOfConstraintsVar2);
            });
            variables = Utils<T>.SubArrayFirstSameElements(variables);
            return variables;
        }
        
        
        private static int CountConstraints(Variable<T> var, List<BinaryConstraint<T>> constraints)
        {
            return constraints.Count(c => c.Var1 == var || c.Var2 == var);
        }
    }
}