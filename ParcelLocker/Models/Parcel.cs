namespace ParcelLocker.Models
{
    public class Parcel
    {
        public Guid ID{ get; set; }
        public int WeightGrams { get; set; }
        public Address Destination { get; set; }
        public int ShippingCostCents { get; set; }
    }
}
