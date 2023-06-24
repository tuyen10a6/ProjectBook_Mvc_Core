using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Project.Models
{
    public class SildeHome
    {
        [Key]
        public int Id { get; set; }
        [ValidateNever]
        public string LinkImage { get; set; }
  
    }
}
