using System.Linq;

namespace UQAC_IA_TP2.core.functions
{
    /// <summary>
    /// Algorithme permettant de trier le domaine d'une variable en classant les valeurs de la moins contraignante à la
    /// plus contraignante
    ///
    /// Possède une unique fonction Apply qui retourne la variable avec le domaine trié
    /// </summary>
    public static class LeastConstrainingValueFunction<T>
    {
        public static Variable<T> Apply(Variable<T> variable, CSP<T> csp)
        {
            // On garde toutes contraintes dont la variable est la source de la contraite
            var constraints = csp.Constraints.Where(c => c.Var1.Equals(variable));
            // On recupère toutes les variables constraintes avec la variable source
            var variables = constraints.Select(c => c.Var2);
            
            // inner method
            // Compte le nombre de domaine que l'assignation d'une certaine valeur va réduire
            int CountNbOfDomainReduced(T value)
            {
                var cpt = 0;
                foreach (var v in variables)
                {
                    var c = csp.GetConstraint(variable, v);
                    if (c != null)
                        cpt += (c.WillReduceDomainOfTheSecondVariable(value) ? 1 : 0);
                }
                return cpt;
            }

            // Trie le domaine suivant le nombre de domaine que va réduire chaque valeur
            variable.Domain.Sort(delegate(T val1, T val2)
            {
                var nbOfValuesReduced1 = CountNbOfDomainReduced(val1);
                var nbOfValuesReduced2 = CountNbOfDomainReduced(val2);
                return nbOfValuesReduced1.CompareTo(nbOfValuesReduced2);
            });

            return variable;
        }
    }
}

