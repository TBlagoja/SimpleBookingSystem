using API.Dtos;
using AutoMapper;
using Core.Entities;
using Microsoft.AspNetCore.Http;
using System.Globalization;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Resource, ResourceToReturnDto>();
            CreateMap<Booking, BookingToAddDto>()
            .ReverseMap();
        }
    }
}
