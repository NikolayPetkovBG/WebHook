using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHook.Backend.Services;

namespace WebHook.Backend.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WebHookApiController : ControllerBase
    {
        private readonly IWebHookService _webHookService;

        public WebHookApiController(IWebHookService webHookService)
        {
            _webHookService = webHookService;
        }

        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _webHookService.GetAllAsync();

            return new JsonResult(result);
        }

        [HttpGet]
        [Route("Get/{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _webHookService.GetAsync(id);

            if (result != null)
            {
                return new JsonResult(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("Call/{id}")]
        public async Task<IActionResult> CallAsync(int id)
        {
            await _webHookService.CallAsync(id);

            return Ok();
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> PostAsync(Common.Models.WebHook webHook)
        {
            var result = await _webHookService.AddAsync(webHook);

            return new JsonResult(result);
        }
    }
}
