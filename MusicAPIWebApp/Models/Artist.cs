namespace MusicAPIWebApp.Models
{
    public class Artist
    {
        public Artist()
        {
            Songs = new List<Song>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Song> Songs { get; set; }
    }
}
