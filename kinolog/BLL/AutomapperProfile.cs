﻿using AutoMapper;
using BLL.Models;
using DAL.Entities;

namespace BLL
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Movie, MovieNameModel>().ReverseMap();
            CreateMap<Creator, CreatorNameModel>().ReverseMap();
            CreateMap<Genre, GenreNameModel>().ReverseMap();

            CreateMap<Movie, MovieModel>()
                .ForMember(mm => mm.Rating, opts =>
                    opts.MapFrom(m => m.UsersRatings.Sum(r => Convert.ToDouble(r.Mark)) / m.UsersRatings.Count()))
                .ForMember(mm => mm.RatingsIds, opts =>
                    opts.MapFrom(m => m.UsersRatings.Select(r => r.Id)))
                .ReverseMap();

            CreateMap<Rating, RatingModel>()
                .ForMember(rm => rm.Movie, opts =>
                    opts.MapFrom(r => r.Movie.Name))
                .ReverseMap();

            CreateMap<Genre, GenreModel>()
                .ForMember(gm => gm.MoviesIds, opts =>
                    opts.MapFrom(g => g.Movies.Select(m => m.Id)))
                .ReverseMap();

            CreateMap<Creator, CreatorModel>()
                .ForMember(cm => cm.Country, opts =>
                    opts.MapFrom(c => c.Country.Name))
                .ReverseMap();
        }
    }
}
