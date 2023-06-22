using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProjectBook.Models.ViewModels
{
    public class ProductVM
    {
        public Product product { get; set; }
        public IEnumerable<SelectListItem> Categorylist { get; set; }
    }
}
