using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        double length;
        double width;
        double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }
        public double Length
        {
            get => this.length;
            private set
            {
                this.ThrowCurrentException(value, nameof(this.Length));
            }

        }
        public double Width
        {
            get => this.width;
            private set
            {
                this.ThrowCurrentException(value, nameof(this.Width));
            }

        }
        public double Height
        {
            get => this.height;
            private set
            {
                this.ThrowCurrentException(value, nameof(this.Height));
            }

        }
                //volume = length* width * heigth;
                //lateralSurfaceArea = 2 * length* heigth + 2 * width* heigth;
                //surfaceArea = 2 * (length* width +  length* heigth + width* heigth);
        public double Volume(double length,double width, double heigth)
        {
            double volume = 0;
            volume = length * width * heigth;
            return volume;
        }
        public double SurfaceArea(double length, double width, double heigth)
        {
            double surfaceArea = 0;
            surfaceArea =  2 * (length * width + length * heigth + width * heigth);
            return surfaceArea;
        }
        public double LateralSurfaceArea(double length, double width, double heigth)
        {
            double lateralSurfaceArea = 0;
            lateralSurfaceArea = 2 * length * heigth + 2 * width * heigth;
            return lateralSurfaceArea;
        }

        private void ThrowCurrentException(double value, string sideName)
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{sideName} cannot be zero or negative.");
            }
            
        }

    }
}
