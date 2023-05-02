namespace MusicAPIWebApp.Models
{
    public class Playlist
    {
        public Playlist()
        {
            Songs = new List<Song>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Song> Songs { get; set; }
    }
}
