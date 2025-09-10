using Microsoft.AspNetCore.Mvc;
using PhotoCatalog.Core.Contracts;
using PhotoCatalog.Core.Services;

namespace PhotoCatalog.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PhotosController(IPhotoService service) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PhotoDto>>> GetAllPhotos(CancellationToken ct)
    {
        return Ok(await service.GetAllPhotosAsync(ct));
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<PhotoDto>> GetPhotoById(int id, CancellationToken ct)
    {
        var p = await service.GetPhotoByIdAsync(id, ct);
        return p is null ? NotFound() : Ok(p);
    }

    [HttpPost]
    public async Task<ActionResult<PhotoDto>> CreatePhoto([FromBody] CreatePhotoRequest body, CancellationToken ct)
    {
        var created = await service.CreatePhotoAsync(body, ct);
        return CreatedAtAction(nameof(CreatePhoto), new { id = created.Id }, created);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdatePhotoById(int id, [FromBody] UpdatePhotoRequest body, CancellationToken ct)
    {
        await service.UpdatePhotoByIdAsync(id, body, ct);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeletePhotoById(int id, CancellationToken ct)
    {
        await service.DeletePhotoByIdAsync(id, ct);
        return NoContent();
    }
}
