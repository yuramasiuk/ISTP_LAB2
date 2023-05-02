namespace MusicAPIWebApp.Models
{
    public class Song
    {
        public Song()
        {
            Playlists = new List<Playlist>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int ArtistId { get; set; }
        public int GenreId { get; set; }
        public virtual Artist? Artist { get; set; }
        public virtual Genre? Genre { get; set; }
        public virtual ICollection<Playlist> Playlists { get; set; }
    }
}
