using app.Api.Extensions;
using app.Business.Interfaces.Services;
using app.Business.Models.Input;
using app.Business.Models.Output;
using app.Business.Notification;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.Api.Controllers.v2
{
    //[Authorize]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class NaturalPersonController : CustomController
    {
        private readonly INaturalPersonService _naturalPersonService;

        public NaturalPersonController(
            ILogger<NaturalPersonController> logger,
            INaturalPersonService naturalPersonService,
            INotify notify,
            IMapper mapper) : base(logger, notify, mapper)
        {
            _naturalPersonService = naturalPersonService;
        }

        //[ClaimsAuthorize(ConstClaim.NaturalPerson, ConstClaim.ReadAll)]
        [HttpGet]
        public IActionResult Get()
        {
            var result = _naturalPersonService.GetAll();
            return CustomResponse(ResultType.Get, result);
        }

        [HttpGet("Filter")]
        public IActionResult Filter(
            [FromQuery] Guid? naturalPersonId = null,
            [FromQuery] string documentNumber = null)
        {
            IEnumerable<NaturalPersonOutput> userModel = _naturalPersonService.Filter(
                                                         naturalPersonId: naturalPersonId,
                                                         documentNumber: documentNumber);

            if (userModel == null || !userModel.Any())
                return CustomResponse(ResultType.Get, success: false);
            return CustomResponse(ResultType.Get, userModel);
        }

        [HttpGet("{id:guid}")]
        public IActionResult Get([FromRoute] Guid id)
        {
            IEnumerable<NaturalPersonOutput> userModel = _naturalPersonService.Filter(naturalPersonId: id);

            if (userModel == null || !userModel.Any())
                return CustomResponse(ResultType.Get, success: false);
            return CustomResponse(ResultType.Get, userModel);
        }

        [HttpPost]
        //[ClaimsAuthorize(ConstClaim.NaturalPerson, ConstClaim.Create)]
        public async Task<IActionResult> Post(NaturalPersonInput naturalPersonInput)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            NaturalPersonOutput created = await _naturalPersonService.CreateAsync(naturalPersonInput);

            return CustomResponse(ResultType.Post, created.Id);
        }

        [HttpDelete("{id:guid}")]
        //[ClaimsAuthorize(ConstClaim.User, ConstClaim.Delete)]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _naturalPersonService.DeleteAsync(id);
            return CustomResponse(ResultType.Delete);
        }

        //[HttpPut("{id:guid}")]
        //[ClaimsAuthorize(ConstClaim.User, ConstClaim.Update)]
        //public async Task<IActionResult> Put(Guid id, UserModel model)
        //{
        //    if (!ModelState.IsValid)
        //        return CustomResponse(ModelState);

        //    await _naturalPersonService.UpdateAsync(id, _mapper.Map<User>(model));

        //    return CustomResponse(ResultType.Put);
        //}
    }

}