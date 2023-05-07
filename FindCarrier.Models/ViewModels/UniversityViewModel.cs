using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindCarrier.Models.ViewModels
{
    public class UniversityViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Place { get; set; }
        public bool IsDeleted { get; set; }
        public string Location { get; set; }
        public string Field { get; set; }
        public string SchoolType { get; set; }
        public List<UniversityViewModel> University { get; set; }
    }
}
