using System;
using System.Collections.Generic;
using System.Linq;
using UQAC_IA_TP2.sudoku;
using UQAC_IA_TP2.sudoku.heuristics;



namespace UQAC_IA_TP2
{
    /// <summary>
    /// 
    /// </summary>
    internal static class Application
    {
        private static void Main(string[] args)
        {
            // On génère le Sudoku
            // Console.Write("Saisir la taille du Sudoku : ");
            // string saisie = Console.ReadLine();
            // int size = int.Parse(saisie);
            var sudoku = SudokuParser.GenerateSudoku(9);
            sudoku.PrintGrid();
            
            // On résout le Sudoku
            var assignment = sudoku.Resolve();
            var assignmentList = assignment.assignment.ToList();
            assignmentList.Sort((pair1, pair2) =>
                ((SudokuVariable) pair1.Key).Position.CompareTo(((SudokuVariable) pair2.Key).Position)
            );

            int i = 0;
            foreach (var pair in assignmentList)
            {
                if (i % 9 == 0) Console.WriteLine();
                Console.Write(pair.Value + " ");
                i++;
            }
            Console.WriteLine();

        }
    }
}