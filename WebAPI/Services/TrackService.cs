using DataAccess;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using WebAPI.Services.Interfaces;

namespace WebAPI.Services
{
    public class TrackService : ITrackService
    {
        private readonly MusicCollectionDb context;

        public TrackService(MusicCollectionDb context)
        {
            this.context = context;
        }

        public void Create(Track track)
        {
            context.Tracks.Add(track);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            if (id < 0) return;

            var track = context.Tracks.Find(id);

            if (track == null) return;

            context.Tracks.Remove(track);
            context.SaveChanges();
        }

        public Track Get(int id)
        {
            if (id < 0) return null;

            var track = context.Tracks.Find(id);

            if (track == null) return null;

            return track;
        }

        public IEnumerable<Track> Get(float ratingFrom)
        {
            var tracks = context.Tracks.Where(t => t.Rating >= ratingFrom).ToList();
            return tracks;
        }

        public async Task<IEnumerable<Track>> GetAllAsync()
        {
            var tracks = await context.Tracks.ToListAsync();
            return tracks;
        }

        public void Update(Track track)
        {
            context.Tracks.Update(track);
            context.SaveChanges();
        }
    }
}
