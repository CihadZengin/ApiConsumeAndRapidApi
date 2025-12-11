using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.EntityLayer.Concrete
{
    public class WorkLocation
    {
        public int WorkLocationID { get; set; }
        public string WorkLocationName { get; set; }
        public string WorkLocationCityName { get; set; }

        public List<AppUser> AppUsers { get; set; }

    }
}
