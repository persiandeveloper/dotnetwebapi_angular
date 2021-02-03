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
    public class StudentController : CommonApi<Student>
    {

        public StudentController(IRepository<Student> repository): base(repository)
        {

        }

        // GET: Teacher
        [System.Web.Http.HttpGet]
        public IHttpActionResult Index()
        {
            return Ok(repository.GetAllIncluding(null));
        }

        public IHttpActionResult Post(StudentModel model)
        {
            repository.Insert(new Student() { Name = model.Name });
            repository.Commit();

            return Ok();
        }

        public IHttpActionResult Put(StudentModel model)
        {
            var item = repository.GetById(model.Id);

            item.Name = model.Name;

            repository.Update(item);
            repository.Commit();

            return Ok();
        }
    }
}