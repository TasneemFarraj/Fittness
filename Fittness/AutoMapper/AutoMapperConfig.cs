using AutoMapper;
using Fittness.Data.Models;
using Fittness.Dtos.CredDtos;
using Fittness.Dtos.UserDtos;

namespace Fittness.AutoMapper;

public class AutoMapperConfig
{
    public static IMapper CreateMapper()
    {
        var MapConfig = new MapperConfiguration(M =>
        {
            M.CreateMap<Card, ReadCardDto>().ReverseMap();
            M.CreateMap<Card, WriteCardDto>().ReverseMap();
            M.CreateMap<PalateIngredient, ReadPalateIngredientDto>().ReverseMap();
            M.CreateMap<PalateIngredient, WritePalateIngredientDto>().ReverseMap();

            M.CreateMap<User, UserDto>().ReverseMap();
            M.CreateMap<User, LoginDto>().ReverseMap();
            M.CreateMap<User, WriteUserDto>().ReverseMap();

        });
        return MapConfig.CreateMapper();
    }
}

