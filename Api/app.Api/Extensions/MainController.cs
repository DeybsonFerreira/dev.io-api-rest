using app.Business.Notification;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace app.Api.Extensions
{
    [ApiController]
    public abstract class CustomController : ControllerBase
    {
        public readonly IMapper _mapper;
        public readonly INotify _notify;
        public readonly ILogger<CustomController> _logger;

        public CustomController(ILogger<CustomController> logger, INotify notify, IMapper mapper)
        {
            _logger = logger;
            _notify = notify;
            _mapper = mapper;
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid)
            {
                var erros = modelState.Values.SelectMany(e => e.Errors);
                return BadRequest(new { sucess = false, erros });
            }
            throw new NotImplementedException();
        }

        protected IActionResult CustomResponse(ResultType type, object result = null, bool success = true)
        {
            if (_notify.HasNotification())
                return CustomBadReqeust();

            if (success)
            {
                if (type == ResultType.Put)
                    return NoContent();

                if (type == ResultType.Post)
                    return Ok(result);

                if (type == ResultType.Post)
                    return RedirectToAction($"Get", new { id = result });

                if (type == ResultType.Delete)
                    return NoContent();

                return Ok(new { success = true, data = result });
            }
            else
            {
                if (type == ResultType.Get)
                    return NotFound();

                if (type == ResultType.Post)
                    return BadRequest();

                if (type == ResultType.Delete)
                    return BadRequest();

                return CustomBadReqeust();
            }
        }

        private IActionResult CustomBadReqeust()
        {
            IEnumerable<string> errorMessages = GetErros();
            _logger.LogError($"Erros : {errorMessages}");
            return BadRequest(new { sucess = false, erros = errorMessages });
        }

        protected IEnumerable<string> GetErros()
        {
            return _notify.Get().Select(n => n.Message);
        }
    }

    public enum ResultType
    {
        Get,
        Post,
        Put,
        Delete
    }
}