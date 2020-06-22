using SimpleBackgroundTask.Controllers;
using SimpleBackgroundTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace SimpleBackgroundTask.Services
{
    public class DomainService : IDomainService
    {
        private readonly ApplicationDbContext _context;
        private readonly int timeOut = 10000;
        private readonly ISendMessage _send;
        public DomainService(ApplicationDbContext context, ISendMessage send)
        {
            _context = context;
            _send = send;
        }

        public void ChekDomain()
        {
            var model = GetAll();
            foreach (var item in model)
            {
                Uri url = new Uri(item.Url);
                string pingurl = string.Format("{0}", url.Host);
                string host = pingurl;
                Ping p = new Ping();
                try
                {
                    PingReply reply = p.Send(host, timeOut);
                    if (reply.Status == IPStatus.Success)
                    {
                        string message = "host" + item.ServerName + " is available";
                        Console.WriteLine(message);
                        //await _homeController.SendMessage(host, item.ServerName, "host is available");
                        _send.Send(host, item.ServerName, "host is available");
                    }
                    else
                    {
                        Console.WriteLine("host is not available");
                    }
                }
                catch { }
            }
        }

        public IEnumerable<Domains> GetAll()
        {
            return _context.Domain;
        }
    }
}
