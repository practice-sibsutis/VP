﻿namespace DapperExample.Models.Chinook;

public class Track
{
    public int? TrackId { get; set; }
    public string? Name { get; set; }
    //public int? AlbumId { get; set; }
    public int? MediaTypeId { get; set; }
    public int? GenreId { get; set; }
    public string? Composer { get; set; }
    public int? Milliseconds { get; set; }
    public int? Bytes { get; set; }
    public decimal? UnitPrice { get; set; }

    public Album? Album { get; set;}
    public ICollection<Playlist>? Playlists { get; set; }
}
