using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace SimpleWebAPI.Api.Infrastructure.Attributes
{
    public class AuthorizeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            try
            {
                var isUserAuthenticated = context.HttpContext.User.Identity.IsAuthenticated;
                if (!isUserAuthenticated)
                    context.Result = new UnauthorizedResult();

                base.OnActionExecuting(context);
            }
            catch (Exception)
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}
