using ElectronicQueue.EQServer.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json;

namespace ElectronicQueue.EQServer.Controllers
{
    [ApiController]
    [Route("api/ServiceProvider")]
    public class ServiceProviderController : ControllerBase
    {
        private readonly ServiceProviderService _serviceProviderService = new ServiceProviderService();

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var serviceProviders = _serviceProviderService.GetAllWithServices();
                string json = JsonSerializer.Serialize(serviceProviders);
                return base.Ok(serviceProviders);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.StackTrace, title: ex.Message);
            }
        }
    }
}
