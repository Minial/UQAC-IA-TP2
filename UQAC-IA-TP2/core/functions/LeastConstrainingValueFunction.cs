using System.Linq;

namespace UQAC_IA_TP2.core.functions
{
    public class LeastConstrainingValueFunction<T>
    {
        public static Variable<T> Apply(Variable<T> variable, CSP<T> csp)
        {
            // On garde toutes contraintes dont la variable est la source de la contraite
            var constraints = csp.constraints.Where(c => c.Var1.Equals(variable));
            // On recupère toutes les variables constraintes avec la variable source
            var variables = constraints.Select(c => c.Var2);
            

            int CountValuesReduced(T value)
            {
                return variables.Count(v => v.Domain.Contains(value));
            }

            variable.Domain.Sort(delegate(T val1, T val2)
            {
                var nbOfValuesReduced1 = CountValuesReduced(val1);
                var nbOfValuesReduced2 = CountValuesReduced(val2);
                return nbOfValuesReduced1.CompareTo(nbOfValuesReduced2);
            });

            return variable;
        }
    }
}

