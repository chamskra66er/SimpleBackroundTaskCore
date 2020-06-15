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
        public DomainService(ApplicationDbContext context)
        {
            _context = context;
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
                        Console.WriteLine("host is not available");
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
