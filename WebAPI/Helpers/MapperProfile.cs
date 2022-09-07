using AutoMapper;
using DataAccess.Models;
using WebAPI.DTOs;

namespace WebAPI.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Track, TrackDTO>().ReverseMap();
        }
    }
}
