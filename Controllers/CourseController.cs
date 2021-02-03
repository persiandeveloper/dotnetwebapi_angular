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
    public class CourseController : CommonApi<Course>
    {
        public CourseController(IRepository<Course> repository) : base(repository)
        {
        }


        // GET: Teacher
        [System.Web.Http.HttpGet]
        public IHttpActionResult Index()
        {
            var courses = repository.GetAllIncluding(null, "Subjects.Enrollments");

            var result = courses.Select(r => new
            { Id = r.Id, Name = r.Name,
                Students = r.Subjects.SelectMany(t => t.Enrollments.Select(y => y.Student).Distinct()).Count(),
                Average = r.Subjects.Count > 0 ? r.Subjects.Select(t => t.Enrollments.Select(y => (double)y.Score)).SelectMany(e => e).Average(t => t) : 0,
               Teachers = r.Subjects.Select(t => t.Teacher).Distinct().Count(), }).ToList(); 

            return Ok(result);
        }

        public IHttpActionResult Post(CourseModel model)
        {
            repository.Insert(new Course() {  Name = model.Name });
            repository.Commit();

            return Ok();
        }

        public IHttpActionResult Put(CourseModel model)
        {
            var item = repository.GetById(model.Id);

            item.Name = model.Name;

            repository.Update(item);
            repository.Commit();

            return Ok();
        }
    }
}