using AutoMapper;
using LibraryApi.Dtos.AuthorDtos;
using LibraryApi.Dtos.BookDtos;
using LibraryApi.Dtos.BorrowerDtos;
using LibraryApi.Dtos.LoanDtos;
using LibraryApi.Models;

namespace LibraryApi.Helper;

public class LibraryProfile : Profile
{
    public LibraryProfile()
    {
        CreateMap<Author, GetAuthorResponse>();

        CreateMap<Book, GetBookResponse>()
            .ForMember(destination => destination.AuthorName,
                options => options.MapFrom(source => source.Author.Name));

        CreateMap<Borrower, GetBorrowerResponse>();

        CreateMap<Loan, GetLoanResponse>()
            .ForMember(destination => destination.BookTitle,
                options => options.MapFrom(source => source.Book.Title))
            .ForMember(destination => destination.BorrowerName,
                options => options.MapFrom(source => source.Borrower.Name));
    }
}
