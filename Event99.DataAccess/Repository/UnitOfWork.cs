using Event99.DataAccess.Contexts;
using Event99.DataAccess.Repository.IRepository;
using Event99.Models.Entites;
using Event99.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event99.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            ApplicationUser = new ApplicationUserRepository(_db);
            Category = new CategoryRepository(_db);
            City = new CityRepository(_db);
            Location = new LocationRepository(_db);
            Event = new EventRepository(_db);
            Ticket = new TicketRepository(_db);
            
        }
        public IApplicationUserRepository ApplicationUser { get; private set; }

        public ICategoryRepository Category { get; private set; }

        public ICityRepository City { get; private set; }

        public ILocationRepository Location { get; private set; }

        public IEventRepository Event { get; private set; }

        public ITicketRepository Ticket { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
