using System;
using Telerik.XamarinForms.Common;
using Telerik.XamarinForms.Common.DataAnnotations;

namespace Aviation
{
    public class Customer : NotifyPropertyChangedBase
    {
        private string customerFirstName;
        private string customerLastName;
        private int customerAge;
        private double customerWeight;
        private bool customerHasLapChild;
        private DateTime outboundDate;
        private string departureAirport;
        private DateTime inboundDate;
        private string arrivalAirport;

        [DisplayOptions(Header = "First Name", Group = "Customer Info", Position = 1)]
        [NonEmptyValidator("Please enter first name", "OK")]
        public string CustomerFirstName
        {
            get
            {
                return this.customerFirstName;
            }
            set
            {
                this.customerFirstName = value;
                this.OnPropertyChanged("CustomerFirstName");
            }
        }

        [DisplayOptions(Header = "Last Name", Group = "Customer Info", Position = 2)]
        [NonEmptyValidator("Please enter last name", "OK")]
        public string CustomerLastName
        {
            get
            {
                return this.customerLastName;
            }
            set
            {
                this.customerLastName = value;
                this.OnPropertyChanged("CustomerLastName");
            }
        }

        [DisplayOptions(Header = "Age", Group = "Customer Info", Position = 3)]
        [NumericalRangeValidator(0, 100)]
        public int CustomerAge
        {
            get { return this.customerAge; }
            set
            {
                if (value != this.customerAge)
                {
                    this.customerAge = value;
                    OnPropertyChanged("CustomerAge");
                }
            }
        }

        [DisplayOptions(Header = "Has Lap Child", Group = "AirCraft Config", Position = 1)]
        public bool CustomerHasLapChild
        {
            get { return this.customerHasLapChild; }
            set
            {
                if (value != this.customerHasLapChild)
                {
                    this.customerHasLapChild = value;
                    OnPropertyChanged("CustomerHasLapChild");
                }
            }
        }

        [DisplayOptions(Header = "Weight (Lb)", Group = "AirCraft Config", Position = 2)]
        public double CustomerWeight
        {
            get { return this.customerWeight; }
            set
            {
                if (value != this.customerWeight)
                {
                    this.customerWeight = value;
                    OnPropertyChanged("CustomerWeight");
                }
            }
        }

        [DisplayOptions(Header = "Outbound Date", Group = "Flight Info", Position = 1)]
        public DateTime OutboundDate
        {
            get { return this.outboundDate; }
            set
            {
                if (value != this.outboundDate)
                {
                    this.outboundDate = value;
                    OnPropertyChanged("OutboundDate");
                }
            }
        }

        [DisplayOptions(Header = "Inbound Date", Group = "Flight Info", Position = 2)]
        public DateTime InboundDate
        {
            get { return this.inboundDate; }
            set
            {
                if (value != this.inboundDate)
                {
                    this.inboundDate = value;
                    OnPropertyChanged("InboundDate");
                }
            }
        }

        [DisplayOptions(Header = "From", Group = "Flight Info", Position = 3)]
        [NonEmptyValidator("Please enter departure airport", "OK")]
        public string DepartureAirport
        {
            get
            {
                return this.departureAirport;
            }
            set
            {
                this.departureAirport = value;
                this.OnPropertyChanged("DepartureAirport");
            }
        }

        [DisplayOptions(Header = "To", Group = "Flight Info", Position = 4)]
        [NonEmptyValidator("Please enter arrival airport", "OK")]
        public string ArrivalAirport
        {
            get
            {
                return this.arrivalAirport;
            }
            set
            {
                this.arrivalAirport = value;
                this.OnPropertyChanged("ArrivalAirport");
            }
        }

        public Customer()
        {
        }
    }
}
