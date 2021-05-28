﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Net;
using TIPP.Client.Service;

namespace BlazorApp.Helpers
{
    public class AppRouteView : RouteView
    {
        //[Inject]
        //public NavigationManager NavigationManager { get; set; }

        //[Inject]
        //public IUserDataService userDataService { get; set; }

        //protected override void Render(RenderTreeBuilder builder)
        //{
        //    Console.WriteLine("Authorizing");
        //    var authorize = Attribute.GetCustomAttribute(RouteData.PageType, typeof(AuthorizeAttribute)) != null;
        //    if (authorize && userDataService.User == null)
        //    {
        //        var returnUrl = WebUtility.UrlEncode(new Uri(NavigationManager.Uri).PathAndQuery);
        //        Console.WriteLine(returnUrl);
        //        NavigationManager.NavigateTo($"user/login");
        //    }
        //    else
        //    {
        //        base.Render(builder);
        //    }
        //}

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IUserDataService AccountService { get; set; }

        protected override void Render(RenderTreeBuilder builder)
        {
            var authorize = Attribute.GetCustomAttribute(RouteData.PageType, typeof(AuthorizeAttribute)) != null;
            if (authorize && AccountService.User == null)
            {
                var returnUrl = WebUtility.UrlEncode(new Uri(NavigationManager.Uri).PathAndQuery);
                NavigationManager.NavigateTo($"user/login?returnUrl={returnUrl}");
            }
            else
            {
                base.Render(builder);
            }
        }
    }
}