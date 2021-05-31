using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TIPP.Client.Service;

namespace TIPP.Client.Helpers
{
    public class AppRouteView : RouteView
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IUserDataService userDataService { get; set; }

        protected override void Render(RenderTreeBuilder builder)
        {
            Console.WriteLine("Authenticating");
            var authorize = Attribute.GetCustomAttribute(RouteData.PageType, typeof(AuthorizeAttribute)) != null;
            if (authorize && userDataService.User == null)
            {
                Console.WriteLine("Authentication failed");
                var returnUrl = WebUtility.UrlEncode(new Uri(NavigationManager.Uri).PathAndQuery);
                NavigationManager.NavigateTo($"account/login?returnUrl={returnUrl}");
            }
            else
            {
                Console.WriteLine("Authentication good");
                base.Render(builder);
            }
        }
    }
}
