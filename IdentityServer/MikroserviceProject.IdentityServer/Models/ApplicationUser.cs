﻿using Microsoft.AspNetCore.Identity;

namespace MikroserviceProject.IdentityServer.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string UserImage { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

    }
}
