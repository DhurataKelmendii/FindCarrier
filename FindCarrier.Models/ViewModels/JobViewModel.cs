﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindCarrier.Models.ViewModels
{
    public class JobViewModel
    {
        public int Id { get; set; }
        public string JobName { get; set; }
        public string Position { get; set; }
        public string CompanyName { get; set; }
        public bool IsDeleted { get; set; }
        public string Place { get; set; }
        public string Deadline { get; set; }
        public List<JobViewModel> Job { get; set; }
    }
}
