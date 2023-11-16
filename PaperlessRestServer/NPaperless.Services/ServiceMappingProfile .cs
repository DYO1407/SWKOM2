using AutoMapper;
using NPaperless.Services.DTOs;
using BusinessLogic.Entities;


namespace NPaperless.Services.MappingProfile
{
    public class ServiceMappingProfile : Profile
    {

        public ServiceMappingProfile()
        {
            CreateMap<DTOs.Correspondent, BusinessLogic.Entities.Correspondent>().ReverseMap();
            CreateMap<DTOs.Document, BusinessLogic.Entities.Document>().ReverseMap();
            CreateMap<DTOs.DocumentType, BusinessLogic.Entities.DocumentType>().ReverseMap();
            CreateMap<Tag, DocumentTag>().ReverseMap();
            CreateMap<UserInfo, User>().ReverseMap();


        }



    }
}