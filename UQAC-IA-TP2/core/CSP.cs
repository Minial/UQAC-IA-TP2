using System.Collections.Generic;
using UQAC_IA_TP2.core.functions;

namespace UQAC_IA_TP2.core
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class CSP<T>
    {
        public List<Variable<T>> Variables;
        public List<BinaryConstraint<T>> Constraints;
        

        /// 1. Génère les variables du problème (implémenté par la classe Sudoku)
        /// 2. Génère les contraintes binaires du problème (implémenté par la classe Sudoku)
        /// 3. Résout le CSP avec l'algorithme du backtracking
        ///
        /// Retourne l'assignement des variables finalement obtenus
        public Assignment<T> Resolve(BacktrackingConfig config)
        {
            GenerateVariables();
            GenerateConstraints();
            return new BacktrackingSearch<T>(config).Search(this);
        }
        
        /// L'assignement est complet lorsque toutes les variables ont été assignées à une valeur
        public bool IsComplete(Assignment<T> assignment)
        {
            return assignment.assignment.Count == Variables.Count;
        }

        public abstract BinaryConstraint<T> GetConstraint(Variable<T> var1, Variable<T> var2);

        public abstract bool IsValueConsistent(Assignment<T> assignment, Variable<T> variable, T value);

        protected abstract void GenerateConstraints();
        
        protected abstract void GenerateVariables();
    }
}