using System;
using System.Collections.Generic;

namespace UQAC_IA_TP2.Sudoku
{
    public class Assignment
    {
        
        private HashSet<Tuple<Variable, int>> assignment;

        public Assignment()
        {
            assignment = new HashSet<Tuple<Variable, int>>();
        }

        public void Add(Variable variable, int value)
        {
            assignment.Add(new Tuple<Variable, int>(variable, value));
        }

        public void Remove(Variable variable, int value)
        {
            
        }
    }
}