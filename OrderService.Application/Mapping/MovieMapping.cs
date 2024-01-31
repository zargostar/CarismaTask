using AutoMapper;
using OrderService.Application.Features.Movies.Comands;
using OrderService.Application.Features.Movies.Dtos;
using OrderService.Application.Features.Theaters.Dtos;
using OrderServise.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Mapping
{
    public class MovieMapping:Profile
    {
        public MovieMapping()
        {
            CreateMap<Movie,MovieDto>().ForMember(des=>des.Genres,src=>src.MapFrom(src=>src.GenreMovie.Select(p=>new Genre() { Id=p.GenreId,Name=p.Genre.Name}))).
                ForMember(des=>des.Theaters,res=>res.MapFrom(res=>res.MovieTheater.Select(p=>new TheaterDto() { Name=p.Theater.Name} )));

            CreateMap<CreateMovieCommand, Movie>().ForMember(des => des.Image, src => src.Ignore())
                  .ForMember(des => des.GenreMovie, src => src.MapFrom(x => x.GenresIds.Select(x => new GenreMovie() { GenreId = x }).ToList()))
                  .ForMember(des => des.MovieTheater, src => src.MapFrom(x => x.TheaterIds.Select(x => new MovieTheater() { TheaterId = x }).ToList()))
                  .ForMember(des => des.ActorMovies, src => src.MapFrom(x => x.Actors.Select(x => new ActorMovie() { Role = x.Role, ActorId = x.Id }).ToList()));    
        }
        //  enums
        // CreateMap<NewOrder, NewOrderDto>().ForMember(x => x.OrderDSescription, src => src.MapFrom(x => ((OrderState) x.OrderState).AsString(EnumFormat.Description)));

        // in dton directly map
        //=>  // public string OrderStatename =>OrderState.GetDisplayName();
        // public string Orderdescription => ((OrderState)OrderState).AsString(EnumFormat.Description);
    }
}
