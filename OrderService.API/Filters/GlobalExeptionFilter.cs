using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OrderService.Application.Exceptions;

namespace OrderService.API.Filters
{
    public class GlobalExeptionFilter:ExceptionFilterAttribute
    {
        private readonly ILogger<GlobalExeptionFilter> _logger;

        public GlobalExeptionFilter(ILogger<GlobalExeptionFilter> logger)
        {
            _logger = logger;
        }

        public override void OnException(ExceptionContext context)
        {
            var errors=new List<string>();
            if (context.Exception is ValidationException exception) { 
              errors= exception?.Errors?.Select(x=>x.ErrorMessage).ToList();
                context.Result = new BadRequestObjectResult(errors);

            }
           else if(context.Exception is ClientErrorMessage clientErrorMessage) {
                errors.Add("یک ایراد داخلی  از سمت کلاینت رخ داده است");
                //errors.Add(clientErrorMessage.Message);
                context.Result = new BadRequestObjectResult(errors);
                
                _logger.LogWarning(context.Exception.Message);
                _logger.LogError("stack trace" + "-" + context.Exception.StackTrace);
            }
            else
            {
                errors.Add("یک ایراد داخلی سرور رخ داده است");
                _logger.LogError(context.Exception.Message);
                _logger.LogError("stack trace" + "-" + context.Exception.StackTrace);

            }
          
           // _logger.LogError(context.Exception.InnerException.Message);
            context.Result = new BadRequestObjectResult(errors);
        }
    }
}
