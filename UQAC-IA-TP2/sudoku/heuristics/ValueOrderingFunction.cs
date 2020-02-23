using System.Collections.Generic;

namespace UQAC_IA_TP2.sudoku.heuristics
{
    public abstract class ValueOrderingFunction<T>
    {
        private ValueOrderingFunction<T> _nextFunction;

        public virtual Domain<T> Apply(Variable variable, Domain<T> domain, CSP<T> csp, Assignment<T> assignment)
        {
            if (_nextFunction == null) 
                return domain;
            return _nextFunction.Apply(variable, domain, csp, assignment);
        }
        
        public void SetNext(ValueOrderingFunction<T> nextFunction)
        {
            _nextFunction = nextFunction;
        }
        
    }
}