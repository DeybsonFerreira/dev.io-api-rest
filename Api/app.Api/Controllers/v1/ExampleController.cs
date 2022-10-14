using app.Api.Extensions;
using app.Business.Interfaces.Repositories;
using app.Business.Interfaces.Testes;
using app.Business.Notification;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace app.Api.Controllers.v2
{
    [ApiVersion("1.0", Deprecated = false)]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class ExampleController : CustomController
    {
        public Func<string, IServiceByKey> ServiceAcessor { get; }

        public ExampleController(
            ILogger<ServiceLocatorController> logger,
            INotify notify,
            IMapper mapper,
            Func<string, IServiceByKey> serviceAcessor) : base(logger, notify, mapper)
        {
            ServiceAcessor = serviceAcessor;
        }

        /// <summary>
        /// Resolver dependências de (múltipla classes) interface por uma chave
        /// </summary>
        [Tags("ServiceProvider")]
        [HttpGet("GetInstanceByKey")]
        public IActionResult GetInstanceByKey()
        {
            string serviceA = ServiceAcessor("A").GetServiceName();
            string serviceB = ServiceAcessor("B").GetServiceName();

            object services = new { A = serviceA, B = serviceB };

            return Ok(services);
        }

        /// <summary>
        /// Resolver injeção de dependência por propriedade
        /// </summary>
        /// <returns></returns>
        [Tags("ServiceProvider")]
        [HttpGet("PropertInjection")]
        public async Task<IActionResult> PropertInjection([FromServices] INaturalPersonRepository exampleInstance)
        {
            return Ok(await exampleInstance.GetAllAsync());
        }

    }

}