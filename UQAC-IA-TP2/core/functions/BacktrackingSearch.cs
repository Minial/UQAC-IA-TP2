using System.Collections.Generic;
using System.Linq;


namespace UQAC_IA_TP2.core.functions
{
    /// <summary>
    /// classe gérant le backtracking des différents cas
    /// </summary>
    public class BacktrackingSearch<T>
    {
        private BacktrackingConfig _config;

        public BacktrackingSearch(BacktrackingConfig config)
        {
            _config = config;
        }
        
        public Assignment<T> Search(CSP<T> csp) => SearchRecursion(new Assignment<T>(), csp);

        private Assignment<T> SearchRecursion(Assignment<T> assignment , CSP<T> csp)
        {
            if (csp.IsComplete(assignment))
                return assignment;
            if (_config.Ac3)
                csp = AC3Function<T>.Apply(csp);
            var curVar = SelectUnassignedVariable(assignment, csp);
            foreach (var value in OrderDomainValue(curVar, assignment, csp))
            {
                if (csp.IsValueConsistent(assignment, curVar, value))
                {
                    assignment.Add(curVar, value);
                    var result = SearchRecursion(assignment, csp);
                    if (result != null)
                        return result;
                    assignment.Remove(curVar, value);
                }
            }
            return null;
        }
        
        
        private Variable<T> SelectUnassignedVariable(Assignment<T> assignment, CSP<T> csp)
        {
            var variables = new List<Variable<T>>();
            foreach (var v in csp.variables)
            {
                if (!assignment.assignment.Keys.Contains(v))
                    variables.Add(v);
            }
            if (_config.Mrv)
                variables = MinimumRemainingValueFunction<T>.Apply(variables);
            if (_config.DegreeHeuristic && variables.Count > 1)
                variables = DegreeHeuristicFunction<T>.Apply(variables, csp);
            return variables[0];
        }
        
        
        private List<T> OrderDomainValue(Variable<T> var, Assignment<T> assignment, CSP<T> csp)
        {
            return _config.Lcv ? LeastConstrainingValueFunction<T>.Apply(var, csp).Domain : var.Domain;
        }
    }
    
    
    
    public class BacktrackingConfig
    {
        public bool Ac3 = false;
        public bool Mrv = false; // minimum remaining value
        public bool DegreeHeuristic = false;
        public bool Lcv = false; // least constraining value

        public BacktrackingConfig WithAc3() { Ac3 = true; return this; }
        public BacktrackingConfig WithMrv() { Mrv = true; return this; }
        public BacktrackingConfig WithDegreeHeuristic() { DegreeHeuristic = true; return this; }
        public BacktrackingConfig WithLcv() { Lcv = true; return this; }
    }
}