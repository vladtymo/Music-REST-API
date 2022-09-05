using DataAccess.Models;

namespace WebAPI.Services.Interfaces
{
    public interface ITrackService
    {
        Task<IEnumerable<Track>> GetAllAsync();
        Track Get(int id);
        IEnumerable<Track> Get(float ratingFrom);
        void Create(Track track);
        void Update(Track track);
        void Delete(int id);


    }
}
