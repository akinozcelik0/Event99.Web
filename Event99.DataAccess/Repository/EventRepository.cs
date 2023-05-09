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
    public class EventRepository : Repository<Event>, IEventRepository
    {
        private readonly ApplicationDbContext _db;

        public EventRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
