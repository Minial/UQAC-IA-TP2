using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic;
using UQAC_IA_TP2.sudoku.heuristics;


namespace UQAC_IA_TP2.sudoku
{
    public class BacktrackingSearch<T>
    {
        public bool Ac3 = false;
        public bool Mrv = true; // minimum remaining value
        public bool DegreeHeuristic = true;
        public bool Lcv = false; // least constraining value
        
        public Assignment<T> Search(CSP<T> csp) => SearchRecursion(new Assignment<T>(), csp);

        private Assignment<T> SearchRecursion(Assignment<T> assignment , CSP<T> csp)
        {
            if (csp.IsComplete(assignment))
                return assignment;
            if (Ac3)
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
            if (Mrv)
                variables = MinimumRemainingValueFunction<T>.Apply(variables);
            if (DegreeHeuristic && variables.Count > 1)
                variables = DegreeHeuristicFunction<T>.Apply(variables, csp);
            return variables[0];
        }
        
        
        private List<T> OrderDomainValue(Variable<T> var, Assignment<T> assignment, CSP<T> csp)
        {
            var domain = new List<T>(var.Domain);
            if (Lcv)
                domain = LeastConstrainingValueFunction<T>.Apply(var, csp);
            return domain;
        }
    }
}