using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class NewServices
    {
        private readonly MedTechDbContext _context;

        public NewServices(MedTechDbContext context)
        {
            _context = context;
        }

        public List<New> GetAll()
        {
            var news = _context.News.ToList();
            return news ;
        }

        public void CreateNew(New news)
        {
            _context.News.Add(news);
            _context.SaveChanges();
        }

        public List<New> GetNewById(int id)
        {
            return _context.News.Where(x => x.ID == id).ToList();
        }

        public void EditNew(New news,string PhotoURL)
        {
            news.PhotoURL = PhotoURL;
            var UpdatedEntity = _context.Entry(news);
            UpdatedEntity.State = EntityState.Modified;
            _context.SaveChanges();
        }

        public List<New> GetNewDetailById(int id)
        {
            return _context.News.Where(x=>x.ID == id).ToList();
        }

        public void DeleteNew(New news)
        {
            _context.News.Remove(news);
            _context.SaveChanges();
        }
    }
}
