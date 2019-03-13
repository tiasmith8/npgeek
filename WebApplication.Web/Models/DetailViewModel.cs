using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Web.Models
{
    public class DetailViewModel
    {
        public Park park { get; set; }
        public IList<Weather> forecast { get; set; }
    }
}
