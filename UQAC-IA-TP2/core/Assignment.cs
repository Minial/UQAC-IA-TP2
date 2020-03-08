using System;
using System.Collections.Generic;

namespace UQAC_IA_TP2.sudoku
{
    public class Assignment<T>
    {
        
        public Dictionary<Variable<T>, T> assignment;

        public Assignment()
        {
            assignment = new Dictionary<Variable<T>, T>();
        }

        public void Add(Variable<T> variable, T value)
        {
            assignment.Add(variable, value);
        }

        public void Remove(Variable<T> variable, T value)
        {
            assignment.Remove(variable);
        }
    }
}