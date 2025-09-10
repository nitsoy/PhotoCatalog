using PhotoCatalog.Core.Contracts;
using PhotoCatalog.Core.Entities;
using PhotoCatalog.Core.Interfaces;

namespace PhotoCatalog.Core.Services;

public class PhotoService : IPhotoService
{
    private readonly IPhotoRepository _photoRepository;
    private readonly IUnitOfWork _uow;

    public PhotoService(IPhotoRepository photoRepository, IUnitOfWork uow)
    {
        _photoRepository = photoRepository;
        _uow = uow;
    }

    public async Task<List<PhotoDto>> GetAllPhotosAsync(CancellationToken cancellationToken)
    {
        var items = await _photoRepository.GetAllPhotosAsync(cancellationToken);
        return items.Select(ToDto).ToList();
    }

    public async Task<PhotoDto?> GetPhotoByIdAsync(int id, CancellationToken cancellationToken)
    {
        var p = await _photoRepository.GetPhotoByIdAsync(id, cancellationToken);
        return p is null ? null : ToDto(p);
    }

    public async Task<PhotoDto> CreatePhotoAsync(CreatePhotoRequest request, CancellationToken cancellationToken)
    {
        var photo = new Photo(request.Title, request.Url, request.TakenAt, request.Tags);
        await _photoRepository.AddPhotoAsync(photo, cancellationToken);
        await _uow.SaveChangesAsync(cancellationToken);
        return ToDto(photo);
    }

    public async Task UpdatePhotoByIdAsync(int id, UpdatePhotoRequest request, CancellationToken cancellationToken)
    {
        var existing = await _photoRepository.GetPhotoByIdAsync(id, cancellationToken)
                      ?? throw new KeyNotFoundException("Photo not found");

        existing.Update(request.Title, request.Url, request.TakenAt, request.Tags);
        await _uow.SaveChangesAsync(cancellationToken);
    }

    public async Task DeletePhotoByIdAsync(int id, CancellationToken cancellationToken)
    {
        var photo = await _photoRepository.GetPhotoByIdAsync(id, cancellationToken)
                      ?? throw new KeyNotFoundException("Photo not found");

        await _photoRepository.DeletePhotoByIdAsync(photo, cancellationToken);
        await _uow.SaveChangesAsync(cancellationToken);
    }

    static PhotoDto ToDto(Photo p)
    {
        return new(p.Id, p.Title, p.Url, p.TakenAt, p.Tags);
    }
}
