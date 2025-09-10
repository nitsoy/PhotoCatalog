namespace PhotoCatalog.Core.Contracts;

public record UpdatePhotoRequest(
    string Title,
    string Url,
    DateTime? TakenAt,
    string? Tags
);
