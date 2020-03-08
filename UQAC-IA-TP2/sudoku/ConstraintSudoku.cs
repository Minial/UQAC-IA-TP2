namespace UQAC_IA_TP2.sudoku
{
    public class ConstraintSudoku : BinaryConstraint<int>
    {
        public ConstraintSudoku(Variable<int> var1, Variable<int> var2) : base(var1, var2)
        {
        }
        
    }
}