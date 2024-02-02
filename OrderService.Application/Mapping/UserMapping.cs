using AutoMapper;
using OrderService.API.Models;
using OrderServise.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Mapping
{
    public class UserMapping:Profile
    {
        public UserMapping() {
            CreateMap<CreateUserDto, AppUser>();
        }
    }
}
