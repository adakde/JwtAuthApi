using Microsoft.AspNetCore.Mvc;

namespace JwtAuthApi.Models
{
    public class RefreshTokenRequestDto
    {
        public Guid UserId { get; set; }
        public required string RefreshToken { get; set; }
    }
}
