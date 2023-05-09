using Event99.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event99.Models.ViewModels.Ticket
{
    public class TicketViewModel
    {
        public Event99.Models.Entities.Ticket Ticket { get; set; } 
        public string EventName { get; set; }
    }
}
