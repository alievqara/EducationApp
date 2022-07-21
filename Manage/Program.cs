using System;
using Core.Constants;
using Core.Entities;
using Core.Helpers;
using DataAccess.Repository.Implementations;
using Manage.Controllers;

namespace Manage
{
    public class Program
    {
        public static void Main()
        {
            GroupRepository _groupRepository = new GroupRepository();
            GroupControllers _groupController = new GroupControllers();

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

                                _groupController.EndApp();

                                return;
                            #endregion

                            #region CreateGroup
                            case (int)Options.Create:
                                _groupController.CreateGroup();
                                break;
                            #endregion

                            #region Update 

                            case (int)Options.Update:
                                _groupController.UpdateGroup();

                                break;

                            #endregion

                            #region Delete

                            case (int)Options.Delete:
                                _groupController.Delete();
                                break;

                            #endregion

                            #region GetforName

                            case (int)Options.GetforName:
                                _groupController.GetforName();

                                break;

                            #endregion


                            #region AllEntity
                            case (int)Options.AllEntity:
                                _groupController.GetAll();
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