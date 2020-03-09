using System;
using System.Collections.Generic;

namespace UQAC_IA_TP2.core
{
    public abstract class Variable<T>
    {
        public List<T> Domain;

        public Variable(List<T> domain)
        {
            Domain = domain;
        }
    }
}