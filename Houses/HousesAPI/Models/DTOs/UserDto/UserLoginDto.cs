﻿using System.ComponentModel.DataAnnotations;

namespace HousesAPI.Models.DTOs.UserDto
{
    public class UserLoginDto
    {
        [Required(ErrorMessage = "Field required: UserName")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Field required: Password")]      
        public string Password { get; set; }


    }
}
