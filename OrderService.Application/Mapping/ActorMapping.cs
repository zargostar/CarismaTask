using AutoMapper;
using OrderService.Application.Features.Actors.Dto;
using OrderServise.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Mapping
{
    public class ActorMapping:Profile
    {
        public ActorMapping()
        {
            CreateMap<ActorDto,Actor>().ReverseMap();
        }
    }
}
