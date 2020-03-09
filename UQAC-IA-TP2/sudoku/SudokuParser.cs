using System;
using System.IO;

namespace UQAC_IA_TP2.sudoku
{
    /// <summary>
     /// classe permettant la lecture d'un sudoku depuis un fichier
     /// 
     /// Méthode :
     ///     - GenerateSudoku() : permet la lecture du fichier, nécessite juste de connaitre la taille de la grille à l'avance
     /// </summary>
    public class SudokuParser
    {
        
        public static Sudoku GenerateSudoku(int size)
        {
            int[,] grid = new int[size, size];
            char c;
            int value, i, j;
            StreamReader strReader;
            strReader = new StreamReader("../../../sudoku.txt");
            i = 0;
            j = 0;
            do
            {
                c = (char)strReader.Read();
                value = (int)Char.GetNumericValue(c);
                if (j < size)
                {
                    grid[i, j] = value;
                    j++;
                }
                else
                {
                    i++;
                    j = 0;
                    grid[i, j] = value;
                    j++;
                }
            } while (!strReader.EndOfStream && (i<size-1 || j < size-1));
            return new Sudoku(grid, size);
        }
    }
}