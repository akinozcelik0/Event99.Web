using Event99.Models.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event99.Models.ViewModels.Event
{
    public class EventViewModel
    {
        public Event99.Models.Entities.Event Event { get; set; }
        public Location Location { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> CityList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> CategoryList { get; set; }
    }
}
