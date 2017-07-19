using System;
using System.Collections;
using System.Collections.Generic;
using TopsisLIB.Models;

namespace TopsisLIB.DataCollections
{
    internal class ProducentEnumerator : IEnumerator<producent>
    {
        private List<producent> producent;
        int index = 0;

        public ProducentEnumerator(List<producent> producent)
        {
            this.producent = producent;
        }
        public producent Current
        {
            get
            {
                return producent[index];
            }
        }

        object IEnumerator.Current
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Dispose()
        {
            index = 0;
        }

        public bool MoveNext()
        {
            index++;

            if (producent.Count <= index + 1)
            {
                index--;
                return false;
            }
            else
                return true;
        }

        public void Reset()
        {
            index = 0;
        }
    }
}