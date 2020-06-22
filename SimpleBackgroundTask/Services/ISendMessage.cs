using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBackgroundTask.Services
{
    public interface ISendMessage
    {
        void Send(string url, string name, string descr);
    }
}
