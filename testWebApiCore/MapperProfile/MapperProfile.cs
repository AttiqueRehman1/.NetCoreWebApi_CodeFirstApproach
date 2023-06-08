using AutoMapper;
using System.Net;
using testWebApiCore.DTO_Models;
using testWebApiCore.Models;

namespace testWebApiCore.MapperProfile
{
    public class MapperProfile : Profile
    {

        public MapperProfile()
        {
            CreateMap<Book, BookDTO>();
            CreateMap<BookDTO, Book>();
            CreateMap<Author, AuthorDTO>().ReverseMap();
            CreateMap<Author, AuhhorInfo_BookInfo>();
            

        }
    }
}
