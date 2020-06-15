using SimpleBackgroundTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBackgroundTask.Services
{
    public interface IDomainService
    {
        IEnumerable<Domains> GetAll();
        void ChekDomain();
    }
}
