﻿namespace ParcelLocker.Models
{
    public class Address
    {
        public Guid Id { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
    }
}
