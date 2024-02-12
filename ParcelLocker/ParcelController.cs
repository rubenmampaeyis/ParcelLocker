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
        private readonly ParcelStore _parcelStore;

        public ParcelController(ParcelService parcelService, ParcelStore parcelStore)
        {
             _parcelService = parcelService;
            _parcelStore = parcelStore;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _parcelStore.GetData());
        }

        [HttpPost]
        public async Task<IActionResult> AddParcelAsync(AddParcelDTO parcelDto)
        {
            var parcel = await _parcelService.Add(parcelDto);
            return Ok(parcel);
        }
    }
}
