using System;
using System.Collections.Generic;
using System.Linq;
using UQAC_IA_TP2.core;


namespace UQAC_IA_TP2.sudoku
{
    /// <summary>
    /// Classe représentant le CSP d'un Sudoku
    /// 
    /// Champs : 
    ///     - _grid : contient les valeurs initiales de la grille de sudoku
    ///     - _size : taille de la grille de sudoku
    ///
    /// Méthodes :
    ///     - GetConstraint(var1, var2) : retourne la contrainte impliquant va1 et var2 (null sinon)
    ///     - IsValueConsistent(assignement, var, value) : vérifie si l'assignation d'une valeur à l'une des cases de la
    ///                                                    grille est possible avec un certain assignement
    ///     - GenerateVariables() : génère toutes les variables du CSP (une pour chaque case)
    ///     - GenerateConstraints() : génère toutes les contraintes binaires de la grille du sudoku
    ///     - PrintGrid() : affiche la grille
    /// </summary>
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
            var tmp = Constraints.Where(c => c.Var1 == var1 && c.Var2 == var1);
            return !tmp.Any() ? null : tmp.First();
        }

        /// Vérifie si l'assignation de la valeur [value] à la variable [variable] est possible
        /// C'est à dire si cette assignation ne viole aucune contrainte du CSP
        public override bool IsValueConsistent(Assignment<int> assignment, Variable<int> variable, int value)
        {
            foreach (var pair in assignment.assignment)
            {
                foreach (var constraint in Constraints)
                {
                    if (variable.Equals(constraint.Var1) && pair.Key.Equals(constraint.Var2) && pair.Value.Equals(value))
                        return false;
                }
            }
            return true;
        }
        

        // Génère toutes les variables associées à chaque case
        protected override void GenerateVariables()
        {
            Variables = new List<Variable<int>>();
            for (var i = 0; i < _size; i++)
            {
                for (var j = 0; j < _size; j++)
                    Variables.Add(new SudokuVariable(GetDomain(_grid[i,j]), new Position(j, i)));
            }
        }
        

        /// Génère toutes les contraintes du sudoku (lignes, colonnes, blocs)
        protected override void GenerateConstraints()
        {
            Constraints = new List<BinaryConstraint<int>>();

            for (var i = 0; i < _size; i++)
            {
                for (var j = 0; j < _size; j++)
                {
                    // Contraintes lignes et colonnes
                    for (var z = 0; z < _size; z++)
                    {
                        if (j != z) // ligne
                            Constraints.Add(new ConstraintSudoku(Variables.ElementAt(_size * i + j),  Variables.ElementAt(_size * i + z)));
                        if (i != z) // colonne
                                Constraints.Add(new ConstraintSudoku(Variables.ElementAt(_size * i + j), Variables.ElementAt(_size * z + j)));
                    }
                    // Contraintes blocs
                    var icell = (int)(i / Math.Sqrt(_size));
                    var jcell = (int)(j / Math.Sqrt(_size));
                    for (var k = (int)(0 + Math.Sqrt(_size) * icell); k < Math.Sqrt(_size) + Math.Sqrt(_size) * icell; k++)
                    {
                        for (var z = (int)(0 + Math.Sqrt(_size) * jcell); z < Math.Sqrt(_size) + Math.Sqrt(_size) * jcell; z++)
                        {
                            if (i != k && j != z)
                                Constraints.Add(new ConstraintSudoku(Variables.ElementAt(_size * i + j), Variables.ElementAt(_size * k + z)));
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
