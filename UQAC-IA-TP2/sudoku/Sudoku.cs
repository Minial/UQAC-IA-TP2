using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UQAC_IA_TP2.sudoku
{
    public class Sudoku : CSP<int>
    {
        public int[,] grid;
        public int size;

        public Sudoku(int[,] grid, int size)
        {
            this.grid = grid;
            this.size = size;
        }
        

        public override bool IsValueConsistent(Assignment<int> assignment, Variable<int> variable, int value)
        {
            foreach (var pair in assignment.assignment)
            {
                foreach (var constraint in constraints)
                {
                    if (variable.Equals(constraint.Var1) && pair.Key.Equals(constraint.Var2) && pair.Value.Equals(value))
                        return false;
                }
            }
            return true;
        }
        
        
        // Obtenir les variables
        protected override void GenerateVariables()
        {
            Variable<int> tmp;
            variables = new List<Variable<int>>();
            int i, j;

            for (i = 0; i < size; i++)
            {
                for (j = 0; j < size; j++)
                {
                    tmp = new SudokuVariable(GetDomain(grid[i,j]), new Position(j, i));
                    variables.Add(tmp);
                }
            }
        }


        protected override void GenerateConstraints()
        {
            ConstraintSudoku tmp;
            Variable<int> v1, v2;
            constraints = new List<BinaryConstraint<int>>();
            int i, j, k, z, icell, jcell;

            for (i = 0; i < size; i++)
            {
                for (j = 0; j < size; j++)
                {
                    // Contraintes lignes et colonnes
                    for (z = 0; z < size; z++)
                    {
                        if (j != z) // ligne
                        {
                            v1 = variables.ElementAt(size * i + j);
                            v2 = variables.ElementAt(size * i + z);
                            tmp = new ConstraintSudoku(v1, v2);
                            constraints.Add(tmp);
                        }
                        if (i != z) // colonne
                        {
                            v1 = variables.ElementAt(size * i + j);
                            v2 = variables.ElementAt(size * z + j);
                            tmp = new ConstraintSudoku(v1, v2);
                            constraints.Add(tmp);
                        }
                    }
                    // Contraintes blocs
                    icell = (int)(i / Math.Sqrt(size));
                    jcell = (int)(j / Math.Sqrt(size));

                    for (k = (int)(0 + Math.Sqrt(size) * icell); k < Math.Sqrt(size) + Math.Sqrt(size) * icell; k++)
                    {
                        for (z = (int)(0 + Math.Sqrt(size) * jcell); z < Math.Sqrt(size) + Math.Sqrt(size) * jcell; z++)
                        {
                            if (i != k && j != z)
                            {
                                v1 = variables.ElementAt(size * i + j);
                                v2 = variables.ElementAt(size * k + z);
                                tmp = new ConstraintSudoku(v1, v2);
                                constraints.Add(tmp);
                            }
                        }
                    }
                }
            }
        }
        
        // Méthode d'affichage de la grille
        public void PrintGrid()
        {
            int i, j;
            for (i = 0; i < size; i++)
            {
                for (j = 0; j < size; j++)
                {
                    Console.Write(grid[i, j] + " ");
                }
                Console.Write("\n");
            }
        }

        private List<int> GetDomain(int value)
        {
            var domain = new List<int>();
            if (value != 0)
            {
                domain.Add(value);
            }
            else
            {
                for (int k = 1; k <= size; k++)
                    domain.Add(k);
            }

            return domain;
        }
    }
}
