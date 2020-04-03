using AutoMapper;
using TesteNavita.Domain;
using TesteNavita.Domain.Identity;
using TesteNavita.WebApi.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProAgil.WebApi.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Patrimonio, PatrimonioDto>().ReverseMap();
            CreateMap<Marca, MarcaDto>().ReverseMap();                
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserLoginDto>().ReverseMap();
        }
    }
}
