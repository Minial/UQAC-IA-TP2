using System.Collections.Generic;

namespace UQAC_IA_TP2.core
{
    /// <summary>
    /// Une variable est défini sur un domaine, on considère des domaines discret, donc représenté par une liste de
    /// valeur que la variable peut prendre.
    /// </summary>
    public abstract class Variable<T>
    {
        public List<T> Domain;

        public Variable(List<T> domain)
        {
            Domain = domain;
        }
    }
}