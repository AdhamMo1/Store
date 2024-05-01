using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.OrderAggregate
{
    public class Address : BaseEntity
    {
        public Address()
        {
            
        }
        public Address(string fName,string lName,string address1,string address2,string street,string city,string state,string zipCode)
        {
            FName = fName;
            LName = lName;
            Address1 = address1;
            Address2 = address2;
            Street = street;
            City = city;
            State = state;
            ZipCode = zipCode;
        }
        public string? FName { get; set; }
        public string? LName { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }
        
    }
}
