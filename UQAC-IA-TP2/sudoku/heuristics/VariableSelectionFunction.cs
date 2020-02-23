using System.Collections.Generic;


namespace UQAC_IA_TP2.sudoku.heuristics
{
    public abstract class VariableSelectionFunction<T>
    {
        private VariableSelectionFunction<T> _nextFunction;
        
        public virtual List<Variable> Apply(List<Variable> variables, CSP<T> csp, Assignment<T> assignment)
        {
            if (_nextFunction == null) 
                return variables;
            return _nextFunction.Apply(variables, csp, assignment);
        }

        public void SetNext(VariableSelectionFunction<T> nextFunction)
        {
            _nextFunction = nextFunction;
        }
    }
}