﻿namespace OrderService.API.Models
{
    public class CreateUserDto
    {
        //[Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}
