using System;
using System.Collections.Generic;
using System.Linq;

namespace UQAC_IA_TP2.sudoku
{
    public abstract class CSP<T>
    {
        public List<Variable<T>> variables;
        public List<BinaryConstraint<T>> constraints;

        public Assignment<T> Resolve()
        {
            GenerateVariables();
            GenerateConstraints();
            return new BacktrackingSearch<T>().Search(this);
        }
        
        public bool IsComplete(Assignment<T> assignment)
        {
            return assignment.assignment.Count == variables.Count;
        }

        public abstract bool IsValueConsistent(Assignment<T> assignment, Variable<T> variable, T value);

        protected abstract void GenerateConstraints();
        
        protected abstract void GenerateVariables();
    }
}