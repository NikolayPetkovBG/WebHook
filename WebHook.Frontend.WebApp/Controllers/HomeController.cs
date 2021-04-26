using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebHook.Common.ApiClients;
using WebHook.Frontend.Services;
using WebHook.Frontend.WebApp.Models;
using WebHook.Frontend.WebApp.Extentions;

namespace WebHook.Frontend.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHookService _webHookService;

        public HomeController(ILogger<HomeController> logger, IWebHookService webHookService)
        {
            _logger = logger;
            _webHookService = webHookService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var data = await _webHookService.GetAllWebHooksAsync();

            return View(data.Select(x => x.FromDTO()));
        }

        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateAsync(WebHookViewModel webHookViewModel)
        {
            await _webHookService.AddWebHookAsync(webHookViewModel.ToDTO());

            return RedirectToAction("Index");
        }
        
        [HttpPost]
        public async Task<IActionResult> CallAllAsync()
        {
            await _webHookService.CallAllWebHooksAsync();

            return Ok();
        }


    }
}
