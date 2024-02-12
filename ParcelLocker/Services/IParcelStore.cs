using ParcelLocker.Models;

namespace ParcelLocker.Services
{
    public interface IParcelStore
    {
        Task SaveData(Parcel data);
        Task<Parcel[]> GetData();
    }
}
