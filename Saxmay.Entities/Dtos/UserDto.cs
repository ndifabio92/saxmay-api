﻿
using Microsoft.AspNetCore.Identity;

namespace Saxmay.Entities.Dtos
{
    public class UserDto
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public IEnumerable<IdentityError> Errors { get; set; }
    }
}
