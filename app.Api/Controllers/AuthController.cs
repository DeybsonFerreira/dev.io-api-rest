﻿using app.Api.Extensions;
using app.Api.Models;
using app.Business.Notification;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace api_rest.Controllers
{
    [Authorize]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Route("api/[controller]")]
    public class AuthController : CustomController
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AppSettings _appSettings;

        public AuthController(
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager,
            IOptions<AppSettings> appSettings,
            IMapper mapper,
            ILogger<CustomController> logger,
            INotify notify) : base(logger, notify, mapper)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterUserViewModel registerUser)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            var user = new IdentityUser
            {
                UserName = registerUser.Email,
                Email = registerUser.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, registerUser.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                var token = await GerarJwt(user.Email);

                return CustomResponse(ResultType.Post, token.AccessToken);
            }
            else
            {
                if (result.Errors.Any())
                {
                    var erros = result.Errors.Select(c => c.Description);
                    return CustomResponse(ResultType.Post, result: erros, success: false);
                }
                return CustomResponse(ResultType.Post, success: false);
            }
        }

        [AllowAnonymous]
        [HttpPost("Enter")]
        public async Task<IActionResult> Login(LoginUserViewModel loginUser)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            var result = await _signInManager.PasswordSignInAsync(loginUser.Email, loginUser.Password, false, true);

            if (result.Succeeded)
            {
                _logger.LogInformation("Usuario " + loginUser.Email + " logado com sucesso");

                var token = await GerarJwt(loginUser.Email);
                return CustomResponse(ResultType.Post, token.AccessToken);

            }
            else
            {
                _notify.Handle(new NotificationLite("Usuário ou Senha incorretos"));
            }
            if (result.IsLockedOut)
            {
                string error = "Usuário temporariamente bloqueado por tentativas inválidas";
                _notify.Handle(new NotificationLite(error));
                return CustomResponse(ResultType.Post, success: false);
            }

            return CustomResponse(ResultType.Post);
        }

        private async Task<LoginResponseViewModel> GerarJwt(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var claims = await _userManager.GetClaimsAsync(user);
            var userRoles = await _userManager.GetRolesAsync(user);

            if (!claims.Any())
                JwtTokenExtensions.CreateClaims(user.Id, user.Email, userRoles);

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_appSettings.Secret));

            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _appSettings.Issuer,
                Audience = _appSettings.UrlAudience,
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddHours(_appSettings.HourExpiration),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
            });

            var encodedToken = tokenHandler.WriteToken(token);

            var response = new LoginResponseViewModel
            {
                AccessToken = encodedToken,
                ExpiresIn = TimeSpan.FromHours(_appSettings.HourExpiration).TotalSeconds,
                UserToken = new UserTokenViewModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    Claims = claims.Select(c => new ClaimViewModel { Type = c.Type, Value = c.Value })
                }
            };

            return response;
        }
    }
}
