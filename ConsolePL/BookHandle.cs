using Persistence;
using BL;
using Utilities;
using System.Text.RegularExpressions;

namespace ConsolePL
{
    public class BookHandle
    {
        static BookBL bookBl = new BookBL();
        static List<Book> list = new List<Book>();
        public static void ShowListOfSearchedBooks(string searchKey, int choice)
        {
            if (choice == 1)
            {
                list = bookBl.GetBookByBookName(searchKey);
            }
            else if (choice == 2)
            {
                list = bookBl.GetBookByCategoryName(searchKey);
            }
            string search = '"' + searchKey + '"';
            if (list.Count == 0)
            {
                Console.WriteLine($"There are no books matching the keyword {search}");
            }
            else
            {
                int size = 10;
                int page = 1;
                int pages = (int)Math.Ceiling((double)list.Count / size);
                int i, k = 0;
                string choose, price;
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("================================================================================================================================");
                    Console.WriteLine($"|                                            Search results with keyword {search,-53} |");
                    Console.WriteLine($"| Found about {list.Count} books                                                                                                  Page {page}/{pages} |");
                    Console.WriteLine("================================================================================================================================");
                    Console.WriteLine("| Book id   | Book title                                                            | Price           | Type                   |");
                    if (list.Count < size)
                    {
                        for (i = 0; i < list.Count; i++)
                        {
                            price = Utility.FormatCurrency(list[i].bookPrice.ToString());
                            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------");
                            Console.WriteLine($"| {list[i].bookId,-9} | {list[i].bookName,-69} | {price,-15} | {list[i].bookCategory!.categoryName,-22} |");
                        }
                    }
                    else
                    {
                        for (i = ((page - 1)) * size; i < k + 10; i++)
                        {
                            if (i == list.Count) break;
                            price = Utility.FormatCurrency(list[i].bookPrice.ToString());
                            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------");
                            Console.WriteLine($"| {list[i].bookId,-9} | {list[i].bookName,-69} | {price,-15} | {list[i].bookCategory!.categoryName,-22} |");
                        }
                    }
                    Console.WriteLine("================================================================================================================================");
                    Console.WriteLine("Enter P to view the previous page.");
                    Console.WriteLine("Enter N to view the next page.");
                    Console.WriteLine("Enter book id to view book details.");
                    Console.WriteLine("Enter 0 to go back.");
                    Console.WriteLine("-----------------------------------------------------------------");
                    Console.Write("Choose: ");
                    choose = Console.ReadLine() ?? "";
                    while (true)
                    {
                        if (Regex.Match(choose, @"([PpNn]|[1-9]|^0$)").Success)
                        {
                            break;
                        }
                        else
                        {
                            Console.Write("Invalid selection! re-select: ");
                            choose = Console.ReadLine() ?? "";
                        }
                    }
                    choose = choose.Trim();
                    choose = choose.ToLower();
                    string number = Regex.Match(choose, @"\d+").Value;
                    if (choose == "n")
                    {
                        if (page == pages)
                        {
                            Utility.WaitForKey("No next page! Enter any key to continue...");
                        }
                        else
                        {
                            page = page + 1;
                            k = k + 10;
                        }
                    }
                    else if (choose == "p")
                    {
                        if (page == 1)
                        {
                            Utility.WaitForKey("No previous page! Enter any key to continue...");
                        }
                        else
                        {
                            page = page - 1;
                            k = k - 10;
                        }
                    }
                    else if (choose == "0")
                    {
                        return;
                    }
                    else
                    {
                        bool found = false;
                        string search1 = '"' + choose + '"';
                        for (i = ((page - 1)) * size; i < k + 10; i++)
                        {
                            try
                            {
                                if (int.Parse(choose) == list[i].bookId)
                                {
                                    Book book = bookBl.GetBookById(list[i].bookId);
                                    ShowBookDetail(book, search1);
                                    Utility.WaitForKey("Enter any key to continue...");
                                    found = true;
                                    break;
                                }
                            }
                            catch (System.FormatException) { }
                            catch (System.ArgumentOutOfRangeException) { }
                        }
                        if (!found)
                        {
                            Console.WriteLine("Invalid book id!");
                            Utility.WaitForKey("Enter any key to continue...");
                        }
                    }
                }
            }
        }

        public static void ShowListOfAllBooks()
        {
            list = bookBl.GetAllBooks();
            if (list.Count == 0)
            {
                Console.WriteLine("No books!");
            }
            else
            {
                int size = 10;
                int page = 1;
                int pages = (int)Math.Ceiling((double)list.Count / size);
                int i, k = 0;
                string choose, price;
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("================================================================================================================================");
                    Console.WriteLine("|                                                          All books                                                           |");
                    Console.WriteLine($"|                                                                                                                     Page {page}/{pages} |");
                    Console.WriteLine("================================================================================================================================");
                    Console.WriteLine("| Book id   | Book title                                                            | Price           | Type                   |");
                    if (list.Count < size)
                    {
                        for (i = 0; i < list.Count; i++)
                        {
                            price = Utility.FormatCurrency(list[i].bookPrice.ToString());
                            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------");
                            Console.WriteLine($"| {list[i].bookId,-9} | {list[i].bookName,-69} | {price,-15} | {list[i].bookCategory!.categoryName,-22} |");
                        }
                    }
                    else
                    {
                        for (i = ((page - 1)) * size; i < k + 10; i++)
                        {
                            if (i == list.Count) break;
                            price = Utility.FormatCurrency(list[i].bookPrice.ToString());
                            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------");
                            Console.WriteLine($"| {list[i].bookId,-9} | {list[i].bookName,-69} | {price,-15} | {list[i].bookCategory!.categoryName,-22} |");
                        }
                    }
                    Console.WriteLine("================================================================================================================================");
                    Console.WriteLine("Enter P to view the previous page.");
                    Console.WriteLine("Enter N to view the next page.");
                    Console.WriteLine("Enter book id to view book details.");
                    Console.WriteLine("Enter 0 to go back.");
                    Console.WriteLine("-----------------------------------------------------------------");
                    Console.Write("Choose: ");
                    choose = Console.ReadLine() ?? "";
                    while (true)
                    {
                        if (Regex.Match(choose, @"([PpNn]|[1-9]|^0$)").Success)
                        {
                            break;
                        }
                        else
                        {
                            Console.Write("Invalid selection! re-select: ");
                            choose = Console.ReadLine() ?? "";
                        }
                    }
                    choose = choose.Trim();
                    choose = choose.ToLower();
                    string number = Regex.Match(choose, @"\d+").Value;
                    if (choose == "n")
                    {
                        if (page == pages)
                        {
                            Utility.WaitForKey("No next page! Enter any key to continue...");
                        }
                        else
                        {
                            page = page + 1;
                            k = k + 10;
                        }
                    }
                    else if (choose == "p")
                    {
                        if (page == 1)
                        {
                            Utility.WaitForKey("No previous page! Enter any key to continue...");
                        }
                        else
                        {
                            page = page - 1;
                            k = k - 10;
                        }
                    }
                    else if (choose == "0")
                    {
                        return;
                    }
                    else
                    {
                        bool found = false;
                        string search1 = '"' + choose + '"';
                        for (i = ((page - 1)) * size; i < k + 10; i++)
                        {
                            try
                            {
                                if (int.Parse(choose) == list[i].bookId)
                                {
                                    Book book = bookBl.GetBookById(list[i].bookId);
                                    ShowBookDetail(book, search1);
                                    Utility.WaitForKey("Enter any key to continue...");
                                    found = true;
                                    break;
                                }
                            }
                            catch (System.FormatException) { }
                            catch (System.ArgumentOutOfRangeException) { }
                        }
                        if (!found)
                        {
                            Console.WriteLine("Invalid book id!");
                            Utility.WaitForKey("Enter any key to continue...");
                        }
                    }
                }
            }
        }


        public static void ShowBookDetail(Book book, string search)
        {
            Console.Clear();
            string price = Utility.FormatCurrency(book.bookPrice.ToString());
            Console.WriteLine("===============================================================================================");
            Console.WriteLine($"|                                    Book details with id is {search,-30}   |");
            Console.WriteLine("===============================================================================================");
            Console.WriteLine($"| Book id:           | {book.bookId,-70} |");
            Console.WriteLine("-----------------------------------------------------------------------------------------------");
            Console.WriteLine($"| Book title:        | {book.bookName,-70} |");
            Console.WriteLine("-----------------------------------------------------------------------------------------------");
            Console.WriteLine($"| Author name:       | {book.authorName,-70} |");
            Console.WriteLine("-----------------------------------------------------------------------------------------------");
            Console.WriteLine($"| Price:             | {price,-70} |");
            Console.WriteLine("-----------------------------------------------------------------------------------------------");
            Console.WriteLine($"| Type:              | {book.bookCategory!.categoryName,-70} |");
            Console.WriteLine("-----------------------------------------------------------------------------------------------");
            Console.WriteLine($"| Quantity:          | {book.bookQuantity,-70} |");
            Console.WriteLine("-----------------------------------------------------------------------------------------------");
            Console.Write("| Description:       |");
            string str = ' ' + book.bookDescription;
            string subStr;
            int i = 65;
            try
            {
                while (str.Length > 0 && i < str.Length)
                {
                    i = 65;
                    while (str[i] != ' ')
                    {
                        i = i + 1;
                        if (i >= str.Length)
                        {
                            break;
                        }
                    }
                    subStr = str.Substring(1, i);
                    Console.WriteLine($" {subStr,-70} |");
                    Console.Write("|                    |");
                    str = str.Remove(0, i);
                }
            }
            catch (System.ArgumentOutOfRangeException) { }
            finally
            {
                Console.WriteLine($" {str.Remove(0, 1),-70} |");
                Console.WriteLine("===============================================================================================");
            }
        }
    }
}