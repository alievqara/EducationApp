using Core.Constants;
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
    public class GroupControllers
    {
        private GroupRepository _groupRepository;

        public GroupControllers()
        {
            _groupRepository = new GroupRepository();
        }

        #region Exit

        public void EndApp()
        {
            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "Thanks for using Education Application");

        }
        #endregion

        #region CreateGroup

        public void CreateGroup()
        {


            ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "Pleace Enter Name");
            string name = Console.ReadLine();
        MaxSize: ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "Pleace Enter Max Size Group");
            string size = Console.ReadLine();
            int maxSize;
            bool result = int.TryParse(size, out maxSize);
            if (result)
            {
                Group group = new Group
                {
                    Name = name,
                    MaxSize = maxSize,
                };
                var createdGroup = _groupRepository.Create(group);
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, $"{createdGroup.Name} is successfully created.");

            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "Pleace Enter Correct Max Size Group");
                goto MaxSize;

            }


        }
        #endregion

        #region Update

        public void UpdateGroup()
        {
            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "Enter Group Name");
            string groupName = Console.ReadLine();

            var group = _groupRepository.Get(g => g.Name.ToLower() == groupName.ToLower());

            if (group != null)
            {
                int oldSize = group.MaxSize;
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "Enter New Group Name");
                string newName = Console.ReadLine();

                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "Enter New Max Size");
                string size = Console.ReadLine();

                int maxSize;
                bool result = int.TryParse(size, out maxSize);
                if (result)
                {
                    var newGroup = new Group
                    {
                        ID = group.ID,
                        Name = newName,
                        MaxSize = maxSize

                    };

                    _groupRepository.Update(newGroup);

                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, $"Name;{groupName},Max Size: {oldSize} is Updated to Name: {newGroup.Name}, Max Size: {maxSize}");

                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "Please, enter correct group 'Name' and 'MAx Size'");
                }

            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "Please, enter correct group 'Name' and 'Max Size'");

            }

        }

        #endregion

        #region GetForAll

        

        public void GetAll()
        {
            var groups = _groupRepository.GetAll();
            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "All Group List");
            foreach (var group in groups)
            {
                Console.WriteLine($"Name: {group.Name}, Max Size: {group.MaxSize}");
            }
        }

        #endregion

        #region Delete

        public void Delete()
        {
            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "Enter Group Name");
            string name = Console.ReadLine();
            var group = _groupRepository.Get(g => g.Name.ToLower() == name.ToLower());

            if (group != null)
            {
                _groupRepository.Delete(group);
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, $"Group '{name}' is successfully deleted.");

            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "This group doesn't exist");

            }
        }


        #endregion

        #region GetForName

        public void GetforName()
        {

            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "Enter Group Name");
            string name = Console.ReadLine();

            var group = _groupRepository.Get(g => g.Name.ToLower() == name.ToLower());
            if (group != null)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, $"Name: {group.Name}, Max Size: {group.MaxSize}");

            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "This group doesn't exist");

            }


        }

            #endregion
    }
}
