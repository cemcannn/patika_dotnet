using AutoMapper;
using System.Net;
using WebApi.AuthorOperations.CreateAuthor;
using WebApi.AuthorOperations.GetAuthorDetail;
using WebApi.AuthorOperations.GetAuthors;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.GetBookDetail;
using WebApi.BookOperations.GetBooks;
using WebApi.Controllers;
using WebApi.Entities;
using WebApi.GenreOperations.GetGenreDetail;
using WebApi.GenreOperations.GetGenres;
using static WebApi.BookOperations.CreateBook.CreateBookCommand;
using static WebApi.BookOperations.GetBookDetail.GetBookDetailQuery;

namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            //CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
            //CreateMap<Book, BookViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString())); //Genre ye bir konfigurasyon ayarla, Şu şekilde maple; GenreId'yi GenreEnum'dan cast ederek string e çevir.
            CreateMap<Genre, GenresViewModel>();
            CreateMap<Genre, GenreDetailViewModel>();
            CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<Book, BookViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<Author, AuthorViewDetailModel>();
            CreateMap<Author, AuthorViewModel>();
            CreateMap<CreateAuthorModel, Author>();
            CreateMap<CreateUserModel, User>();
        }
    }
}
