using System.Collections;
using System.Collections.Generic;

namespace UQAC_IA_TP2.sudoku
{
    public class Domain<T> : IEnumerable<T>
    {
        private List<T> _values;

        public Domain(List<T> values)
        {
            _values = values;
        }

        public int Count() => _values.Count;
        
        
        public IEnumerator<T> GetEnumerator() => _values.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}