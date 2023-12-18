﻿using Microsoft.AspNetCore.Mvc;
using UDFirstTask.Models;

namespace UDFirstTask.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILogger<ErrorController> _logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            _logger = logger;
        }

        [Route("/Error/{statusCode}")]
        public IActionResult ErrorHandler(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    _logger.LogWarning($"404 Not Found Error Occurred.");
                    return View("~/Views/Shared/_PageNotFound.cshtml"); 
                default:
                 
                    _logger.LogError($"Error with status code: {statusCode}");
                    return View("~/Views/Shared/_Error.cshtml");
            }
        }
    }


}