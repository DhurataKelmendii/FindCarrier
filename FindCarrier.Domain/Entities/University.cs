using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindCarrier.Domain.Entities
{
    public class University
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Place { get; set; }
        public string Location { get; set; }
        public string Field { get; set; }
        public string SchoolType { get; set; }
        public string Logo { get; set; }
        public string WebsiteLink { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
    }
}
