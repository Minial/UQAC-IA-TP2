using System;
using System.Linq;
using UQAC_IA_TP2.core;
using UQAC_IA_TP2.core.functions;
using UQAC_IA_TP2.sudoku;



namespace UQAC_IA_TP2
{
    /// <summary>
    /// Classe principale du programme (création du sudoku, résolution affichage du résultat)
    /// </summary>
    internal static class Application
    {
        private static void Main(string[] args)
        {
            // On génère le Sudoku
            Console.Write("Saisir la taille du Sudoku : ");
            string saisie = Console.ReadLine();
            int size = int.Parse(saisie);
            var sudoku = SudokuParser.GenerateSudoku(size);
            sudoku.PrintGrid();
            
            // On résout le Sudoku
            var config = new BacktrackingConfig().WithMrv().WithLcv().WithDegreeHeuristic().WithAc3();
            var assignment = sudoku.Resolve(config);
            
            // On affiche l'assignement obtenu
            PrintSudokuAssignement(assignment,size);
        }
        

        private static void PrintSudokuAssignement(Assignment<int> assignment, int size)
        {
            var assignmentList = assignment.assignment.ToList();
            assignmentList.Sort((pair1, pair2) =>
                ((SudokuVariable) pair1.Key).Position.CompareTo(((SudokuVariable) pair2.Key).Position)
            );
            int i = 0;
            foreach (var pair in assignmentList)
            {
                if (i % size == 0) Console.WriteLine();
                Console.Write(pair.Value + " ");
                i++;
            }
            Console.WriteLine();
        }
    }
}