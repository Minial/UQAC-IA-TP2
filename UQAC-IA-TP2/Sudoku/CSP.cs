using System.Collections.Generic;

namespace UQAC_IA_TP2.Sudoku
{
    public abstract class CSP
    {
        public List<Variable> variables;
        public List<Domain> domain;
        public List<IConstraint> constraints;

        // public abstract bool ObjectiveTest();
        
        public bool isComplete(Assignment assignment)
        {
            return false;
        }

        public bool isValueConsistent(Assignment assignment, int value)
        {
            return false;
        }
    }
}