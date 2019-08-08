using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace TestedApp.Hubs
{
    public class PersonHub : Hub
    {
        public void Add(String key, String value)
        {
            this.Clients.All.addNewInfo(key, value);
        }
    }
}