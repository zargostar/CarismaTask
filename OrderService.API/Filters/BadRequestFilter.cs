using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OrderService.API.Filters
{
    public class BadRequestFilter : IActionFilter
    {
        //private readonly ILogger<> _logger;   
        public void OnActionExecuted(ActionExecutedContext context)
        {
            var result = context.Result as IStatusCodeActionResult;
            if (result == null)
            {
                return;
            }
            var statusCode = result.StatusCode;
            if (statusCode == 400)
            {
                var data = context.Result as BadRequestObjectResult;
                var errors = new List<string>();

                var badRequestObjectResult = context.Result as BadRequestObjectResult;

                if (data.Value is string)
                {
                    errors.Add(data.Value.ToString());
                }
                else if (badRequestObjectResult.Value is IEnumerable<IdentityError> identityErr)
                {
                    foreach (var item in identityErr)
                    {
                        errors.Add(item.Description);
                    }
                }
                else if (badRequestObjectResult.Value is not null)
                {
                    var cc = badRequestObjectResult.Value as IEnumerable<string>;
                   // cc.ToList();
                    foreach (var item in cc.ToList())
                    {
                        errors.Add(item);
                    }
                }
            
                else
                {
                    foreach (var key in context.ModelState.Keys)
                    {
                        foreach (var error in context.ModelState[key].Errors)
                        {
                            errors.Add($"{key} {error.ErrorMessage}");

                        }

                    }

                }


                context.Result = new BadRequestObjectResult(errors);


            }

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var result = context.Result as IStatusCodeActionResult;
            if (result == null)
            {
                return;
            }
            var statusCode = result.StatusCode;
            if (statusCode == 403)
            {
                var data = context.Result as BadRequestObjectResult;
                var errors = new List<string>();

                var badRequestObjectResult = context.Result as BadRequestObjectResult;

                if (data.Value is string)
                {
                    errors.Add(data.Value.ToString());
                }
                else if (badRequestObjectResult.Value is IEnumerable<IdentityError> identityErr)
                {
                    foreach (var item in identityErr)
                    {
                        errors.Add(item.Description);
                    }
                }
                else
                {
                    foreach (var key in context.ModelState.Keys)
                    {
                        foreach (var error in context.ModelState[key].Errors)
                        {
                            errors.Add($"{key} {error.ErrorMessage}");

                        }

                    }

                }


                context.Result = new BadRequestObjectResult(errors);

            }
            // throw new NotImplementedException();
        }
    }
}
