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
    public class SubjectController : CommonApi<Subject>
    {
        private readonly IRepository<Course> repositoryCourse;
        private readonly IRepository<Teacher> repositoryTeacher;

        public SubjectController(IRepository<Subject> repository, IRepository<Course> repositoryCourse, IRepository<Teacher> repositoryTeacher) : base(repository)
        {
            this.repositoryCourse = repositoryCourse;
            this.repositoryTeacher = repositoryTeacher;
        }

        // GET: Teacher
        [System.Web.Http.HttpGet]
        public IHttpActionResult Index()
        {
            var result = repository.GetAllIncluding(null, new[] { "Course", "Teacher", "Enrollments" });

            var finalResult = result.Select(r => new { r.Id, Students = r.Enrollments.Count, Average = r.Enrollments.Count > 0 ? r.Enrollments.Average(y =>y.Score) : 0, Teacher = r.Teacher.Name, Course = r.Course.Name });

            return Ok(finalResult);
        }

        public IHttpActionResult Post(SubjectModel model)
        {
            repository.Insert(new Subject() { Course = repositoryCourse.GetById(model.CourseId), Teacher = repositoryTeacher.GetById(model.TechaerId) });
            repository.Commit();

            return Ok();
        }
    }
}