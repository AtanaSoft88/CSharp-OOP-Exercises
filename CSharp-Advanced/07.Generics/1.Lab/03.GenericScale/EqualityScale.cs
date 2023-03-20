using System;
using System.Collections.Generic;
using System.Text;

namespace GenericScale
{
    public class EqualityScale<T> where T : struct
    {
        
        public EqualityScale(T elementLeft, T elementRight)
        {
            this.Left = elementLeft;
            this.Right = elementRight;
        }


        public T Left { get; set; }
        public T Right { get; set; }


        public bool AreEqual()
        {

            return Left.Equals(Right);



        }
    }
}
