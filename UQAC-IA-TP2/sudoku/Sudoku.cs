using System;
using System.Collections.Generic;
using System.Linq;
using UQAC_IA_TP2.core;


namespace UQAC_IA_TP2.sudoku
{
    public class Sudoku : CSP<int>
    {
        private readonly int[,] _grid;
        private readonly int _size;

        public Sudoku(int[,] grid, int size)
        {
            _grid = grid;
            _size = size;
        }

        public override BinaryConstraint<int> GetConstraint(Variable<int> var1, Variable<int> var2)
        {
            var tmp = constraints.Where(c => c.Var1 == var1 && c.Var2 == var1);
            return !tmp.Any() ? null : tmp.First();
        }

        /// Vérifie si l'assignation de la valeur [value] à la variable [variable] est possible
        /// C'est à dire si cette assignation ne viole aucune contrainte du CSP
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

            for (i = 0; i < _size; i++)
            {
                for (j = 0; j < _size; j++)
                {
                    tmp = new SudokuVariable(GetDomain(_grid[i,j]), new Position(j, i));
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

            for (i = 0; i < _size; i++)
            {
                for (j = 0; j < _size; j++)
                {
                    // Contraintes lignes et colonnes
                    for (z = 0; z < _size; z++)
                    {
                        if (j != z) // ligne
                        {
                            v1 = variables.ElementAt(_size * i + j);
                            v2 = variables.ElementAt(_size * i + z);
                            tmp = new ConstraintSudoku(v1, v2);
                            constraints.Add(tmp);
                        }
                        if (i != z) // colonne
                        {
                            v1 = variables.ElementAt(_size * i + j);
                            v2 = variables.ElementAt(_size * z + j);
                            tmp = new ConstraintSudoku(v1, v2);
                            constraints.Add(tmp);
                        }
                    }
                    // Contraintes blocs
                    icell = (int)(i / Math.Sqrt(_size));
                    jcell = (int)(j / Math.Sqrt(_size));

                    for (k = (int)(0 + Math.Sqrt(_size) * icell); k < Math.Sqrt(_size) + Math.Sqrt(_size) * icell; k++)
                    {
                        for (z = (int)(0 + Math.Sqrt(_size) * jcell); z < Math.Sqrt(_size) + Math.Sqrt(_size) * jcell; z++)
                        {
                            if (i != k && j != z)
                            {
                                v1 = variables.ElementAt(_size * i + j);
                                v2 = variables.ElementAt(_size * k + z);
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
            for (i = 0; i < _size; i++)
            {
                for (j = 0; j < _size; j++)
                {
                    Console.Write(_grid[i, j] + " ");
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
                for (int k = 1; k <= _size; k++)
                    domain.Add(k);
            }

            return domain;
        }
    }
}
