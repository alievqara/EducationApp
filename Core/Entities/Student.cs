using Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Student : IEntity
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public byte Age { get; set; }
    }
}
