using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OrderService.Application.Exceptions;

namespace OrderService.API.Filters
{
    public class GlobalExeptionFilter:ExceptionFilterAttribute
    {
        
        public override void OnException(ExceptionContext context)
        {
            var errors=new List<string>();
            if (context.Exception is ValidationException exception) { 
              errors= exception?.Errors?.Select(x=>x.ErrorMessage).ToList();


            }
            if(context.Exception is ClientErrorMessage clientErrorMessage) {
                errors.Add(clientErrorMessage.Message);
            }
            
            context.Result = new BadRequestObjectResult(errors);
        }
    }
}
