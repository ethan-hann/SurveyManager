using System;
using System.Collections;

namespace SurveyManager.utility.Filtering
{
    /// <summary>
    /// Class representing a list of enumerable filter expressions.
    /// </summary>
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
