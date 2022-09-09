using AutoMapper;
using DataAccess.Models;
using BLL.DTOs;

namespace BLL.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Track, TrackDTO>().ReverseMap();
        }
    }
}
