using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobilePhone
{
    public class GSM
    {
        private static readonly GSM iPhone4S = new GSM("IPhone4S","Apple",1000,"Petko",new Battery(BatteryType.Li_Ion,20,16),new Display(3.5,16));
        private string model;
        private string manufacturer;
        private decimal price;
        private string owner;
        private Battery battery;
        private Display display;
        private List<Call> callHistory = new List<Call>();
       
        
        // Properties
        public List<Call> CallHistory
        {
            get { return this.callHistory; }
        }
       
        public static GSM IPhone4S
        {
            get
            {
                return iPhone4S;
            }
        }
        public string Model
        {
            get { return this.model; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name can not be empty");
                }
                this.model = value;
            }
        }
        public string Manufacturer
        {
            get { return this.manufacturer; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name can not be empty");
                }
                this.manufacturer = value;
            }
        }
        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price must be over or equal to 0");
                }
                this.price = value;
            }
        }
        public string Owner
        {
            get { return this.owner; }
            set { this.owner = value; }
        }
        public Battery Battery
        {
            get { return this.battery; }
            private set { this.battery = value; }
        }
        public Display Display 
        {
            get { return this.display; }
            set { this.display = value; }
        }
        

        // Constructors
        public GSM(string model, string manufacturer)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
        }
        public GSM(string model, string manufacturer, decimal price)
            :this(model,manufacturer)
        {
            this.Price = price;
        }
        public GSM(string model, string manufacturer, decimal price, string owner)
            :this(model,manufacturer,price)
        {
            this.Owner = owner;
        }
        public GSM(string model, string manufacturer, decimal price, string owner, Battery battery)
            : this(model, manufacturer, price,owner)
        {
            this.Battery = battery;
        }
        public GSM(string model, string manufacturer, decimal price, string owner, Battery battery, Display display)
            : this(model, manufacturer, price, owner,battery)
        {
            this.Display = display;
            this.callHistory = new List<Call>();
        }
        public override string ToString()
        {
            return String.Format("Model:{0}\nManufacutrer:{1}\nPrice:{2}\nOwner:{3}\nBattery:{4}\nDisplay:{5}", this.model, this.manufacturer,this.price,this.owner,this.battery,this.display);
        }
        public void AddCall(DateTime datetime, string phoneNumber,uint seconds)
        {
            this.CallHistory.Add(new Call(datetime,phoneNumber,seconds));
        }
        public void DeleteCall(int position)
        {
            this.callHistory.RemoveAt(position);
        }
        public void CallHistoryClear()
        {
            this.callHistory.Clear();
        }
        public decimal CallPrice(decimal pricePerMinute)
        {
            uint priceCalls = 0;
            foreach (var item in callHistory)
            {
                priceCalls += item.Seconds;
            }
            return (priceCalls/60)*pricePerMinute;
        }

    }
}
