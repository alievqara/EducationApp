using Core.Entities;
using DataAccess.Context;
using DataAccess.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Implementations
{
    public class StudentRepository : IRepositories<Student>
    {
        public Student Create(Student entity)
        {
            DbContext.Students.Add(entity);
            return entity;
        }

        public void Delete(Student entity)
        {
            DbContext.Students.Remove(entity);
        }

        public Student Get(Predicate<Student> filter)
        {
            if (filter == null)
            {
                return DbContext.Students[0];
            }
            else
            {
                return DbContext.Students.Find(filter);
            }
        }

        public List<Student> GetAll(Predicate<Student> filter = null)
        {
            if (filter == null)
            {
                return DbContext.Students;
            }
            else
            {
                return DbContext.Students.FindAll(filter);
            }
        }

        public void Update(Student entity)
        {
            var student = DbContext.Students.Find(g => g.ID == entity.ID);
            if (student != null)
            {
                student.Name = entity.Name;
                student.Surname = entity.Surname;
                student.Age = entity.Age;
            }
        }
    }

}
