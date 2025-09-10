using Microsoft.EntityFrameworkCore;
using PhotoCatalog.Core.Entities;
using PhotoCatalog.Core.Interfaces;

namespace PhotoCatalog.Infrastructure.Data.Repositories;

public class PhotoRepository(AppDbContext db) : IPhotoRepository
{
    public async Task<List<Photo>> GetAllPhotosAsync(CancellationToken cancellationToken)
    {
        return await db.Photos.AsNoTracking().OrderByDescending(x => x.Id).ToListAsync(cancellationToken);
    }

    public async Task<Photo?> GetPhotoByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await db.Photos.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task AddPhotoAsync(Photo photo, CancellationToken cancellationToken)
    {
        await db.Photos.AddAsync(photo, cancellationToken);
    }

    public Task DeletePhotoByIdAsync(Photo photo, CancellationToken cancellationToken)
    {
        db.Photos.Remove(photo);
        return Task.CompletedTask;
    }
}
