using System.Collections.Generic;
using System.Linq;


namespace UQAC_IA_TP2.core.functions
{

    internal class Arc<T>
    {
        public Variable<T> VarI;
        public Variable<T> VarJ;

        public Arc(Variable<T> varI, Variable<T> varJ)
        {
            VarI = varI;
            VarJ = varJ;
        }
    }
    
    public class AC3Function<T>
    {
        public static CSP<T> Apply(CSP<T> csp)
        {
            var queue = new Queue<Arc<T>>(csp.constraints.Select(c => new Arc<T>(c.Var1, c.Var2)));

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
            return csp.constraints.Where(c => var.Equals(c.Var1)).Select(c => c.Var2);
        }
        

        private static bool RemoveInconsistentValues(CSP<T> csp, Variable<T> varI, Variable<T> varJ)
        {
            var removed = false;
            foreach (var x in varI.Domain.ToList())
            {
                if (!csp.SatisfyConstraint(varI, varJ, x))
                {
                    varI.Domain.Remove(x);
                    removed = true;
                }
            }
            return removed;
        }
    }
}