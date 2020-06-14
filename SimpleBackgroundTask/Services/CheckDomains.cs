using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace SimpleBackgroundTask.Services
{
    public class CheckDomains
    {
        private int timeOut = 10000;
        private readonly IDomainService _domainService;
        public CheckDomains(IDomainService domainService)
        {
            _domainService = domainService;
        }
        public void Check()
        {
            Ping pingSender = new Ping();

            var model = _domainService.GetAll();
            foreach(var item in model)
            {
                var pingReply = pingSender.Send(item.Url, timeOut);
                if(pingReply.Status == IPStatus.Success)
                {
                    Console.WriteLine("host is available");
                }
                else
                {
                    Console.WriteLine("host is not available");
                }
            }
        }
    }
}
