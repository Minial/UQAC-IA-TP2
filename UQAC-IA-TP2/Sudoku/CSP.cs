using System.Collections.Generic;

namespace UQAC_IA_TP2.Sudoku
{
    public abstract class CSP
    {
        public List<Variable> variables;
        public List<Domain> domain;
        public List<IConstraint> constraints;

        // public abstract bool ObjectiveTest();
        
        public bool IsComplete(Assignment assignment)
        {
            return assignment.assignment.Count == variables.Count;
        }

        public bool IsValueConsistent(Assignment assignment, int value)
        {
            return false;
        }
    }
}