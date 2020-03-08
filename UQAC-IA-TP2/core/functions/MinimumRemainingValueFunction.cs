using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace UQAC_IA_TP2.sudoku.heuristics
{
    public class MinimumRemainingValueFunction<T>
    {
        public static List<Variable<T>> Apply(List<Variable<T>> variables)
        {
            variables.Sort((var1, var2) => var1.Domain.Count.CompareTo(var2.Domain.Count));
            variables = Utils<T>.SubArrayFirstSameElements(variables);
            return variables;
        }
    }
}