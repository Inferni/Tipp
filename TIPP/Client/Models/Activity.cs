using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TIPP.Client.Models
{
    public class Activity
    {
        [Required]
        public string Name { get; set; }
    }
}
