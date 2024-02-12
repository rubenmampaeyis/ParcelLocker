using Microsoft.AspNetCore.Mvc;
using ParcelLocker.Models;
using ParcelLocker.Services;

namespace ParcelLocker
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParcelController : ControllerBase
    {
        private readonly ParcelService _parcelService;
        private readonly FileStore _fileStore;

        public ParcelController(ParcelService parcelService, FileStore fileStore)
        {
             _parcelService = parcelService;
            _fileStore = fileStore;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _fileStore.GetData());
        }

        [HttpPost]
        public async Task<IActionResult> AddParcelAsync(AddParcelDTO parcelDto)
        {
            var parcel = await _parcelService.Add(parcelDto);
            return Ok(parcel);
        }
    }
}
