namespace WebAppMVC.Infrastructure.SignalRHubs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.SignalR;

    public class AnonymousHub : Hub
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AnonymousHub(IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;
        }

        public string GetConnectionId()
        {
            return Context.ConnectionId;
        }
    }
}