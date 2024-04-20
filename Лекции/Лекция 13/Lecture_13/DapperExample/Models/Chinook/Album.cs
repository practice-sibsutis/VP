namespace DapperExample.Models.Chinook;

public class Album
{
    public int? AlbumId { get; set; }
    public string? Title { get; set; }
    public int? ArtistId { get; set; }
    public ICollection<Track>? Tracks { get; set; }
}