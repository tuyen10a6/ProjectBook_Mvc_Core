using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    public class SildeHome
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string LinkImage { get; set; }
  
    }
}
