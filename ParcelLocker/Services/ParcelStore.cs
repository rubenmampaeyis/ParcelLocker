using Microsoft.EntityFrameworkCore;
using ParcelLocker.Models;

namespace ParcelLocker.Services
{

    public class ParcelContext : DbContext
    {
        public DbSet<Parcel> Parcels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "ParcelStore");
        }
    }
    public class ParcelStore(ParcelContext _dbContext)
    {

        public async Task SaveData(Parcel data)
        {
            _dbContext.Parcels.Add(data);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Parcel[]> GetData()
        {
            return await _dbContext.Parcels.Include(p => p.Destination).ToArrayAsync();
        }
    }
}
