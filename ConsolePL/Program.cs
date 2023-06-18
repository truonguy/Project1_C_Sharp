using Persistence;
using BL;
using Utilities;

namespace ConsolePL
{
    public class Program
    {
        static StaffBL staffBl = new StaffBL();
        public static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            MainMenu();
        }
        static void MainMenu()
        {
            string[] menu = { "login", "Exit" };
            string name = @"  
        ██████╗  ██████╗  ██████╗ ██╗  ██╗    ███████╗████████╗ ██████╗ ██████╗ ███████╗
        ██╔══██╗██╔═══██╗██╔═══██╗██║ ██╔╝    ██╔════╝╚══██╔══╝██╔═══██╗██╔══██╗██╔════╝
        ██████╔╝██║   ██║██║   ██║█████╔╝     ███████╗   ██║   ██║   ██║██████╔╝█████╗  
        ██╔══██╗██║   ██║██║   ██║██╔═██╗     ╚════██║   ██║   ██║   ██║██╔══██╗██╔══╝  
        ██████╔╝╚██████╔╝╚██████╔╝██║  ██╗    ███████║   ██║   ╚██████╔╝██║  ██║███████╗
        ╚═════╝  ╚═════╝  ╚═════╝ ╚═╝  ╚═╝    ╚══════╝   ╚═╝    ╚═════╝ ╚═╝  ╚═╝╚══════╝";
            int choice;
            while (true)
            {
                choice = Utility.Menu(menu, name);
                switch (choice)
                {
                    case 1:
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine("=========================================================================================================");
                            Console.WriteLine(@"                
            ██████╗  ██████╗  ██████╗ ██╗  ██╗    ███████╗████████╗ ██████╗ ██████╗ ███████╗
            ██╔══██╗██╔═══██╗██╔═══██╗██║ ██╔╝    ██╔════╝╚══██╔══╝██╔═══██╗██╔══██╗██╔════╝
            ██████╔╝██║   ██║██║   ██║█████╔╝     ███████╗   ██║   ██║   ██║██████╔╝█████╗  
            ██╔══██╗██║   ██║██║   ██║██╔═██╗     ╚════██║   ██║   ██║   ██║██╔══██╗██╔══╝  
            ██████╔╝╚██████╔╝╚██████╔╝██║  ██╗    ███████║   ██║   ╚██████╔╝██║  ██║███████╗
            ╚═════╝  ╚═════╝  ╚═════╝ ╚═╝  ╚═╝    ╚══════╝   ╚═╝    ╚═════╝ ╚═╝  ╚═╝╚══════╝  ");
                            Console.WriteLine("|                                                 [Đăng nhập]                                           |");
                            Console.WriteLine("=========================================================================================================");

                            Console.Write("User name: ");
                            string userName = Console.ReadLine() ?? "";
                            Console.Write("Password: ");
                            string password = Utility.GetPassword();
                            Staff staff = staffBl.Login(userName, password);
                            if (staff != null)
                            {
                                if (staff.staffRole == 1)
                                {
                                    MenuSeller(staff);
                                    break;
                                }
                                else if (staff.staffRole == 2)
                                {
                                    MenuAccountant(staff);
                                    break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Login failed, please try again!");
                                Utility.WaitForKey("Enter any key to continue...");
                            }
                        }
                        break;

                    case 2:
                        if (Utility.IsContinue("Do you want to exit? (Y/N): "))
                        {
                            Console.WriteLine("Program exited!");
                            Environment.Exit(0);
                        }
                        break;
                }
            }
        }

        static void MenuSeller(Staff staff)
        {
            string[] menu = { "Search books", "Create a new order", "Log out" };
            string name = @"   
        ██████╗  ██████╗  ██████╗ ██╗  ██╗    ███████╗████████╗ ██████╗ ██████╗ ███████╗
        ██╔══██╗██╔═══██╗██╔═══██╗██║ ██╔╝    ██╔════╝╚══██╔══╝██╔═══██╗██╔══██╗██╔════╝
        ██████╔╝██║   ██║██║   ██║█████╔╝     ███████╗   ██║   ██║   ██║██████╔╝█████╗  
        ██╔══██╗██║   ██║██║   ██║██╔═██╗     ╚════██║   ██║   ██║   ██║██╔══██╗██╔══╝  
        ██████╔╝╚██████╔╝╚██████╔╝██║  ██╗    ███████║   ██║   ╚██████╔╝██║  ██║███████╗
        ╚═════╝  ╚═════╝  ╚═════╝ ╚═╝  ╚═╝    ╚══════╝   ╚═╝    ╚═════╝ ╚═╝  ╚═╝╚══════╝
|                                               [MENU SELLER]                                    |";
            int choice;
            do
            {
                choice = Utility.Menu(menu, name);
                switch (choice)
                {
                    case 1:
                        MenuSearchBook();
                        break;

                    case 2:
                        OrderHandle.CreateOrder(staff);
                        break;

                    case 3:
                        if (Utility.IsContinue("Do you want to log out? (Y/N): "))
                        {
                            Console.WriteLine("Log out successful!");
                            Utility.WaitForKey("Enter any key to continue...");
                        }
                        else
                        {
                            MenuSeller(staff);
                        }
                        break;
                }
            } while (choice != menu.Length);
        }

        static void MenuAccountant(Staff staff)
        {
            string[] menu = { "Payment", "Transaction history", "Log out" };
            string name = @"   
        ██████╗  ██████╗  ██████╗ ██╗  ██╗    ███████╗████████╗ ██████╗ ██████╗ ███████╗
        ██╔══██╗██╔═══██╗██╔═══██╗██║ ██╔╝    ██╔════╝╚══██╔══╝██╔═══██╗██╔══██╗██╔════╝
        ██████╔╝██║   ██║██║   ██║█████╔╝     ███████╗   ██║   ██║   ██║██████╔╝█████╗  
        ██╔══██╗██║   ██║██║   ██║██╔═██╗     ╚════██║   ██║   ██║   ██║██╔══██╗██╔══╝  
        ██████╔╝╚██████╔╝╚██████╔╝██║  ██╗    ███████║   ██║   ╚██████╔╝██║  ██║███████╗
        ╚═════╝  ╚═════╝  ╚═════╝ ╚═╝  ╚═╝    ╚══════╝   ╚═╝    ╚═════╝ ╚═╝  ╚═╝╚══════╝
                                           [MENU ACCOUNTANT]                                           ";
            int choice;
            do
            {
                choice = Utility.Menu(menu, name);
                switch (choice)
                {
                    case 1:
                        OrderHandle.ShowListOfUnpaidOrders();
                        break;

                    case 2:
                        OrderHandle.ShowTransactionHistory();
                        break;

                    case 3:
                        if (Utility.IsContinue("Do you want to log out? (Y/N): "))
                        {
                            Console.WriteLine("Log out successful!");
                            Utility.WaitForKey("Enter any key to continue...");
                        }
                        else
                        {
                            MenuAccountant(staff);
                        }
                        break;
                }
            } while (choice != menu.Length);
        }

        static void MenuSearchBook()
        {
            string[] menu = { "Search books by book title", "Search books by category name", "View all books", "Back" };
            string name = @"   
        ██████╗  ██████╗  ██████╗ ██╗  ██╗    ███████╗████████╗ ██████╗ ██████╗ ███████╗
        ██╔══██╗██╔═══██╗██╔═══██╗██║ ██╔╝    ██╔════╝╚══██╔══╝██╔═══██╗██╔══██╗██╔════╝
        ██████╔╝██║   ██║██║   ██║█████╔╝     ███████╗   ██║   ██║   ██║██████╔╝█████╗  
        ██╔══██╗██║   ██║██║   ██║██╔═██╗     ╚════██║   ██║   ██║   ██║██╔══██╗██╔══╝  
        ██████╔╝╚██████╔╝╚██████╔╝██║  ██╗    ███████║   ██║   ╚██████╔╝██║  ██║███████╗
        ╚═════╝  ╚═════╝  ╚═════╝ ╚═╝  ╚═╝    ╚══════╝   ╚═╝    ╚═════╝ ╚═╝  ╚═╝╚══════╝
                                                 [SEARCH BOOK]                                         ";
            int choice;
            do
            {
                choice = Utility.Menu(menu, name);
                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("=================================================================================");
                        Console.WriteLine("|                          Search books by book title                           |");
                        Console.WriteLine("=================================================================================");
                        Console.WriteLine("Keyword suggestions: \"tiếng anh\", \"tài chính\", \"sức khỏe\", \"giả kim\",...");
                        Console.Write("Enter keywords to search: ");
                        string bookName = Console.ReadLine() ?? "";
                        BookHandle.ShowListOfSearchedBooks(bookName, choice);
                        Utility.WaitForKey("Enter any key to continue...");
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("=================================================================================");
                        Console.WriteLine("|                         Search books by category name                         |");
                        Console.WriteLine("=================================================================================");
                        Console.WriteLine("Keyword suggestions: \"văn học\", \"kinh tế\", \"thiếu nhi\", \"ngoại ngữ\",...");
                        Console.Write("Enter keywords to search: ");
                        string categoryName = Console.ReadLine() ?? "";
                        BookHandle.ShowListOfSearchedBooks(categoryName, choice);
                        Utility.WaitForKey("Enter any key to continue...");
                        break;

                    case 3:
                        BookHandle.ShowListOfAllBooks();
                        Utility.WaitForKey("Enter any key to continue...");
                        break;

                    default:

                        break;
                }
            } while (choice != menu.Length);
        }
    }
}


