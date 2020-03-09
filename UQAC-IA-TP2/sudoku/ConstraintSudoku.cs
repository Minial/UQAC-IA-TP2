using UQAC_IA_TP2.core;

namespace UQAC_IA_TP2.sudoku
{
    public class ConstraintSudoku : BinaryConstraint<int>
    {
        public ConstraintSudoku(Variable<int> var1, Variable<int> var2) : base(var1, var2)
        {
        }
        
        public override bool SatisfyConstraint(int valueI)
        {
            var allowed = false;
            foreach (var y in Var2.Domain)
            {
                if (valueI != y)
                    allowed = true;
            }
            return allowed;
        }
    }
}