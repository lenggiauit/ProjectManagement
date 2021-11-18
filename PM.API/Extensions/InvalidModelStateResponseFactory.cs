﻿
using PM.API.Resources;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace PM.API.Extensions
{
    public static class InvalidModelStateResponseFactory
    {
        public static IActionResult ProduceErrorResponse(ActionContext context)
        {
            var errors = context.ModelState.GetErrorMessages();
            var response = new ErrorResource(messages: errors);
            return new BadRequestObjectResult(response);
        }
    }
}
