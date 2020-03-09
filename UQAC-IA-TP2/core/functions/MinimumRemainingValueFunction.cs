using System.Collections.Generic;


namespace UQAC_IA_TP2.core.functions
{
    /// Algorithme permettant de trier une liste de variables suivant la cardinalité de leurs domaines de définition
    ///
    /// Possède une unique fonction Apply qui exécute l'algorithme et retourne la liste résultante
    public class MinimumRemainingValueFunction<T>
    {
        public static List<Variable<T>> Apply(List<Variable<T>> variables)
        {
            variables.Sort(
                (var1, var2) => var1.Domain.Count.CompareTo(var2.Domain.Count)
            );
            variables = Utils<T>.SubArrayFirstSameElements(variables);
            return variables;
        }
    }
}