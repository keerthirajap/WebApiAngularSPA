namespace WebApi.Infrastructure.Filters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc.ApplicationModels;
    using Microsoft.AspNetCore.Mvc.Authorization;

    public class AuthorizationFilter : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            if (controller.ControllerName.Contains("Api"))
            {
                controller.Filters.Add(new AuthorizeFilter("apipolicy"));
            }
            else
            {
                controller.Filters.Add(new AuthorizeFilter("defaultpolicy"));
            }
        }
    }
}