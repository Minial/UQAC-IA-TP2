using System.Collections.Generic;
using System.Threading;
using UQAC_IA_TP2.sudoku;
using UQAC_IA_TP2.sudoku.heuristics;
using UQAC_TP1_IA.core;
using UQAC_TP1_IA.core.functions;
using UQAC_TP1_IA.mansion;


namespace UQAC_IA_TP2
{
    /// <summary>
    /// 
    /// </summary>
    internal static class Application
    {
        private static void Main(string[] args)
        {
            var selectionFunction = new MinimumRemainingValueFunction<int>();
            selectionFunction.SetNext(new DegreeHeuristicFunction<int>());
            var valueOrderingFunction = new LeastConstrainingValueFunction<int>();
            var inferenceFunction = new AC3Function<int>();
            
            var sudoku = new Sudoku();
            var backtracking = new BacktrackingSearch<int>(selectionFunction, valueOrderingFunction, inferenceFunction);
            var finalAssignment = sudoku.Resolve(backtracking);
        }
    }
}