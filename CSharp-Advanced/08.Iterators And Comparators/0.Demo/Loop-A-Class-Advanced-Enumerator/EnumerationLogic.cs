using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loop_A_Class_Advanced_Enumerator
{
    public class EnumerationLogic : IEnumerator<string> // Get all string properties to iterate through
    {
        private List<string> elements;
        private int index; // initial index where we want to start iteration from

        public EnumerationLogic(List<string> elements)
        {
            this.elements = elements;
            this.index = -1;
        }
        public string Current => this.elements[index];
        
        public bool MoveNext()
        {
            this.index++;
            if (index >= elements.Count) // no more elements to iterate through
            {
                return false;
            }
            else          // There are more elements to iterate through
            {
                return true;
            }

        }

        public void Reset()
        {
            this.index = -1;
        }

        object IEnumerator.Current => this.Current; // Legacy reasons kept used, but not important now
        public void Dispose()
        {
            // Not important 
        }
    }
}
