using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        //•	void Add(element) – adds an element on the top of the list.
        //•	element Remove() – removes the topmost element.
        //•	int Count { get; }

        private Stack<T> elementsStack;

        public Box()
        {
            elementsStack = new Stack<T>();
        }
        public int Count { get => elementsStack.Count; }

       
        public void Add(T element)
        {

            elementsStack.Push(element);
        
        
        }
        
        public T Remove()
        {

            T tempElement = elementsStack.Peek();
            elementsStack.Pop();

            return tempElement;
        
        
        }
    }
}
