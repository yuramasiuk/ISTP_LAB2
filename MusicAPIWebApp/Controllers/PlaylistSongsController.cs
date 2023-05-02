using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicAPIWebApp.Models;

namespace MusicAPIWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistSongsController : ControllerBase
    {
        private readonly MusicAPIContext _context;

        public PlaylistSongsController(MusicAPIContext context)
        {
            _context = context;
        }

        // GET: api/PlaylistSongs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlaylistSong>>> GetPlaylistsSong()
        {
          if (_context.PlaylistsSong == null)
          {
              return NotFound();
          }
            return await _context.PlaylistsSong.ToListAsync();
        }

        // GET: api/PlaylistSongs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlaylistSong>> GetPlaylistSong(int id)
        {
          if (_context.PlaylistsSong == null)
          {
              return NotFound();
          }
            var playlistSong = await _context.PlaylistsSong.FindAsync(id);

            if (playlistSong == null)
            {
                return NotFound();
            }

            return playlistSong;
        }

        // PUT: api/PlaylistSongs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlaylistSong(int id, PlaylistSong playlistSong)
        {
            if (id != playlistSong.PlaylistId)
            {
                return BadRequest();
            }

            _context.Entry(playlistSong).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlaylistSongExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PlaylistSongs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PlaylistSong>> PostPlaylistSong(PlaylistSong playlistSong)
        {
          if (_context.PlaylistsSong == null)
          {
              return Problem("Entity set 'MusicAPIContext.PlaylistsSong'  is null.");
          }
            _context.PlaylistsSong.Add(playlistSong);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PlaylistSongExists(playlistSong.PlaylistId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPlaylistSong", new { id = playlistSong.PlaylistId }, playlistSong);
        }

        // DELETE: api/PlaylistSongs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlaylistSong(int id)
        {
            if (_context.PlaylistsSong == null)
            {
                return NotFound();
            }
            var playlistSong = await _context.PlaylistsSong.FindAsync(id);
            if (playlistSong == null)
            {
                return NotFound();
            }

            _context.PlaylistsSong.Remove(playlistSong);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlaylistSongExists(int id)
        {
            return (_context.PlaylistsSong?.Any(e => e.PlaylistId == id)).GetValueOrDefault();
        }
    }
}
