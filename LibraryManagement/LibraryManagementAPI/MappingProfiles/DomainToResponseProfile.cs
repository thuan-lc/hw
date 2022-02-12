using AutoMapper;
using LibraryManagementAPI.Contracts.V1.Requests;
using LibraryManagementAPI.Contracts.V1.Responses;
using LibraryManagementAPI.Domains;

namespace LibraryManagementAPI.MappingProfiles
{
    public class DomainToResponseProfile:Profile
    {
        public DomainToResponseProfile()
        {
            CreateMap<Book, BookResponse>();
            CreateMap<CreateBookRequest, Book>();
        }
    }
}
