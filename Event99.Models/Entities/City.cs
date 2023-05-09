using Event99.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event99.Models.Entities
{
    public class City : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Location>? Locations { get; set; }
    }
}
