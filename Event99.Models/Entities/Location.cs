using Event99.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Event99.Models.Entities
{
    public class Location : BaseEntity
    {
        public string Adress { get; set; }

        public Guid? CityId { get; set; }
        public City? City { get; set; }
    }
}
