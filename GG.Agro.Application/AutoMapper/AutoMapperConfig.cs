using AutoMapper;
using GG.Agro.Application.Commands.Contract;
using GG.Agro.Domain.Entities;

namespace GG.Agro.Application.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<CreateContractCommand, Contract>();
            CreateMap<UpdateContractCommand, Contract>();
        }
    }
}
