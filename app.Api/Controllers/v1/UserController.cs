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

namespace app.Api.Controllers.v1
{
    [Authorize]
    [ApiVersion("1.0", Deprecated = true)]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class UserController : CustomController
    {
        private readonly IUserService _userService;

        public UserController(ILogger<CustomController> logger, IUserService userService, INotify notify, IMapper mapper) : base(logger, notify, mapper)
        {
            _userService = userService;
        }

        [HttpGet]
        [ClaimsAuthorize(ConstClaim.User, ConstClaim.ReadAll)]
        public async Task<IActionResult> Get()
        {
            var result = await _userService.GetAllAsync();
            return CustomResponse(ResultType.Get, result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            User userModel = await _userService.GetAsync(id);

            if (userModel == null)
                return CustomResponse(ResultType.Get, success: false);

            UserModel modelView = _mapper.Map<UserModel>(userModel);
            return CustomResponse(ResultType.Get, modelView);
        }

        [HttpPost]
        [ClaimsAuthorize(ConstClaim.User, ConstClaim.Create)]
        public async Task<IActionResult> Post(UserModel model)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            await _userService.AddAsync(_mapper.Map<User>(model));

            return CustomResponse(ResultType.Post, model.Id);
        }

        [HttpDelete("{id:guid}")]
        [ClaimsAuthorize(ConstClaim.User, ConstClaim.Delete)]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _userService.RemoveAsync(id);
                return CustomResponse(ResultType.Delete);
            }
            catch (Exception error)
            {
                return CustomResponse(ResultType.Delete, error, false);
            }
        }

        [HttpPut("{id:guid}")]
        [ClaimsAuthorize(ConstClaim.User, ConstClaim.Update)]
        public async Task<IActionResult> Put(Guid id, UserModel model)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            await _userService.UpdateAsync(id, _mapper.Map<User>(model));

            return CustomResponse(ResultType.Put);
        }
    }

}