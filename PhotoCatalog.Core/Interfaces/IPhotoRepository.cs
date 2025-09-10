using PhotoCatalog.Core.Entities;

namespace PhotoCatalog.Core.Interfaces;

public interface IPhotoRepository
{
    Task<List<Photo>> GetAllPhotosAsync(CancellationToken cancellationToken);
    Task<Photo?> GetPhotoByIdAsync(int id, CancellationToken cancellationToken);
    Task AddPhotoAsync(Photo photo, CancellationToken cancellationToken);
    Task DeletePhotoByIdAsync(Photo photo, CancellationToken cancellationToken);
}
