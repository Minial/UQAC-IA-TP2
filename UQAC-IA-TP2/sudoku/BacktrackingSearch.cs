using System.Collections.Generic;
using UQAC_IA_TP2.sudoku.heuristics;


namespace UQAC_IA_TP2.sudoku
{
    public class BacktrackingSearch<T>
    {
        private VariableSelectionFunction<T> _variableSelectionFunction;
        private ValueOrderingFunction<T> _valueOrderingFunction;
        private InferenceFunction<T> _inferenceFunction;

        public BacktrackingSearch(VariableSelectionFunction<T> variableSectionFunction, ValueOrderingFunction<T> valueOrderingFunction, InferenceFunction<T> inferenceFunction)
        {
            _variableSelectionFunction = variableSectionFunction;
            _valueOrderingFunction = valueOrderingFunction;
            _inferenceFunction = inferenceFunction;
        }
        
        public Assignment<T> Search(CSP<T> csp)
        {
            return SearchRecursion(new Assignment<T>(), csp);
        }

        private Assignment<T> SearchRecursion(Assignment<T> assignment , CSP<T> csp)
        {
            if (csp.IsComplete(assignment))
                return assignment;
            var curVar = SelectUnassignedVariable(assignment, csp);
            foreach (var value in OrderDomainValue(curVar, assignment, csp))
            {
                if (csp.IsValueConsistent(assignment, value))
                {
                    assignment.Add(curVar, value);
                    var result = SearchRecursion(assignment, csp);
                    if (result != null)
                        return result;
                    assignment.Remove(curVar, value);
                }
            }
            return null;
        }

        private Variable SelectUnassignedVariable(Assignment<T> assignment, CSP<T> csp)
        {
            var variables = new List<Variable>(csp.variables.Keys);
            _variableSelectionFunction.Apply(variables, csp, assignment);
            return variables[0];
        }

        private Domain<T> OrderDomainValue(Variable var, Assignment<T> assignment, CSP<T> csp)
        {
            var domain = csp.variables[var];
            return _valueOrderingFunction.Apply(var, domain, csp, assignment);
        }
    }
}