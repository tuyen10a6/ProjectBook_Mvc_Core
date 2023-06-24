using Project.DataAccess.Data;
using Project.DataAccess.Repository;
using Project.Models;
using ProjectBook.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBook.DataAccess.Repository
{
    public class SlideHomeRepository : Repository<SildeHome>, ISlideRepository
    {
        private ApplicationDbContext _db;
        public SlideHomeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(SildeHome obj)
        {
            _db.Update(obj);
        }
    }
}
