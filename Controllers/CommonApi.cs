using DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class CommonApi<T> : ApiController where T : class
    {
        protected readonly IRepository<T> repository;

        public CommonApi(IRepository<T> repository)
        {
            this.repository = repository;
        }

        public IHttpActionResult Delete(int id)
        {
            var item = repository.GetById(id);


            repository.Delete(item);
            repository.Commit();

            return Ok();
        }
    }
}