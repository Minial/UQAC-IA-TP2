using System;
using System.Collections.Generic;

namespace UQAC_IA_TP2.Sudoku
{
    public class BacktrackingSearch
    {
        public Assignment Search(CSP csp)
        {
            return SearchRecursion(new Assignment(), csp);
        }

        private Assignment SearchRecursion(Assignment assignment , CSP csp)
        {
            if (csp.isComplete(assignment))
                return assignment;
            var curVar = SelectUnassignedVariable(csp.variables, assignment, csp);
            foreach (var value in OrderDomainValue(curVar, assignment, csp))
            {
                if (csp.isValueConsistent(assignment, value))
                {
                    assignment.Add(curVar, value);
                    var result = SearchRecursion(assignment, csp);
                    if (result != null)
                    {
                        return result;
                    }
                    assignment.Remove(curVar, value);
                }
            }
            return null;
        }

        private Variable SelectUnassignedVariable(List<Variable> var, Assignment assignment, CSP csp)
        {
            // mrv
            // degree heuristic
            return null;
        }

        private List<int> OrderDomainValue(Variable var, Assignment assignment, CSP csp)
        {
            // ac3
            // least constraining value
            return null;
        }
    }
}