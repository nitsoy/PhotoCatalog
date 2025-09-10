namespace PhotoCatalog.Core.Contracts;

public class UpdatePhotoRequest(
    string Title,
    string Url,
    DateTime? TakenAt,
    string? Tags
);
