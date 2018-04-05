using System;

namespace Aviation
{
    public class CustomerViewModel
    {
        private Customer selectedCustomer;

        public CustomerViewModel()
        {
        }

        public Customer GetSelectedCustomer()
        {
            selectedCustomer = new Customer();
            selectedCustomer.CustomerFirstName = "John";
            selectedCustomer.CustomerLastName = "Doe";
            selectedCustomer.CustomerAge = 40;
            selectedCustomer.CustomerWeight = 180;
            selectedCustomer.CustomerHasLapChild = true;
            selectedCustomer.OutboundDate = DateTime.Now;
            selectedCustomer.InboundDate = DateTime.Now.AddDays(7);
            selectedCustomer.DepartureAirport = "SFO";
            selectedCustomer.ArrivalAirport = "ORD";

            return selectedCustomer;
        }
    }
}
