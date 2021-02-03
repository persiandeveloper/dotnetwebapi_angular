using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Domain
{
    public class Enrollment : IEntity
    {
        public int Id { get; set; }

        public Student Student { get; set; }

        public Subject Subject { get; set; }

        public int Score { get; set; }
    }
}
