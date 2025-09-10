namespace PhotoCatalog.Core.Contracts;

public record CreatePhotoRequest(
    string Title,
    string Url,
    DateTime? TakenAt,
    string? Tags
);
