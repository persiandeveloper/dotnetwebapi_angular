using DataAccessLayer.Domain;
using DataAccessLayer.Repository;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class TeacherController : CommonApi<Teacher>
    {

        public TeacherController(IRepository<Teacher> repository) : base(repository)
        {
        }

        // GET: Teacher
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(repository.GetAllIncluding(null));
        }
     
        public IHttpActionResult Post(TeacherModel model)
        {
            repository.Insert(new Teacher() { BirthDate = model.BirthDate,Name=model.Name });
            repository.Commit();

            return Ok();
        }

        public IHttpActionResult Put(TeacherModel model)
        {
            var item = repository.GetById(model.Id);

            item.Name = model.Name;
            item.BirthDate = model.BirthDate;

            repository.Update(item);
            repository.Commit();

            return Ok();
        }

    }
}