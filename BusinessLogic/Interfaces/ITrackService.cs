using Core.Entities;
using Core.DTOs;

namespace Core.Interfaces
{
    public interface ITrackService
    {
        Task<IEnumerable<TrackDTO>> GetAllAsync();
        TrackDTO Get(int id);
        IEnumerable<TrackDTO> Get(float ratingFrom);
        void Create(TrackDTO track);
        void Update(TrackDTO track);
        void Delete(int id);


    }
}
