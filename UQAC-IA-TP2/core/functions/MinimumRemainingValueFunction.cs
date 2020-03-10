using System.Collections.Generic;


namespace UQAC_IA_TP2.core.functions
{
    /// <summary>
    /// Algorithme permettant de récupérer une liste de variables non assignées ayant le plus petit nombre de valeur
    /// légales qu'elles peuvent prendre
    ///
    /// Possède une unique fonction Apply qui exécute l'algorithme et retourne la liste résultante
    /// </summary>
    public static class MinimumRemainingValueFunction<T>
    {
        public static List<Variable<T>> Apply(List<Variable<T>> unassignedVariables)
        {
            unassignedVariables.Sort(
                (var1, var2) => var1.Domain.Count.CompareTo(var2.Domain.Count)
            );
            unassignedVariables = Utils<T>.SubArrayFirstSameElements(unassignedVariables);
            return unassignedVariables;
        }
    }
}