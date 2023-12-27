namespace gma_news_api.Infrastructure.Databases.MoviesReviews.Mapping;

using AutoMapper;
using Application = Application.News.Entities;
using Infrastructure = Models;


internal class NewsMappingProfile : Profile
{
    public NewsMappingProfile()
    {
        _ = this.CreateMap<Infrastructure.News, Application.News>();
    }
}
