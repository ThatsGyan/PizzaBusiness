using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBusiness.FranchiseOwnerDetails
{
    public class OwnerDetailsM
    {
        public static void OwnerDetailsAdd()
        {
            Console.WriteLine("Welcome to Bhavna CMC Employee section");
        one:
            OwnerDetails own = new OwnerDetails();//class call object creation
                                              //taking inputs
            Console.WriteLine("Enter Franchise Owner name : ");
            own.OwnerName = Console.ReadLine();
            Console.WriteLine("Enter  Location : ");
            own.location = Console.ReadLine();
            Console.WriteLine("Enter Salary :");
            own.salary = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Gender : ");
            own.gender = Console.ReadLine();
            Console.WriteLine("Enter Contact : ");
            own.contact = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Email : ");
            own.email = Console.ReadLine();


            SqlConnection con = new SqlConnection("server=BHAVNAWKS851;database=PizzaBusiness;integrated security=true");//SQL Connection
            SqlCommand cmd = new SqlCommand("insert into OwnerDetails values('" + own.OwnerName + "','" + own.location + "', " + own.salary + ",'" + own.gender + "'," + own.contact + ",'"+own.email+"')", con);//sql insertion command
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Console.WriteLine("one Employee details added sucessfully");
            Console.WriteLine("Press 1  to add another Franchise Owner details in the list and press anykey to exit");
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
        public static void OwnerDetailsDisplay()
        {
        two:
            Console.WriteLine("Enter the Franchise Owner ID to see the details");
            OwnerDetails own = new OwnerDetails();
            own.OwnerId = int.Parse(Console.ReadLine());

            SqlConnection con = new SqlConnection("server=BHAVNAWKS851;database=PizzaBusiness;integrated security=true");
            SqlDataAdapter da = new SqlDataAdapter("select * from OwnerDetails ", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "OwnerDetails");
            int b = ds.Tables[0].Rows.Count;
            string c = ds.Tables[0].Rows[0][1].ToString();
            Console.WriteLine("Total Number of records : " + b);
            for (int k = 0; k < b; k++)
            {
                if (own.OwnerId.ToString() == ds.Tables[0].Rows[k][0].ToString())
                {
                    Console.WriteLine("Name :" + ds.Tables[0].Rows[k][1].ToString());
                    Console.WriteLine("Locaton :{0}", ds.Tables[0].Rows[k][2].ToString());
                    Console.WriteLine("Salary Hours  :{0}", ds.Tables[0].Rows[k][3].ToString());
                    Console.WriteLine("Gender :{0}", ds.Tables[0].Rows[k][4].ToString());
                    Console.WriteLine("Contact  :{0}", ds.Tables[0].Rows[k][5].ToString());
                    Console.WriteLine("Email  :{0}", ds.Tables[0].Rows[k][6].ToString());
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
        public static void OwnerDetailsDelete()
        {
        three:
            OwnerDetails own = new OwnerDetails();

            Console.WriteLine("Enter the Franchise Owner ID to delete the record: ");
            own.OwnerId = int.Parse(Console.ReadLine());
            SqlConnection con = new SqlConnection("server=BHAVNAWKS851;database=PizzaBusiness;integrated security=true");
            SqlCommand cmd = new SqlCommand("delete from OwnerDetails where f_owner_id = '" + own.OwnerId + "'", con);
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
