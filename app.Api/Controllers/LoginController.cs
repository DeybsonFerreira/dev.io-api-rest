using app.Api.Extensions;
using app.Api.Models;
using app.Business.Interfaces;
using app.Business.Models;
using app.Business.Notification;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace api_rest.Controllers
{
    [Authorize]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Route("api/[controller]")]
    public class LoginController : CustomController
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService, IMapper mapper, ILogger<CustomController> logger, INotify notify) : base(logger, notify, mapper)
        {
            _loginService = loginService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _loginService.GetAllAsync();
            return CustomResponse(ResultType.Get, result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            Login modelView = await _loginService.GetAsync(id);

            if (modelView == null)
                return CustomResponse(ResultType.Get, success: false);

            LoginModel loginViewModel = _mapper.Map<LoginModel>(modelView);
            return CustomResponse(ResultType.Get, loginViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Post(LoginModel model)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            await _loginService.AddAsync(_mapper.Map<Login>(model));

            return CustomResponse(ResultType.Post, model.Id);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _loginService.RemoveAsync(id);
                return CustomResponse(ResultType.Delete);
            }
            catch (Exception error)
            {
                return CustomResponse(ResultType.Delete, error, false);
            }
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Put(Guid id, LoginModel model)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            await _loginService.UpdateAsync(id, _mapper.Map<Login>(model));

            return CustomResponse(ResultType.Put);
        }
    }
}
