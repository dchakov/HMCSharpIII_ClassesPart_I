using System;

namespace MobilePhone
{
    public class Call
    {
        private DateTime dateTime;
        private string phoneNumber;
        private uint seconds;

        // Properties
        public DateTime DateTime
        {
            get { return this.dateTime; }
            set { this.dateTime = value;}
        }
        public string PhoneNumber
        {
            get { return this.phoneNumber; }
            set { this.phoneNumber = value; }
        }
        public uint Seconds
        {
            get { return this.seconds; }
            set { this.seconds = value; }
        }
        // Constructor
        public Call(DateTime dateTime,string phoneNumber,uint seconds)
        {
            this.DateTime = dateTime;
            this.PhoneNumber = phoneNumber;
            this.Seconds = seconds;
        }
       
        // Tostring
        public override string ToString()
        {
            return String.Format("DateTime:{0} Phone number:{1} Seconds talk:{2}",this.dateTime,this.phoneNumber,this.seconds);
        }

    }
}
