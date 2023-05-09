using Event99.DataAccess.Entities;
using Event99.Models.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event99.Models.Entities
{
    public class Ticket : BaseEntity
    {
        public Ticket()
        {
            var rnd = new Random();
            var generatedNumbers = new HashSet<long>();
            while (true)
            {
                long ticketNumber = (long)(rnd.NextDouble() * 10000000000000);
                if (!generatedNumbers.Contains(ticketNumber))
                {
                    generatedNumbers.Add(ticketNumber);
                    TicketNumber = ticketNumber;
                    break;
                }
            }
        }
        public double TicketNumber { get; set; }
        public Guid? EventId { get; set; }
        public Event? Event { get; set; }
        public string? ApplicationUserId { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }

    }
}
