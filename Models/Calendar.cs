﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace Model
{
    public class Calendar
    {
        [DisplayName("Description")]
        public string Description { get; set; }
        [DisplayName("Event Location")]
        public string Location { get; set; }
        [DisplayName("Event Message")]
        public string Message { get; set; }
        [DisplayName("Start Time")]
        public DateTime StartTime { get; set; }
        [DisplayName("End Time")]
        public DateTime EndTime { get; set; }
    }
}
