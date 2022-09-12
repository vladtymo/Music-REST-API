using AutoMapper;
using Core.Entities;
using System.Net;
using Core.DTOs;
using Core.Helpers;
using Core.Interfaces;
using Core.Resources;

namespace Core.Services
{
    // Services should have exception handlers
    public class TrackService : ITrackService
    {
        private readonly IRepository<Track> trackRepo;
        //private readonly MusicCollectionDb context;

        private readonly IMapper mapper;

        public TrackService(IRepository<Track> trackRepo, IMapper mapper)
        {
            this.trackRepo = trackRepo;
            this.mapper = mapper;
        }

        public void Create(TrackDTO track)
        {
            trackRepo.Insert(mapper.Map<Track>(track));
            trackRepo.Save();
        }

        public void Delete(int id)
        {
            if (id < 0) throw new HttpException(HttpStatusCode.BadRequest, ErrorMessages.IncorrectId);

            var track = trackRepo.Get(id);

            if (track == null) throw new HttpException(HttpStatusCode.NotFound, ErrorMessages.TrackNotFound);

            trackRepo.Delete(track);
            trackRepo.Save();
        }

        public TrackDTO Get(int id)
        {
            if (id < 0) throw new HttpException(HttpStatusCode.BadRequest, ErrorMessages.IncorrectId);

            var track = trackRepo.Get(id);

            if (track == null) throw new HttpException(HttpStatusCode.NotFound, ErrorMessages.TrackNotFound);

            return mapper.Map<TrackDTO>(track);
        }

        public IEnumerable<TrackDTO> Get(float ratingFrom)
        {
            var tracks = trackRepo.Get(t => t.Rating >= ratingFrom).ToList();
            return mapper.Map<IEnumerable<TrackDTO>>(tracks);
        }

        public async Task<IEnumerable<TrackDTO>> GetAllAsync()
        {
            // TODO: ToListAsync()
            var tracks = await Task.Run(() => trackRepo.Get().ToList());

            return mapper.Map<IEnumerable<TrackDTO>>(tracks);
        }

        public void Update(TrackDTO track)
        {
            trackRepo.Update(mapper.Map<Track>(track));
            trackRepo.Save();
        }
    }
}
