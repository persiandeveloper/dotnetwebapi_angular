using DataAccessLayer.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class SchoolContext : DbContext
    {
        public SchoolContext() : base("SchoolContext")
        {
            Database.SetInitializer(new SchoolDBInitializer());

        }
        // Entities        
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
    }

    public class SchoolDBInitializer : DropCreateDatabaseIfModelChanges<SchoolContext>
    {
        protected override void Seed(SchoolContext context)
        {
            Course newCourse1 = new Course() { Name = "Computer" };
            Course newCourse2 = new Course() { Name = "Math" };

            Student student = new Student() { Name = "John" };
            Student student2 = new Student() { Name = "Babak" };


            Teacher teacher = new Teacher() { Name = "Mr A", BirthDate = "1990.02.02" };

            Teacher teacher2 = new Teacher() { Name = "Ms B", BirthDate = "1986.06.02" };

            Subject subject = new Subject() { Teacher = teacher, Course = newCourse1 };

            Subject subject2 = new Subject() { Teacher = teacher2, Course = newCourse2 };


            Enrollment enrollment1 = new Enrollment() { Subject =subject, Score = 20, Student = student };

            Enrollment enrollment2 = new Enrollment() { Subject = subject2, Score = 17, Student = student2 };


            context.Courses.Add(newCourse1);
            context.Courses.Add(newCourse2);


            context.Students.Add(student);
            context.Students.Add(student2);

            context.Teachers.Add(teacher);
            context.Teachers.Add(teacher2);

            context.Subjects.Add(subject);
            context.Subjects.Add(subject2);

            context.Enrollments.Add(enrollment1);
            context.Enrollments.Add(enrollment2);

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
