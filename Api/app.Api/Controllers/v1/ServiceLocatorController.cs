using app.Api.Extensions;
using app.Api.Models;
using app.Business.Interfaces.Services;
using app.Business.Models;
using app.Business.Notification;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace app.Api.Controllers.v2
{
    [ApiVersion("1.0", Deprecated = false)]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class ServiceLocatorController : CustomController
    {
        /// <summary>
        /// Resolver dependências de interface pelo Provider
        /// </summary>
        public IServiceProvider ServiceProvider { get; }
        public ServiceLocatorController(
            ILogger<ServiceLocatorController> logger,
            INotify notify,
            IMapper mapper,
            IServiceProvider serviceProvider
            ) : base(logger, notify, mapper)
        {
            this.ServiceProvider = serviceProvider;
        }

        [Tags("ServiceProvider")]
        [HttpGet("GetInstanceNaturalPerson")]
        public IActionResult GetInstanceNaturalPerson()
        {
            INaturalPersonService instance = ServiceProvider.GetService<INaturalPersonService>();
            return Ok(instance);
        }

        [Tags("ServiceProvider")]
        [HttpGet("GetInstanceLegalPerson")]
        public IActionResult GetInstanceLegalPerson()
        {
            ILegalPersonService instance = ServiceProvider.GetService<ILegalPersonService>();
            return Ok(instance);
        }
    }

}