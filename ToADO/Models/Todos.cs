using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ToADO.Models
{
    public class Todos
    {
        public int id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Item { get; set; }

    }
}