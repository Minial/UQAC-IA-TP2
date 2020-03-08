using System.Collections.Generic;

namespace UQAC_IA_TP2.sudoku
{
    public class SudokuVariable : Variable<int>
    {
        public Position Position;
        
        public SudokuVariable(List<int> domain, Position pos) : base(domain)
        {
            Position = pos;
        }
    }
}