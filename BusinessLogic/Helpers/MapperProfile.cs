using AutoMapper;
using Core.Entities;
using Core.DTOs;

namespace Core.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Track, TrackDTO>().ReverseMap();
        }
    }
}
