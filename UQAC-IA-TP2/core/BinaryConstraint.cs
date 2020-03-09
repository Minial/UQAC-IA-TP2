using System;

namespace UQAC_IA_TP2.core
{
    public abstract class BinaryConstraint<T>
    {
        public Variable<T> Var1, Var2;

        public BinaryConstraint(Variable<T> var1, Variable<T> var2)
        {
            Var1 = var1;
            Var2 = var2;
        }

    }
}