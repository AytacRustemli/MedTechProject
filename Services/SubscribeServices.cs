using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Entities;

namespace Services
{
    public class SubscribeServices
    {
        private readonly MedTechDbContext _context;

        public SubscribeServices(MedTechDbContext context)
        {
            _context = context;
        }

        public void Post(Subscribe subscribe)
        {
            _context.Subscribes.Add(subscribe);
            _context.SaveChanges();
        }
    }
}
