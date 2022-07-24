using Core.Entities;
using Core.Helpers;
using DataAccess.Repository.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Controllers
{
    public class StudentController
    {
        private GroupRepository _groupRepository;
        private StudentRepository _studentRepository;
        public StudentController()
        {
            _groupRepository = new GroupRepository();
            _studentRepository = new StudentRepository();

        }

        #region AddStudent



        public void AddStudent()
        {
            var groups = _groupRepository.GetAll();
            if (groups != null)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "Please Enter Student Name: ");
                string name = Console.ReadLine();

                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "Please Enter Student Surname: ");
                string surname = Console.ReadLine();

                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "Please Enter Student Father Name: ");
                string fatherName = Console.ReadLine();

                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "Please Enter Student Age: ");
                string age = Console.ReadLine();
                byte studentAge;
                bool result = byte.TryParse(age, out studentAge);

            AllGroup: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "All Groups: ");


                foreach (var group in groups)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, group.Name);
                }

                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "Enter the name of the group of your choice:");
                string choiceGroup = Console.ReadLine();

                var groupName = _groupRepository.Get(g => g.Name.ToLower() == choiceGroup.ToLower());

                if (groupName != null)
                {
                    if (groupName.MaxSize > groupName.CurretSize)
                    {
                        var student = new Student
                        {
                            Name = name,
                            Surname = surname,
                            FatherName = fatherName,
                            Age = studentAge,
                            Group = groupName,


                        };

                        groupName.CurretSize++;
                        _studentRepository.Create(student);
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, $"Name: {student.Name}, Surname: {student.Surname}, Father Name: {student.FatherName}, Studen Age: {student.Age}");



                    }
                    else
                    {

                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, $"The group is full: Group Max Student Capasity: {groupName.MaxSize}");
                    }

                }
                else
                {

                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Including group doesn't exist");
                }

            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "You must create group before creating of student");

            }
        }


        #endregion

        #region UpdateStudent

        public void UpdateStudent()
        {


        }

        #endregion

        #region Deletestudent

        public void Delete()
        {


            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "Enter Student Name");
            string name = Console.ReadLine();
            var student = _studentRepository.Get(s => s.Name.ToLower() == name.ToLower());


            if (student != null)
            {
                _studentRepository.Delete(student);

                //student.Group.CurretSize--;
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, $"Student '{name} ' is successfully deleted.");


            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "This student doesn't exist");

            }

        }

        #endregion

        #region AllStudents
        public void GetAll()
        {
            var students = _studentRepository.GetAll();
            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "All Student List");
            foreach (var student in students)
            {
                Console.WriteLine($"{student.Name}  {student.Surname} {student.FatherName}  {student.Age}  {student.Group}");
            }

        }
        #endregion

        #region Get Group Students

        public void GetGroupStudents()
        {
            var groups = _groupRepository.GetAll();

        GroupAllList: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "All Groups");
            foreach (var group in groups)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, group.Name);
            }

            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "Enter Group Name:");
            string choiceGroup = Console.ReadLine();

            var groupName = _groupRepository.Get(g => g.Name.ToLower() == choiceGroup.ToLower());
            if (groupName != null)
            {
                var groupStudents = _studentRepository.GetAll(s => s.Group.ID == groupName.ID);

                if (groupStudents.Count != 0)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "All student of group:");
                    foreach (var student in groupStudents)
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, $"{student.Name} {student.Surname} {student.FatherName} {student.Age}");

                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, $"There is no student in this group '{groupName.Name}'");

                }

            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Including group doesn't exist");
                goto GroupAllList;
            }



        }

        #endregion

    }
}
