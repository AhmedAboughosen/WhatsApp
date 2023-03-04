using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using Core.Domain.Entities;
using Core.Domain.Exceptions;
using Core.Domain.Model.DTO.RequestDTO;
using Core.Domain.Model.DTO.ResponseDto;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Services.Handler
{
    public class VerifyCodeHandler : IRequestHandler<VerifyCodeRequestDto, AuthUserInfoResponseDto>
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfigurationSection _jwtSettings;

        public VerifyCodeHandler(UserManager<User> userManager, IConfiguration configuration,
            SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtSettings = configuration.GetSection("JwtSettings");
        }


        public async Task<AuthUserInfoResponseDto> Handle(VerifyCodeRequestDto dto,
            CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(dto.PhoneNumber);


            var result = await _signInManager.TwoFactorSignInAsync("Phone", dto.Code, false, false);

            if (result.Succeeded)
            {
                var signingCredentials = GetSigningCredentials();
                var claims = await GetClaims(user);
                var tokenOptions = GenerateTokenOptions(signingCredentials, claims);

                var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

                return new AuthUserInfoResponseDto
                {
                    PhoneNumber = user.PhoneNumber,
                    Id = user.Id,
                    Dob = user.Dob,
                    Token = token
                };
            }

            throw new APIException(
                "Invalid Operation", HttpStatusCode.Forbidden);
        }


        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(_jwtSettings.GetSection("securityKey").Value);
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var tokenOptions = new JwtSecurityToken(
                _jwtSettings.GetSection("Issuer").Value,
                _jwtSettings.GetSection("Audience").Value,
                claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_jwtSettings.GetSection("TokenTimeout").Value)),
                signingCredentials: signingCredentials);
            return tokenOptions;
        }


        private async Task<List<Claim>> GetClaims(User user)
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.MobilePhone, user.PhoneNumber),
                new(ClaimTypes.NameIdentifier, user.Id),
            };

            var roles = await _userManager.GetRolesAsync(user);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }
    }
}