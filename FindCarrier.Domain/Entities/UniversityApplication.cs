using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindCarrier.Domain.Entities
{
    public class UniversityApplication
    {
        [Key]
        public int Id { get; set; }
        public Resume Resume { get; set; }
        public DateTime AppliedDate { get; set; }
        public bool IsDeleted { get; set; }
        public string UniversityName { get; set; }
        public string StudentName { get; set; }
        public string ApplicationStatus { get; set; }
    }
}
