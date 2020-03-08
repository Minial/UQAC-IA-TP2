using System;
using System.IO;

namespace UQAC_IA_TP2.sudoku
{
    public class SudokuParser
    {
        
        // Méthode remplissant la grille à partir du ficher sudoku.txt
        // On peut changer le sudoku du fichier par celui que l'on veut
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