using Project.DataAccess.Repository.IRepository;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBook.DataAccess.Repository.IRepository
{
    public interface ISlideRepository: IRepository<SildeHome>
    {
        void Update(SildeHome obj);
        void Save();
    }
}
