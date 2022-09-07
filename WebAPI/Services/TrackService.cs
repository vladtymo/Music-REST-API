﻿using AutoMapper;
using DataAccess;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;
using WebAPI.DTOs;
using WebAPI.Helpers;
using WebAPI.Services.Interfaces;

namespace WebAPI.Services
{
    // Services should have exception handlers
    public class TrackService : ITrackService
    {
        private readonly MusicCollectionDb context;
        private readonly IMapper mapper;

        public TrackService(MusicCollectionDb context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void Create(TrackDTO track)
        {
            context.Tracks.Add(mapper.Map<Track>(track));
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            if (id < 0) throw new HttpException(HttpStatusCode.BadGateway, "Id must be greater than zero.");

            var track = context.Tracks.Find(id);

            if (track == null) throw new HttpException(HttpStatusCode.NotFound, "Track is not found.");

            context.Tracks.Remove(track);
            context.SaveChanges();
        }

        public TrackDTO Get(int id)
        {
            if (id < 0) return null;

            var track = context.Tracks.Find(id);

            if (track == null) return null;

            return mapper.Map<TrackDTO>(track);
        }

        public IEnumerable<TrackDTO> Get(float ratingFrom)
        {
            var tracks = context.Tracks.Where(t => t.Rating >= ratingFrom).ToList();
            return mapper.Map<IEnumerable<TrackDTO>>(tracks);
        }

        public async Task<IEnumerable<TrackDTO>> GetAllAsync()
        {
            var tracks = await context.Tracks.ToListAsync();

            return mapper.Map<IEnumerable<TrackDTO>>(tracks);
            //return tracks.Select(t => new TrackDTO()
            //{
            //    Id = t.Id,
            //    Name = t.Name,
            //    Rating = t.Rating,
            //    Duration = t.Duration
            //});
        }

        public void Update(TrackDTO track)
        {
            context.Tracks.Update(mapper.Map<Track>(track));
            context.SaveChanges();
        }
    }
}
