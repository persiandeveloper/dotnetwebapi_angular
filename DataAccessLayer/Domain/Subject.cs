using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Domain
{
    public class Subject : IEntity
    {
        public int Id { get; set; }

        public Course Course { get; set; }

        public Teacher Teacher { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }

    }
}
