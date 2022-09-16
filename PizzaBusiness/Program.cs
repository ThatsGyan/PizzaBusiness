using PizzaBusiness.FranchiseOwnerDetails;
using PizzaBusiness.Menu;
using PizzaBusiness.Sales;

namespace PizzaBusiness
{
    internal class Program
    {
        static void Main(string[] args)
        {
        Start:
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("=====================================================================\n");
            Console.WriteLine("\t\tHi Welcome to Bhavna Pizza Pvt. Ltd.");
            Console.WriteLine("\n=====================================================================\n");
            Login:
            //Login
            Console.WriteLine("Press 1 For Login and Press 2 for Exit.");
            string A = Console.ReadLine();
            
            Console.ForegroundColor = ConsoleColor.White;
            string Username = @"admin@123";
            string Password = @"admin@123";
            string FUsername = @"fadmin@123";
            string FPassword = @"fadmin@123";
            
            Console.WriteLine("Please Enter Your Username :");
            string LoginUn = Console.ReadLine();
            Console.WriteLine("Please Enter Your Password:");
            string LoginPW = Console.ReadLine();

            if (LoginUn == Username && LoginPW == Password)
            {
                Start1:
                Console.WriteLine("Press \n1 to enter in Franchise owner data room\n2 for Menu room data\n3 for sales data room  ");
                string B = Console.ReadLine();
                switch (B)
                {
                    
                    case "1":
                        Console.WriteLine("Press\n1 for insert details\n2 for display details\n3 for delete record\n3 for delete record or any key for main menu.");
                        string C = Console.ReadLine();
                        switch (C)
                        {
                            case "1":
                                OwnerDetailsM.OwnerDetailsAdd();
                                break;
                            case "2":
                                OwnerDetailsM.OwnerDetailsDisplay();
                                break;
                            case "3":
                                OwnerDetailsM.OwnerDetailsDelete();
                                break;
                            default:
                                goto Start1;
                                break;
                        }
                        break;
                    case "2":
                        Console.WriteLine("Press\n1 for insert details\n2 for display details\n3 for delete record or any key for main menu.");
                        string D = Console.ReadLine();
                        switch (D)
                        {
                            case "1":
                                MenuM.MenuAdd();
                                break;
                            case "2":
                                MenuM.MenuDisplay();
                                break;
                            case "3":
                                MenuM.MenuDelete();
                                break;
                            default:
                                goto Start1;
                                break;
                        }
                        break;
                    case "3":
                        Console.WriteLine("Press\n1 display details or press any key to go to main menu");
                        string E = Console.ReadLine();
                        switch (E)
                        {
                            case "1":
                                 SalesM.SalesAdd();
                                break;
                            default:
                                goto Start1;
                                break;
                        }
                        break;
                  
                        
                        
 
                    default:
                        break;
                }

            }
            else if (LoginUn == FUsername && LoginPW == FPassword)
            {
                Start2:
                Console.WriteLine("Press \n1 for insert details\n2 for display details\n3 for delete record or press any key to main menu.");
                string F = Console.ReadLine();
                switch (F)
                {
                    case "1":
                        SalesM.SalesAdd();
                        break;
                    case "2":
                        SalesM.SalesDisplay();
                        break;
                    case "3":
                        SalesM.SalesDelete();
                        break;
                    default:
                        goto Start2;
                        break;
                }
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\t\t|||||  Username and Password are incorrect\n\t\tPlease Enter Something Valid |||||\n\n\n");
                goto Login;
            }

        }
    }
}