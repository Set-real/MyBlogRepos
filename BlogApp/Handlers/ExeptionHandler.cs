using BlogApp.Exeptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BlogApp.Handlers
{
    public class ExeptionHandler : ActionFilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            string massage = "Произошла непредвиденная ошибка!";

            if (context.Exception is CustomExeption)
            {
                massage = context.Exception.Message;
            }

            context.Result = new BadRequestObjectResult(massage);
        }
    }
}
