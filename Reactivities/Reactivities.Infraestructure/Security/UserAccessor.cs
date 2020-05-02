using Microsoft.AspNetCore.Http;
using Reactivities.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Reactivities.Infraestructure.Security
{
    public class UserAccessor : IUserAccesssor
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserAccessor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetCurrentUserName()
        {
            var username = _httpContextAccessor.HttpContext.User?.Claims?.FirstOrDefault( x => 
                x.Type == ClaimTypes.NameIdentifier)?.Value;
            return username;
        }
    }
}
