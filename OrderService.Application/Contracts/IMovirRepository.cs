using OrderService.Application.Features.Movies.Dtos;
using OrderServise.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Contracts
{
    public interface IMovirRepository:IBaseRepositoryAsync<Movie>
    {
        Task<Movie> GetMovieById(int id);
    }
}
