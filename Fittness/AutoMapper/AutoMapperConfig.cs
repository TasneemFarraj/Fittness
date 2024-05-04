using AutoMapper;
using Fittness.Data.Models;
using Fittness.Dtos.CredDtos;

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
          
        });
        return MapConfig.CreateMapper();
    }
}

