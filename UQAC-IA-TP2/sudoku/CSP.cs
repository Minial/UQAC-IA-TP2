using System.Collections.Generic;

namespace UQAC_IA_TP2.sudoku
{
    public abstract class CSP<T>
    {
        public Dictionary<Variable, Domain<T>> variables;
        public List<IConstraint> constraints;
        
        
        public bool IsComplete(Assignment<T> assignment)
        {
            return assignment.assignment.Count == variables.Count;
        }

        public bool IsValueConsistent(Assignment<T> assignment, T value)
        {
            return false;
        }

        public Assignment<T> Resolve(BacktrackingSearch<T> backtrackingSearch)
        {
            return backtrackingSearch.Search(this);
        }
    }
}