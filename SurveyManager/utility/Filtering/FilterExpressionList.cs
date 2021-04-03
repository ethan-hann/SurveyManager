using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyManager.utility.Filtering
{
    [Serializable()]
    public class FilterExpressionList : IEnumerable, IEnumerator
    {
        readonly ArrayList alItems;
        readonly IEnumerator ienum;

        public FilterExpressionList()
        {
            alItems = new ArrayList();
            ienum = alItems.GetEnumerator();
        }

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        public IFilter Current
        {
            get
            {
                return (IFilter)ienum.Current;
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return ienum.Current;
            }
        }

        public void Reset()
        {
            ienum.Reset();
        }

        public bool MoveNext()
        {
            return ienum.MoveNext();
        }

        public void Add(IFilter filterExpresion)
        {
            alItems.Add(filterExpresion);
        }

        public IFilter this[int index]
        {
            get
            {
                return (IFilter)alItems[index];
            }
            set
            {
                alItems[index] = value;
            }
        }

        public int Count
        {
            get
            {
                return alItems.Count;
            }
        }
    }
}
