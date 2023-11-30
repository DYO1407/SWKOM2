
using AutoMapper;
using BusinessLogic.Entities;
using DataAccess.Entities;

namespace BusinessLogic.DataAccessMappingProfile
{
    public class DataAccessMappingProfile : Profile
    {
        public DataAccessMappingProfile()
        {
            CreateMap<DataAccess.Entities.Correspondent, Entities.Correspondent>().ReverseMap();
        }
    }
}
