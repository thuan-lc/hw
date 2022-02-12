using LibraryManagementAPI.Contracts.V1.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementAPI.Filters
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState
                    .Where(ms => ms.Value.Errors.Count() > 0)
                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(e => e.ErrorMessage)).ToArray();

                var errResponse = new ErrorResponse();

                foreach (var error in errors)
                {
                    foreach (var subError in error.Value)
                    {
                        var errorModel = new ErrorModel
                        {
                            FieldName = error.Key,
                            Message = subError
                        };
                        errResponse.Errors.Add(errorModel);
                    }
                }

                context.Result = new BadRequestObjectResult(errResponse);
                return;
            }

            await next();
        }
    }
}
