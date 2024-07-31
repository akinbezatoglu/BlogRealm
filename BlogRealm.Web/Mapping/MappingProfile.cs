using AutoMapper;
using BlogRealm.Core.Models;
using BlogRealm.Web.DTO;
using System;
using System.Text.RegularExpressions;

namespace BlogRealm.Web.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Author, HomeViewAuthorDTO>()
                .ForMember(dest => dest.Url, opt => opt.MapFrom(src => $"/author/{src.Id}"));

            CreateMap<Blog, HomeViewBlogDTO>()
                .ForMember(dest => dest.Url, opt => opt.MapFrom(src => $"/blog/{src.Id}"))
                .ForMember(dest => dest.ContentPreview, opt => opt.MapFrom(src => GetFirstParagraph(src.Content)));

            CreateMap<Category, HomeViewCategoryDTO>()
                .ForMember(dest => dest.Url, opt => opt.MapFrom(src => $"/category/{src.Id}"));
        }

        public static string GetFirstParagraph(string html)
        {
            // Remove HTML tags
            string cleanText = Regex.Replace(html, "<.*?>", string.Empty);

            // Split text into paragraphs
            string[] paragraphs = cleanText.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            // Return the first non-empty paragraph
            return paragraphs.Length > 0 ? paragraphs[0].Trim() : string.Empty;
        }
    }
}