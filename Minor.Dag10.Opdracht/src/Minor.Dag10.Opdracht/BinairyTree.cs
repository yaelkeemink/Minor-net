using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag10.Opdracht
{
    public abstract class BinairyTree<T>
        : IEnumerable<T>
        where T: IComparable<T>
    {
        public abstract T this[int index] { get; }
        public abstract int Count { get; }
        public abstract BinairyTree<T> Add(T item);
        public abstract bool Contains(T item);

        public abstract IEnumerator<T> GetEnumerator();

        public BinairyTree<T> AddRange(IEnumerable<T> elementen )
        {
            foreach (var element in elementen)
            {
                Add(element);
            }
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
