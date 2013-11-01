using System.Data.Entity;

namespace ElectricImpHackathon.Models
{
    public class MusicContext : DbContext
    {
        public DbSet<SongTrack> SongTracks { get; set; }
        public DbSet<SongSet> SongSets { get; set; }
    }
}