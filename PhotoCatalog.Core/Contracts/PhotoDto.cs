namespace PhotoCatalog.Core.Contracts;

public record PhotoDto(
    int Id,
    string Title,
    string Url,
    DateTime? TakenAt,
    string? Tags
);
