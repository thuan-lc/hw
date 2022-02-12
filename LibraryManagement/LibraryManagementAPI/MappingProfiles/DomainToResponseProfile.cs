using AutoMapper;
using LibraryManagementAPI.Contracts.V1.Requests;
using LibraryManagementAPI.Contracts.V1.Responses;
using LibraryManagementAPI.Domains;

namespace LibraryManagementAPI.MappingProfiles
{
    public class DomainToResponseProfile : Profile
    {
        public DomainToResponseProfile()
        {
            CreateMap<Book, BookResponse>()
                .ForMember(dest => dest.CreatedBy, opt =>
                  opt.MapFrom(src => src.CreatedBy.UserName));
            CreateMap<CreateBookRequest, Book>();
        }
    }
}
