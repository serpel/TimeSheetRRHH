﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RRHH.Models
{
    public class ShiftViewModel
    {
        public int ShiftId { get; set; }
        public int CompanyId { get; set; }
        public string ShiftName { get; set; }
        public string ShiftDescription { get; set; }
        public List<ShiftTime> TimeList { get; set; } 
    }
}