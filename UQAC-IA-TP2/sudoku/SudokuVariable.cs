using System.Collections.Generic;
using UQAC_IA_TP2.core;

namespace UQAC_IA_TP2.sudoku
{
    /// Implémentation de la classe Variable pour représenter les variables du Sudoku
    ///
    /// En plus d'avoir un domaine de valeur possible (voir Variable), une variable du sudoku possède aussi une
    /// position dans la grille
    public class SudokuVariable : Variable<int>
    {
        public Position Position;
        
        public SudokuVariable(List<int> domain, Position pos) : base(domain)
        {
            Position = pos;
        }
    }
}