﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AJAX_BD_PR.Models
{
    public class District
    {
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }
        public int divListId { get; set; }
        public divList divList { get; set; }
        public List<Upazila> Upazilas { get; set; }
    }
}
