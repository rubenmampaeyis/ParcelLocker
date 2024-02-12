using ParcelLocker.Models;
using System.Text.Json;

namespace ParcelLocker.Services
{
    public class FileStore
    {
        private readonly string _filePath;

        public FileStore()
        {
            _filePath = Path.Combine(Environment.CurrentDirectory, "data.json");
        }
        public async Task SaveData(Parcel data)
        {
            try
            {
                var allParcels = await GetData();
                Parcel[] newData = [.. allParcels, data];
                var jsonData = JsonSerializer.Serialize(newData);

                await File.WriteAllTextAsync(_filePath, jsonData);
                Console.WriteLine("Data successfully written to JSON file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing data to JSON file: {ex.Message}");
            }
        }

        public async Task<Parcel[]> GetData()
        {
            try
            {
                if (File.Exists(_filePath))
                {
                    string jsonData = await File.ReadAllTextAsync(_filePath);
                    return JsonSerializer.Deserialize<Parcel[]>(jsonData) ?? [];
                }
                else
                {
                    Console.WriteLine("File does not exist.");
                    return [];
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading data from JSON file: {ex.Message}");
                return [];
            }
        }
    }
}
