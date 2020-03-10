using System.Collections.Generic;
using System.Linq;

namespace UQAC_IA_TP2.core.functions
{
    /// <summary>
    /// Permet de retourner la (ou les) variable(s) impliquée(s) dans le plus grand nombre de contraintes
    ///
    /// Possède une fonction Apply qui exécute l'algorithme et retourne la liste résultante
    /// Possède une fonction auxiliaire CountConstraints(variable, constraints) -> int qui compte le nombre de
    /// contraintes dans lesquels la variable est impliqué.
    /// </summary>
    public static class DegreeHeuristicFunction<T>
    {
        public static List<Variable<T>> Apply(List<Variable<T>> unassignedVariables, CSP<T> csp)
        {
            unassignedVariables.Sort(delegate(Variable<T> var1, Variable<T> var2)
            {
                var nbOfConstraintsVar1 = CountConstraints(var1, csp.Constraints);
                var nbOfConstraintsVar2 = CountConstraints(var2, csp.Constraints);
                return nbOfConstraintsVar2.CompareTo(nbOfConstraintsVar1);
            });
            unassignedVariables = Utils<T>.SubArrayFirstSameElements(unassignedVariables);
            return unassignedVariables;
        }
        
        
        /// Compte le nombre de contraintes dans lesquels une variable est impliquée
        private static int CountConstraints(Variable<T> var, List<BinaryConstraint<T>> constraints)
        {
            return constraints.Count(c => c.Var1 == var || c.Var2 == var);
        }
    }
}