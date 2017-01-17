using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag10.Opdracht
{
    public class Branch<T>        
        : BinairyTree<T>
        where T : IComparable<T>
    {
        private T _item { get; set; }
        private BinairyTree<T> _links { get; set; }
        private BinairyTree<T> _rechts { get; set; }

        public override int Count
        {
            get
            {
                return 1 + _links.Count + _rechts.Count;
            }
        }
        
        public override T this[int index]
        {
            get
            {
                foreach (var item in this)
                {
                    if (index == 0)
                    {
                        return item;
                    }
                    index--;
                }
                return _item;
            }
        }

        public Branch(T item)
        {
            _item = item;
            _links = new Empty<T>();
            _rechts = new Empty<T>();
        }
 
        public override BinairyTree<T> Add(T item)
        {

            if (item.CompareTo(_item) == 0)
            {
                return this;
            }
            if (item.CompareTo(_item) == -1)
            {
                if(_links.Count == 0)
                {
                    _links = _links.Add(item);
                }
                _links.Add(item);
                return _links;
            }
            if (_rechts.Count == 0)
            {
                _rechts = _rechts.Add(item);
            }            
            _rechts.Add(item);
            return _rechts;            
        }

        public override bool Contains(T item)
        {
            if(item.CompareTo(_item) == 0)
            {
                return true;
            }
            else if(item.CompareTo(_item) == 1)
            {
                return _rechts.Contains(item);
            }
            else
            {
                return _links.Contains(item);
            }
        }

        public override IEnumerator<T> GetEnumerator()
        {            
            foreach (var item in _links)
            {
                yield return item;
            }            

            yield return _item;
            
            foreach (var item in _rechts)
            {
                yield return item;
            }            
        }
    }
}
