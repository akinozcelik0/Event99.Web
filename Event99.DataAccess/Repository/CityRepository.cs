using Event99.DataAccess.Contexts;
using Event99.DataAccess.Repository.IRepository;
using Event99.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event99.DataAccess.Repository
{
    internal class CityRepository : Repository<City>, ICityRepository
    {
        private readonly ApplicationDbContext _db;

        public CityRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }
    }
}
