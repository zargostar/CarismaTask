using Microsoft.AspNetCore.Mvc;

namespace OrderService.API.Filters
{
    public class BadRequestBehavior
    {
        public static void Parse(ApiBehaviorOptions options)
        {
            options.InvalidModelStateResponseFactory = context =>
            {
                var response = new List<string>();
                foreach (var key in context.ModelState.Keys)
                {
                    foreach (var error in context.ModelState[key].Errors)
                    {
                        response.Add( error.ErrorMessage);

                    }

                }


                return new BadRequestObjectResult(response);
            };

        }
    }
}
