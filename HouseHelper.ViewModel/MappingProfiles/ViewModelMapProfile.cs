using AutoMapper;
using HouseHelper.Models;
using HouseHelper.ViewModel.Models;

namespace HouseHelper.ViewModel.MappingProfiles
{
    public class ViewModelMapProfile : Profile
    {
        public ViewModelMapProfile()
        {
            CreateMap<MoneyOperation, MoneyOperationDto>()
                .ForMember(dest => dest.TimeStringView,
                    opt =>
                        opt.MapFrom(x => x.Date.ToString("t")))
                .ForMember(dest => dest.ValueView,
                    opt =>
                        opt.MapFrom(x => $"{(x.Type == MoneyOperationType.Income ? "+" : "-")}{x.Value}"));
        }
    }
}