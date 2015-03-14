using System;

namespace MobilePhone
{
    public class Display
    {
        private double size;
        private int numberOfColours;

        // Properties
        public double Size
        {
            get { return this.size; }
            set
            {
                if (size<0)
                {
                    throw new ArgumentException("Size must be greater than 0");
                }
                this.size = value;
            }
        }
        public int NumberOfColours
        {
            get { return this.numberOfColours;}
            set
            {
                if (numberOfColours < 0)
                {
                    throw new ArgumentException("Number of colours must be greater than 0");
                }
                this.numberOfColours = value;
            } 
        }
        // Constuctors
        public Display()
        {
        }
        public Display(double size,int numberOfColors)
        {
            this.Size = size;
            this.NumberOfColours = numberOfColors;
        }
        public override string ToString()
        {
            return String.Format("Size:{0} Number of colours:{1}", this.size, this.numberOfColours);
        }

    }
}
