using app.Api.Extensions;
using app.Business.Interfaces.Services;
using app.Business.Notification;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace app.Api.Controllers.v2
{
    [Authorize]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class LegalPersonController : CustomController
    {
        private readonly ILegalPersonService _legalPersonService;

        public LegalPersonController(ILogger<LegalPersonController> logger, ILegalPersonService legalPersonService, INotify notify, IMapper mapper) : base(logger, notify, mapper)
        {
            _legalPersonService = legalPersonService;
        }

        //[HttpGet]
        //[ClaimsAuthorize(ConstClaim.User, ConstClaim.ReadAll)]
        //public async Task<IActionResult> Get()
        //{
        //    var result = await _legalPersonService.GetAllAsync();
        //    return CustomResponse(ResultType.Get, result);
        //}

        //[HttpGet("{id:guid}")]
        //public async Task<IActionResult> Get(Guid id)
        //{
        //    User userModel = await _legalPersonService.GetAsync(id);

        //    if (userModel == null)
        //        return CustomResponse(ResultType.Get, success: false);

        //    UserModel modelView = _mapper.Map<UserModel>(userModel);
        //    return CustomResponse(ResultType.Get, modelView);
        //}

        //[HttpPost]
        //[ClaimsAuthorize(ConstClaim.User, ConstClaim.Create)]
        //public async Task<IActionResult> Post(UserModel model)
        //{
        //    if (!ModelState.IsValid)
        //        return CustomResponse(ModelState);

        //    await _legalPersonService.AddAsync(_mapper.Map<User>(model));

        //    return CustomResponse(ResultType.Post, model.Id);
        //}

        //[HttpDelete("{id:guid}")]
        //[ClaimsAuthorize(ConstClaim.User, ConstClaim.Delete)]
        //public async Task<IActionResult> Delete(Guid id)
        //{
        //    try
        //    {
        //        await _legalPersonService.RemoveAsync(id);
        //        return CustomResponse(ResultType.Delete);
        //    }
        //    catch (Exception error)
        //    {
        //        return CustomResponse(ResultType.Delete, error, false);
        //    }
        //}

        //[HttpPut("{id:guid}")]
        //[ClaimsAuthorize(ConstClaim.User, ConstClaim.Update)]
        //public async Task<IActionResult> Put(Guid id, UserModel model)
        //{
        //    if (!ModelState.IsValid)
        //        return CustomResponse(ModelState);

        //    await _legalPersonService.UpdateAsync(id, _mapper.Map<User>(model));

        //    return CustomResponse(ResultType.Put);
        //}
    }

}