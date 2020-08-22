using EMS.Entity;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.Web.SignalRHubs
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/aspnet/core/tutorials/signalr?view=aspnetcore-3.1&tabs=visual-studio
    /// 
    /// https://www.youtube.com/watch?v=r7nLlTGBcoY
    /// 
    /// https://www.youtube.com/watch?v=RUZLIh4Vo20
    /// 
    /// https://www.youtube.com/watch?v=YwezzKWrFuo
    /// 
    /// https://www.youtube.com/watch?v=yr_-MArHXUM&list=PLThyvG1mlMzltDxuQj0uQw1TDu1gJUNeG
    /// </summary>
    public class EmployeeHub : Hub
    {
        // A hub is a class that serves as a high-level pipeline that handles client-server communication.

        // The Hub class manages connections, groups, and messaging.

        // https://www.zealousweb.com/signalr-to-send-real-time-notifications-with-asp-net-core/    >>>>>>>>>>>USE IT>>>>>>>>>>>>>

        public async Task sendToUser(Employee model)
        {
            await Clients.All.SendAsync("ReceiveMessage", model);
        }

        public async Task ReceiveMessage(Employee model)
        {
            await Clients.All.SendAsync("ReceiveMessage", model);
        }

    }
}
