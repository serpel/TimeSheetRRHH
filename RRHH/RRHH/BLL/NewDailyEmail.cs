using System;
using System.Collections.Generic;
using Postal;
using RRHH.Models;

namespace RRHH.BLL
{
    public class NewDailyEmail : Email
    {
        public string To { get; set; }
        public string From { get; set; }
        public DateTime Date { get; set; }
        public string Subject { get; set;}
        public string Body { get; set; }
        public List<TimeSheet> RecordList { get; set; }
    }
}
