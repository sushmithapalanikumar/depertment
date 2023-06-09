using System;
using System.Collections.Generic;

namespace depertment.Entities
{
    public partial class StudentModel
    {
        public int StudentId { get; set; }
        public string? StudentName { get; set; }
        public string? Course { get; set; }
        public string? Specialization { get; set; }
        public int? Percentage { get; set; }
        public int? DepartmentId { get; set; }

        public virtual DepartmentModel? Department { get; set; }
    }
}
