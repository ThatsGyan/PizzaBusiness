using PizzaBusiness.FranchiseOwnerDetails;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBusiness.Menu
{
    public class MenuM
    {
        public static void MenuAdd()
        {
            Console.WriteLine("Welcome to Bhavna CMC Employee section");
        one:
            Menu item = new Menu();//class call object creation
                                                  //taking inputs
            Console.WriteLine("Enter Product name : ");
            item.Name = Console.ReadLine();
            Console.WriteLine("Enter  Product Size in Inches : ");
            item.size = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Price :");
            item.price = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Toppings : ");
            item.toppings = Console.ReadLine();
            Console.WriteLine("Enter estimated Prepration Time : ");
            item.time = Console.ReadLine();



            SqlConnection con = new SqlConnection("server=BHAVNAWKS851;database=PizzaBusiness;integrated security=true");//SQL Connection
            SqlCommand cmd = new SqlCommand("insert into Menu values('" + item.Name + "'," + item.size + ", " + item.price + ",'" + item.toppings + "','" + item.time+"')", con);//sql insertion command
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Console.WriteLine("one Product details added sucessfully");
            Console.WriteLine("Press 1  to add another Product details in the list and press anykey to exit");
            string D = Console.ReadLine();
            if (D == "1")
            {
                Console.Clear();
                Console.WriteLine("Enter Another Details : ");
                goto one;
            }
            else
            {
                Environment.Exit(0);
            }
        }
        public static void MenuDisplay()
        {
        two:
            Console.WriteLine("Enter the Product ID to see the details");
            Menu itm = new Menu();
            itm.MId = int.Parse(Console.ReadLine());

            SqlConnection con = new SqlConnection("server=BHAVNAWKS851;database=PizzaBusiness;integrated security=true");
            SqlDataAdapter da = new SqlDataAdapter("select * from Menu ", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "OwnerDetails");
            int b = ds.Tables[0].Rows.Count;
            string c = ds.Tables[0].Rows[0][1].ToString();
            Console.WriteLine("Total Number of records : " + b);
            for (int k = 0; k < b; k++)
            {
                if (itm.MId.ToString() == ds.Tables[0].Rows[k][0].ToString())
                {
                    Console.WriteLine("Name :" + ds.Tables[0].Rows[k][1].ToString());
                    Console.WriteLine("Size :{0}", ds.Tables[0].Rows[k][2].ToString());
                    Console.WriteLine("Price   :{0}", ds.Tables[0].Rows[k][3].ToString());
                    Console.WriteLine("Toppings :{0}", ds.Tables[0].Rows[k][4].ToString());
                    Console.WriteLine("Prepration Time  :{0}", ds.Tables[0].Rows[k][5].ToString());
                }
            }
            //----------------------------------------------
            Console.WriteLine("press 1 to Display Another record  again and press any key to main menu.");
            string D = Console.ReadLine();
            if (D == "1")
            {
                Console.Clear();
                Console.WriteLine("Enter Another Details : ");
                goto two;
            }
            else
            {
                Environment.Exit(0);
            }


        }
        public static void MenuDelete()
        {
        three:
            Menu itm = new Menu();

            Console.WriteLine("Enter the Product ID to delete the record: ");
            itm.MId = int.Parse(Console.ReadLine());
            SqlConnection con = new SqlConnection("server=BHAVNAWKS851;database=PizzaBusiness;integrated security=true");
            SqlCommand cmd = new SqlCommand("delete from Menu where f_owner_id = '" + itm.MId + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            Console.WriteLine("Record Inserted Sucessfully");
            //--------------------------------------------------------------------------------
            Console.WriteLine("press 1 to Delete Another record  again or press any key to main menu.");
            string D = Console.ReadLine();
            if (D == "1")
            {
                Console.Clear();
                Console.WriteLine("Enter Another Details : ");
                goto three;
            }
            else
            {
                Environment.Exit(0);

            }
        }
    }
}
