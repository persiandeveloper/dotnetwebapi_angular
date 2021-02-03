using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class CommonModel
    {
        public int Id { get; set; }
    }

    public class TeacherModel : CommonModel
    {
        public string Name { get; set; }

        public string BirthDate { get; set; }
    }

    public class StudentModel : CommonModel
    {
        public string Name { get; set; }

    }

    public class CourseModel : CommonModel
    {
        public string Name { get; set; }

    }

    public class SubjectModel : CommonModel
    {
        public int CourseId { get; set; }
        public int TechaerId { get; set; }

    }

    public class EnrollmentModel : CommonModel
    {
        public int SubjectId { get; set; }
        public int StudentId { get; set; }
        public int Score { get; set; }


    }
}