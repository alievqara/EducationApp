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
            GroupControllers _groupController = new GroupControllers();
            StudentController _studentController = new StudentController();

            ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "Welcome to Education System");

            Console.WriteLine("------------------------------------------------------------------------------------");

            while (true)
            {
                Console.WriteLine("------------------------------------------------------------------------------------");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "Menu");
                Console.WriteLine("------------------------------------------------------------------------------------");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.White, "1 -  Create Group");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.White, "2 -  Update Group");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.White, "3 -  Delete Group");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.White, "4 -  Get for Name Group");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.White, "5 -  All Group");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.White, "6 -  Add Student");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.White, "7 -  Update Student");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.White, "8 -  Get All Student");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.White, "9 -  Delete Student");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.White, "10 - Get Group Students");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.White, "0 - Exit");
                Console.WriteLine("------------------------------------------------------------------------------------");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "Select option: ");
                string number = Console.ReadLine();
                Console.WriteLine("------------------------------------------------------------------------------------");

                int selectedNumber;
                bool result = int.TryParse(number, out selectedNumber);
                if (result)
                {
                    if (selectedNumber >= 0 && selectedNumber <= 10)
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

                            #region AllEntity
                            case (int)Options.AllEntity:
                                _groupController.GetAll();
                                break;
                            #endregion

                            #region GetforName

                            case (int)Options.GetforName:
                                _groupController.GetforName();

                                break;

                            #endregion

                            #region AddStudent
                            case (int)Options.AddStudent:
                                _studentController.AddStudent();
                                break;

                            #endregion

                            #region Get Group Student
                            case (int)Options.GetGroupStudents:
                                _studentController.GetGroupStudents();
                                break;
                            #endregion

                            #region Delete Student 

                            case (int)Options.DeleteStudent:
                                _studentController.Delete();
                                break;
                            #endregion

                            #region AllStudent 

                            case (int)Options.AllStudents:
                                _studentController.GetAll();
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