using System;
using Custom_Exceptions.Exceptions;
using IEntity_interface.Models;
using Utils.Enum;

namespace IEntity_interface
{
    class Program
    {
        static void Main(string[] args)
        {

            byte role;
            bool isNum;
            User user;
            Console.Write("Enter name:");
            string name = Console.ReadLine();
            Console.Write("Enter Email:");
            string email = Console.ReadLine();
            do
            {

                Console.WriteLine("Role (1. Admin, 2.Member):");
                string roleStr = Console.ReadLine();
                isNum = byte.TryParse(roleStr, out role);

                user = new User(name, email, (Role)role);
            } while (!isNum || !Enum.IsDefined(typeof(Role), role));



            Library library = new Library();
            int choice;
            do
            {
                Console.WriteLine("Menu");
                Console.WriteLine("1.Add book");
                Console.WriteLine("2.Get book by id");
                Console.WriteLine("3.Get all books");
                Console.WriteLine("4.Delete book by id");
                Console.WriteLine("5.Edit book name");
                Console.WriteLine("6.Filter by page count");
                Console.WriteLine("0.Quit");
                choice = Convert.ToInt32(Console.ReadLine());
                try
                {


                    switch (choice)
                    {
                        case 1:
                            if (user.Role == Role.Admin)
                            {
                                Console.Write("Enter book name:");
                                string bookName = Console.ReadLine();
                                Console.Write("Enter the author name:");
                                string bookAuthorName = Console.ReadLine();
                                Console.Write("Enter count of pages:");
                                int bookPageCount = Convert.ToInt32(Console.ReadLine());
                                Book book = new Book(bookName, bookAuthorName, bookPageCount);
                                library.AddBook(book);
                            }
                            else
                            {
                                Console.WriteLine("You are not allowed to add book");
                            }
                            break;
                        case 2:
                            Console.Write("Enter Id:");
                            int bookId = Convert.ToInt32(Console.ReadLine());
                            library.GetBookById(bookId).ShowInfo();

                            break;
                        case 3:
                            Console.WriteLine("All books");
                            foreach (var item in library.GetAllBook())
                            {
                                item.ShowInfo();
                            }

                            break;
                        case 4:
                            if (user.Role == Role.Admin)
                            {
                                Console.Write("Enter the Id to delete:");
                                int deleteBookId = Convert.ToInt32(Console.ReadLine());
                                library.DeleteBookById(deleteBookId);
                            }
                            else
                            {
                                Console.WriteLine("You are not allowed to delete");
                            }
                            break;
                        case 5:
                            if (user.Role == Role.Admin)
                            {
                                Console.Write("Enter Id");
                                int editId = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Enter a new name:");
                                string newBookName = Console.ReadLine();
                                library.EditBookName(editId, newBookName);
                            }
                            else
                            {
                                Console.WriteLine("You are not allowed to make changes");
                            }
                            break;
                        case 6:
                            Console.WriteLine("Enter a Minimum:");
                            int minNumber = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter a Max:");
                            int maxNumber = Convert.ToInt32(Console.ReadLine());
                            library.FilterByPageCount(minNumber, maxNumber);

                            break;
                        default:
                            break;
                    }

                }
                catch (AlreadyExistsException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (CapacityLimitException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (NotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (choice != 0);
        }
    }
}

