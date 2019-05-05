namespace WebApi.Infrastructure.Filters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Antiforgery;
    using Microsoft.AspNetCore.Mvc.Filters;
    using WebApi.Models.V1._0;

    public class ValidateModelStateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var response = new SingleResponse<dynamic>();

            if (!context.ModelState.IsValid)
            {
                var errors = new Dictionary<string, string>();
                foreach (var state in context.ModelState)
                {
                    foreach (var error in state.Value.Errors)
                    {
                        errors.Add(state.Key, error.ErrorMessage);
                    }
                }

                response.ErrorMessage = "One or More Validation error(s) occured";
                response.DidValidationError = true;
                response.Model = errors;
                context.Result = response.ToHttpResponse();
            }
        }
    }
}