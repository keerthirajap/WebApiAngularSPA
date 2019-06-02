namespace BlazorSPA.Shared
{
    using Blazored.LocalStorage;
    using BlazorSPA.Infrastructure;
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Layouts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class MainLayoutBase : LayoutComponentBase
    {
        protected bool IsUserAuthenticated { get; set; }

        protected bool IsLoginNavVisible { get; set; }

        protected bool IsFullNavVisible { get; set; }

        public MainLayoutBase()
        {
            // this.IsUserAuthenticated = this._appState.CheckUserAuthenticationAsync();
        }

        protected async Task MainLayoutOnLoad()
        {
        }
    }
}