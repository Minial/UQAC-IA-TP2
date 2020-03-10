using System.Collections.Generic;
using System.Linq;


namespace UQAC_IA_TP2.core.functions
{
    
    internal class Arc<T>
    {
        public Variable<T> VarI, VarJ;

        public Arc(Variable<T> varI, Variable<T> varJ)
        {
            VarI = varI;
            VarJ = varJ;
        }
    }
    
    /// <summary>
    /// Implémente l'algorithme AC3 pour gérer à l'avance les contraintes
    /// 
    /// Méthodes :
    ///     - Apply() : applique l'algorithme AC3
    ///     - Neighbors(var, csp) : retourne une liste des variables impliquées dans une contraintes avec var
    ///     - RemoveInconsistentValues(csp, varI, varJ) : réduit le domaine d'une variable (enlève les valeurs illégales)
    ///                                                   en fonction de la contrainte entre varI et varJ (si elle existe)
    /// 
    /// </summary>
    public static class Ac3Function<T>
    {
        public static CSP<T> Apply(CSP<T> csp)
        {
            var queue = new Queue<Arc<T>>(csp.Constraints.Select(c => new Arc<T>(c.Var1, c.Var2)));

            while (queue.Count != 0)
            {
                var currentArc = queue.Dequeue();
                if (RemoveInconsistentValues(csp, currentArc.VarI, currentArc.VarJ))
                {
                    foreach (var varK in Neighbors(currentArc.VarI, csp))
                        queue.Enqueue(new Arc<T>(varK, currentArc.VarI));
                }
            }
            return csp;
        }
        

        private static IEnumerable<Variable<T>> Neighbors(Variable<T> var, CSP<T> csp)
        {
            return csp.Constraints.Where(c => var.Equals(c.Var1)).Select(c => c.Var2);
        }
        
        
        private static bool RemoveInconsistentValues(CSP<T> csp, Variable<T> varI, Variable<T> varJ)
        {
            var constraint = csp.GetConstraint(varI, varJ);
            if (constraint == null)
                return false;
            
            var removed = false;
            foreach (var x in varI.Domain.ToList())
            {
                if (!constraint.SatisfyConstraint(x))
                {
                    varI.Domain.Remove(x);
                    removed = true;
                }
            }
            return removed;
        }
    }
}