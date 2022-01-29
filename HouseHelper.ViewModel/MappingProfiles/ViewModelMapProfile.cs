using AutoMapper;
using HouseHelper.Models;
using HouseHelper.ViewModel.Models;

namespace HouseHelper.ViewModel.MappingProfiles
{
    public class ViewModelMapProfile : Profile
    {
        public ViewModelMapProfile()
        {
            CreateMap<MoneyOperation, MoneyOperationDto>();
        }
    }
}