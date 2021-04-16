using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhotoGallery.BLL.Filters
{
    public class SetNumbersPhotoFilterAttribute : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            {
                if (context.ModelState.IsValid == true)
                    context.ActionArguments["numbersOfPhoto"] = 5;
                await next();
            }
        }
    }
}
