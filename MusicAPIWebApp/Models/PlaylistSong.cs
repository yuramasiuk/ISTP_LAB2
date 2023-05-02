using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicAPIWebApp.Models
{
    [PrimaryKey(nameof(PlaylistId), nameof(SongId))]
    public class PlaylistSong
    {
        public int PlaylistId { get; set; }
        public int SongId { get; set; }
        public virtual Playlist? Playlist { get; set; } = null!;
        public virtual Song? Song { get; set; } = null!;
    }
}
