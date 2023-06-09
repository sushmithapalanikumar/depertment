using System;
using System.Collections.Generic;

namespace depertment.Entities
{
    public partial class DepartmentModel
    {
        public DepartmentModel()
        {
            StudentModels = new HashSet<StudentModel>();
        }

        public int DepartmentId { get; set; }
        public string? DepartmentName { get; set; }

        public virtual ICollection<StudentModel> StudentModels { get; set; }
    }
}
