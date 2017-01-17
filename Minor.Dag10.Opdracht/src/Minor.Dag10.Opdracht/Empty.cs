using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag10.Opdracht
{
    public class Empty<T>
        : BinairyTree<T>
        where T: IComparable<T>
    {
        public Empty()
        {
        }

        public override T this[int index]
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override int Count
        {
            get
            {
                return 0;
            }
        }

        public override BinairyTree<T> Add(T item)
        {
            var temp = new Branch<T>(item);
            return temp;
        }        

        public override bool Contains(T item)
        {
            return false;
        }

        public override IEnumerator<T> GetEnumerator()
        {
            yield break;
        }
    }
}
