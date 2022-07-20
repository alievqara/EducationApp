using System;
using Core.Constants;
using Core.Entities;
using Core.Helpers;
using DataAccess.Repository.Implementations;

namespace Manage
{
    public class Program
    {
        public static void Main()
        {
            GroupRepository _groupRepository = new GroupRepository();

            ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "Welcome to Education Application");

            Console.WriteLine("------------------------------------------------------------------------------------");

            while (true)
            {
                Console.WriteLine("------------------------------------------------------------------------------------");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "Menu");
                Console.WriteLine("------------------------------------------------------------------------------------");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.White, "1 - Create");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.White, "2 - Update");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.White, "3 - Delete");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.White, "4 - Get for Name");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.White, "5 - All Entity");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.White, "0 - Exit");
                Console.WriteLine("------------------------------------------------------------------------------------");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "Select option: ");
                string number = Console.ReadLine();
                Console.WriteLine("------------------------------------------------------------------------------------");

                int selectedNumber;
                bool result = int.TryParse(number, out selectedNumber);
                if (result)
                {
                    if (selectedNumber >= 0 && selectedNumber <= 5)
                    {

                        switch (selectedNumber)
                        {
                            #region Exit
                            case (int)Options.Exit:
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "Thanks for using Education Application");
                                return;

                            #endregion
                            #region CreateGroup
                            case (int)Options.Create:
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "Pleace Enter Name");
                                string name = Console.ReadLine();
                            MaxSize: ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "Pleace Enter Max Size Group");
                                string size = Console.ReadLine();
                                int maxSize;
                                result = int.TryParse(size, out maxSize);
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
                                break;
                            #endregion
                            case (int)Options.Update:
                                break;
                            case (int)Options.Delete:
                                break;
                            case (int)Options.GetforName:
                                break;
                            #region AllEntity
                            case (int)Options.AllEntity:
                                var groups = _groupRepository.GetAll();
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "All Group List");
                                foreach (var group in groups)
                                {
                                    Console.WriteLine($"Name: {group.Name}, Max Size: {group.MaxSize}");
                                }
                                break;
                                #endregion
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "<<< Please Select Correct Option >>>");

                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "<<< Please Select Correct Option >>>");
                }
            }



        }
    }
}