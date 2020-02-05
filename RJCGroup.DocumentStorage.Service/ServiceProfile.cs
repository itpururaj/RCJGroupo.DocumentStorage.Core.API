using AutoMapper;
using RJCGroup.DocumentStorage.Repository.Entities;
using RJCGroup.DocumentStorage.Service.Models;

namespace RJCGroup.DocumentStorage.Service
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            CreateMap<DocumentContentModel, DocumentContent>()
                .ReverseMap();

            CreateMap<Document, DocumentModel>()
                .ForMember(dest => dest.FileSize, o => o.MapFrom(src => src.DocumentContent.Content.Length))
                .ForMember(dest => dest.FileContent, o => o.MapFrom(src => src.DocumentContent))
                .ReverseMap();
        }
    }
}
