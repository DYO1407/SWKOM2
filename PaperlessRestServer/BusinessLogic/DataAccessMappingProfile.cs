
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
            CreateMap<DataAccess.Entities.Document, Entities.Document>().ReverseMap();
            CreateMap<DataAccess.Entities.DocumentType, Entities.DocumentType>().ReverseMap();
            CreateMap<DataAccess.Entities.DocumentTag, Entities.DocumentTag>().ReverseMap();
            CreateMap<DataAccess.Entities.User, Entities.User>().ReverseMap();

        }
    }

}
