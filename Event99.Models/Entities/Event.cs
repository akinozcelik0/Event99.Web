using Event99.DataAccess.Entities;
using Event99.Models.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event99.Models.Entities
{
    public class Event : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime EventDate { get; set; }
        public int AttendeeQuota { get; set; }
        public string Status { get; set; }


        //Navigation Properties
        public Guid? LocationId { get; set; }
        public Location? Location { get; set; }
        public Guid? CategoryId { get; set; }
        public Category? Category { get; set; }
        public ICollection<Ticket>? Tickets { get; set; }
        public string? ApplicationUserId { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }

    }
}
