using System.Collections.Generic;

namespace UQAC_IA_TP2.core
{
    /// <summary>
    /// Associe chaque variable avec une valeur.
    ///
    /// Encapsule simplement un dictionnaire et défini deux méthodes Add et Remove 
    /// </summary>
    public class Assignment<T>
    {
        
        public Dictionary<Variable<T>, T> assignment;

        public Assignment()
        {
            assignment = new Dictionary<Variable<T>, T>();
        }

        public void Add(Variable<T> variable, T value)
        {
            assignment.Add(variable, value);
        }

        public void Remove(Variable<T> variable, T value)
        {
            assignment.Remove(variable);
        }
    }
}