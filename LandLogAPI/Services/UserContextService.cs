﻿using System.Security.Claims;

namespace LandLogAPI.Services
{
    public interface IUserContextService
    {
        ClaimsPrincipal? User { get; }
        Guid? GetUserId { get; }
    }

    public class UserContextService : IUserContextService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserContextService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public ClaimsPrincipal? User => _httpContextAccessor.HttpContext?.User;

        public Guid? GetUserId => User != null? Guid.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value) : null;
    }
}
