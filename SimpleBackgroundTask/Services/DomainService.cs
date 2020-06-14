using SimpleBackgroundTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBackgroundTask.Services
{
    public class DomainService : IDomainService
    {
        private readonly ApplicationDbContext _context;
        public DomainService(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Domains> GetAll()
        {
            return _context.Domain;
        }
    }
}
