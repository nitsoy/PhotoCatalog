using PhotoCatalog.Core.Contracts;

namespace PhotoCatalog.Core.Services;

public interface IPhotoService
{
    Task<List<PhotoDto>> GetAllPhotosAsync(CancellationToken cancellationToken);
    Task<PhotoDto?> GetPhotoByIdAsync(int id, CancellationToken cancellationToken);
    Task<PhotoDto> CreatePhotoAsync(CreatePhotoRequest request, CancellationToken cancellationToken);
    Task UpdatePhotoByIdAsync(int id, UpdatePhotoRequest request, CancellationToken cancellationToken);
    Task DeletePhotoByIdAsync(int id, CancellationToken cancellationToken);
}
