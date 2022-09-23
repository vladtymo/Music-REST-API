using AutoMapper;
using Core.Entities;
using System.Net;
using Core.DTOs;
using Core.Helpers;
using Core.Interfaces;
using Core.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.StaticFiles;
using System.Net.Mime;

namespace Core.Services
{
    // Services should have exception handlers
    public class TrackService : ITrackService
    {
        const string imageFolderName = "images";
        private readonly IRepository<Track> trackRepo;
        //private readonly MusicCollectionDb context;

        private readonly IMapper mapper;

        public TrackService(IRepository<Track> trackRepo, IMapper mapper)
        {
            this.trackRepo = trackRepo;
            this.mapper = mapper;
        }

        public async void Create(TrackDTO track)
        {
            var imagePath = await SaveImageAsync(track.Image);

            Track trackEntity = mapper.Map<Track>(track);
            trackEntity.ImagePath = imagePath;

            trackRepo.Insert(trackEntity);
            trackRepo.Save();
        }

        private async Task<string> SaveImageAsync(IFormFile file)
        {
            string fileName = Guid.NewGuid().ToString();
            string fileExtension = Path.GetExtension(file.FileName);
            string fileFullName = fileName + fileExtension;

            string filePath = Path.Combine(imageFolderName, fileFullName);

            using (var fs = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(fs);
            }

            return filePath;
        }

        public DownloadFileDTO GetImage(int trackId)
        {
            if (trackId < 0) throw new HttpException(HttpStatusCode.BadRequest, ErrorMessages.IncorrectId);

            var track = trackRepo.Get(trackId);

            if (track == null) throw new HttpException(HttpStatusCode.NotFound, ErrorMessages.TrackNotFound);

            if (track.ImagePath == null) throw new HttpException(HttpStatusCode.NoContent, "Track has no image file.");

            var fs = new FileStream(track.ImagePath, FileMode.Open);
            var fileName = Path.GetFileName(track.ImagePath);
            new FileExtensionContentTypeProvider().TryGetContentType(fileName, out string contentType);

            return new DownloadFileDTO()
            {
                Stream = fs,
                FileName = Path.GetFileName(track.ImagePath),
                ContentType = contentType
            };
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
