using ParcelLocker.Models;
using System.Text.Json;

namespace ParcelLocker.Services
{
    public class ParcelService
    {
        private IParcelStore _parcelStore;

        public ParcelService(IParcelStore parcelStore)
        {
            _parcelStore = parcelStore;
        }
        public async Task<Parcel> Add(AddParcelDTO parcelDto)
        {
            var parcel = new Parcel()
            {
                Destination = parcelDto.Destination,
                WeightGrams = parcelDto.WeightGrams,
                ShippingCostCents = CalculateShipping(parcelDto.WeightGrams),
                ID = Guid.NewGuid()
            };
            parcelDto.Destination.Id = Guid.NewGuid();
            await _parcelStore.SaveData(parcel);
            return parcel;
        }
        private int CalculateShipping(int weightGrams) {
            if(weightGrams < 2) {
                return 500;
            }
            else if(weightGrams < 5)
            {
                return 505;
            }
            else if( weightGrams < 10)
            {
                return 545;
            }
            else if(weightGrams < 20){
                return 930;
            }
            else
            {
                return 1185;
            }
        }
    }
}
