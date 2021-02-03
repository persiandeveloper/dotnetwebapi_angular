﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Domain
{
    public class Course : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Subject> Subjects { get; set; }
    }
}
