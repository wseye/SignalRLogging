using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace signalRLogging2
{
    public class LogHub : Hub
    {
        public void Begin()
        {
            Task.Factory.StartNew(() =>
                                      {
                                          for (int i = 0; i < 10; i++)
                                          {
                                              Send(string.Format("message {0}", i));
                                          }
                                      });
        }

        public void Send(string message)
        {
            Clients.All.addMessage(message);
        }
    }
}