using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBusiness.Sales
{
    public class SalesM
    {
        public static void SalesAdd()
        {
            Console.WriteLine("Welcome to Bhavna CMC Employee section");
        one:
            Sales sl = new Sales();//class call object creation
                                   //taking inputs
            Console.WriteLine("Enter Product name : ");
            sl.name = Console.ReadLine();
            Console.WriteLine("Enter  Franchise Location : ");
            sl.location = Console.ReadLine();
            Console.WriteLine("Enter Pizza Price :");
            sl.price = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Order type : ");
            sl.OrderType = Console.ReadLine();
;



            SqlConnection con = new SqlConnection("server=BHAVNAWKS851;database=PizzaBusiness;integrated security=true");//SQL Connection
            SqlCommand cmd = new SqlCommand("insert into Sales values('" + sl.name + "', " + sl.location + "," + sl.price + ",'" + sl.OrderType + "')", con);//sql insertion command
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
        public static void SalesDisplay()
        {
        two:
            Console.WriteLine("Enter the Product ID to see the details");
            Sales sl = new Sales();
            sl.id = int.Parse(Console.ReadLine());

            SqlConnection con = new SqlConnection("server=BHAVNAWKS851;database=PizzaBusiness;integrated security=true");
            SqlDataAdapter da = new SqlDataAdapter("select * from Menu ", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "OwnerDetails");
            int b = ds.Tables[0].Rows.Count;
            string c = ds.Tables[0].Rows[0][1].ToString();
            Console.WriteLine("Total Number of records : " + b);
            for (int k = 0; k < b; k++)
            {
                if (sl.id.ToString() == ds.Tables[0].Rows[k][0].ToString())
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
        public static void SalesDelete()
        {
        three:
            Sales sl = new Sales();

            Console.WriteLine("Enter the Product ID to delete the record: ");
            sl.id = int.Parse(Console.ReadLine());
            SqlConnection con = new SqlConnection("server=BHAVNAWKS851;database=PizzaBusiness;integrated security=true");
            SqlCommand cmd = new SqlCommand("delete from Menu where f_owner_id = '" + sl.id + "'", con);
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
