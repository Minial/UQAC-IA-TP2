using System;
using System.Collections;
using System.Collections.Generic;

namespace UQAC_IA_TP2.sudoku.heuristics
{
    public class AC3Function<T>
    {

        public static CSP<T> Apply(CSP<T> csp)
        {
            // var queue = new Queue<BinaryConstraint<T>>();
            // BinaryConstraint<T> current;
            // foreach (var c in csp.constraints)
            //     queue.Enqueue(new BinaryConstraint<T>(c.Var1, c.Var2));
            //
            // while (queue.Count != 0)
            // {
            //     current = queue.Dequeue();
            //     if (RemoveInconsistentValues(current))
            //     {
            //         foreach (var c in csp.constraints)
            //         {
            //             if (current.Var1.IsEquals(c.Var2))
            //                 queue.Enqueue(csp.createConstraint(c.Var2, c.Var1));
            //         }
            //     }
            // }

            return null;
        }
        
        private static bool RemoveInconsistentValues(BinaryConstraint<T> constraint)
        {
            bool removed = false;
            bool test;
            for(int x = 0; x < constraint.Var1.Domain.Count; x++)
            {
                test = false;
                foreach (var y in constraint.Var2.Domain)
                {
                    if (!y.Equals(constraint.Var1.Domain[x]))
                        test = true;
                }
                if (!test)
                {
                    constraint.Var1.Domain.Remove(constraint.Var1.Domain[x]);
                }
            }
            return removed;
        }
    }
}