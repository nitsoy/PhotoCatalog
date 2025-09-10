namespace PhotoCatalog.Core.Entities;

public class Photo
{
    public int Id { get; private set; }
    public string Title { get; private set; }
    public string Url { get; private set; }
    public DateTime? TakenAt { get; private set; }
    public string? Tags { get; private set; }

    private Photo() { }

    public Photo(string title, string url, DateTime? takenAt = null, string? tags = null)
    {
        SetTitle(title);
        SetUrl(url);
        TakenAt = takenAt;
        Tags = tags;
    }

    public void Update(string title, string url, DateTime? takenAt, string? tags)
    {
        SetTitle(title);
        SetUrl(url);
        TakenAt = takenAt;
        Tags = tags;
    }

    private void SetTitle(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("Title is required.");
        }
        if (title.Length > 120)
        {
            throw new ArgumentException("Title max length is 120.");
        }

        Title = title.Trim();
    }

    private void SetUrl(string url)
    {
        if (!Uri.IsWellFormedUriString(url, UriKind.Absolute))
        {
            throw new ArgumentException("Url is invalid.");
        }
        Url = url;
    }
}
