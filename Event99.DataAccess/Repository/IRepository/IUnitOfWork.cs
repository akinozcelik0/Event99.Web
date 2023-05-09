using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event99.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IApplicationUserRepository ApplicationUser { get; }
        ICategoryRepository Category { get; }
        ICityRepository City { get; }
        ILocationRepository Location { get; }
        IEventRepository Event { get; }
        ITicketRepository Ticket { get; }

        void Save();
    }
}
