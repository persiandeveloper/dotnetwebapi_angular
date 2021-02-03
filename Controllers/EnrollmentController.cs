using DataAccessLayer.Domain;
using DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EnrollmentController : CommonApi<Enrollment>
    {
        private readonly IRepository<Student> repositoryStudent;
        private readonly IRepository<Subject> repositorySubject;

        public EnrollmentController(IRepository<Enrollment> repository, IRepository<Student> repositoryStudent, IRepository<Subject> repositorySubject) : base (repository)
        {
            this.repositoryStudent = repositoryStudent;
            this.repositorySubject = repositorySubject;
        }

        // GET: Teacher
        [System.Web.Http.HttpGet]
        public IHttpActionResult Index()
        {
            var result = repository.GetAllIncluding(null, new[] { "Student", "Subject.Course" });

            return Ok(result.Select(r=> new { r.Id, r.Score, Student = r.Student.Name, Course = r.Subject.Course.Name }));
        }

        public IHttpActionResult Post(EnrollmentModel model)
        {
            repository.Insert(new Enrollment() { Subject = repositorySubject.GetById(model.SubjectId), Student = repositoryStudent.GetById(model.StudentId) });
            repository.Commit();

            return Ok();
        }

        public IHttpActionResult Put(EnrollmentModel model)
        {
            var enrollment = repository.GetById(model.Id);
            enrollment.Score = model.Score;

            repository.Update(enrollment);
            repository.Commit();

            return Ok();
        }
    }
}