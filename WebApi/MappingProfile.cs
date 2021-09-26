using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.BookOperation.GetBookDetail;
using WebApi.Common;
using static WebApi.BookOperation.CreateBook.CreateBookCommand;
using static WebApi.BookOperation.GetBooks.GetBooksQuery;

namespace WebApi
{
    public class MappingProfile:Profile
    {

        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BooDetailViewModel>().ForMember(dest=>dest.Genre,opt=>opt.MapFrom(src=>((GemreEnum)src.GenerateId).ToString()));


            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GemreEnum)src.GenerateId).ToString()));
        }



    }
}
