using OrderService.Application.Contracts;
using OrderServise.Domain.Entities;
using OrderServise.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderServise.Infrastructure.Repositories
{
    public class GenreRepository : BaseRepositoryAsync<Genre>, IGenreRepository
    {
        public GenreRepository(DataBaseContext dbContext) : base(dbContext)
        {
        }
    }
}
