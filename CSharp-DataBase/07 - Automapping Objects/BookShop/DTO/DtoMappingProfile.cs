using AutoMapper;
using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookShop.DTO
{
    public class DtoMappingProfile : Profile
    {
        public DtoMappingProfile()
        {
            CreateMap<Book, BookDTO>();

            //DTO propertyName != Initial Class properyName , so we need to configure what to map
            CreateMap<Author, AuthorDTO>()
                            .ForMember(dto => dto.FullName, opt => opt
                            .MapFrom(src => $"{src.FirstName} {src.LastName}"));

            CreateMap<Author, AuthorAndBookDTO>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(src => src.AuthorId))
                .ForMember(dto => dto.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(dto => dto.Title, opt => opt.MapFrom(src => src.Books.First().Title))
                .ForMember(dto => dto.Price, opt => opt.MapFrom(src => src.Books.First().Price))
                .ForMember(dto => dto.CategoryName, opt => opt.MapFrom(src => src.Books.First().BookCategories.First().Category.Name));        
                       
                       
        }

    }
}
