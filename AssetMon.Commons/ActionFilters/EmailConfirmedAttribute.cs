using AssetMon.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class EmailConfirmedAttribute : AuthorizeAttribute, IAsyncAuthorizationFilter
{
    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        if (context.HttpContext.User.Identity?.IsAuthenticated == true)
        {
            var userManager = context.HttpContext.RequestServices.GetService(typeof(UserManager<AppUser>)) as UserManager<AppUser>;

            if (userManager != null)
            {
                var user = await userManager.GetUserAsync(context.HttpContext.User);

                if (user != null && !user.EmailConfirmed)
                {
                    context.Result = new ContentResult
                    {
                        Content = "Email not confirmed",
                        StatusCode = 403,
                        ContentType = "text/plain"
                    };
                    return;
                }
            }
        }
    }
}
