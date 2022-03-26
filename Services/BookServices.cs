using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Entities;

namespace Services
{
    public class BookServices
    {
        private readonly MedTechDbContext _context;

        public BookServices(MedTechDbContext context)
        {
            _context = context;
        }

        public List<Book> GetAll()
        {
            return _context.Books.ToList();
        }

        public void Postt(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }
    }
}
