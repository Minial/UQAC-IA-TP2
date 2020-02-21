using System;
using System.Collections.Generic;

namespace UQAC_IA_TP2.Sudoku
{
    public class Assignment
    {
        
        public Dictionary<Variable, dynamic> assignment;

        public Assignment()
        {
            assignment = new Dictionary<Variable, dynamic>();
        }

        public void Add(Variable variable, dynamic value)
        {
            assignment.Add(variable, value);
        }

        public void Remove(Variable variable, dynamic value)
        {
            assignment.Remove(variable);
        }
    }
}