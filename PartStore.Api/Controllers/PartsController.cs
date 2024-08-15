using Microsoft.AspNetCore.Mvc;
using PartsStoreAPI.Core.Interfaces;
using PartStore.Domain.Entities;


namespace PartStore.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PartsController : ControllerBase
    {
        private readonly IPartService _partService;

        public PartsController(IPartService partService)
        {
            _partService = partService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Part>>> GetParts()
        {
            return Ok(await _partService.GetAllPartsAsync());
        }

        [HttpPost]
        public async Task<ActionResult<Part>> CreatePart(Part part)
        {
            var createdPart = await _partService.CreatePartAsync(part);
            return CreatedAtAction(nameof(GetParts), new { id = createdPart.Id }, createdPart);
        }
    }
}
