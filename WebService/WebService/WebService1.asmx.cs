using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebService
{
    public class WebClient : System.ComponentModel.Component { }
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        SqlConnection myCon = new SqlConnection();
        SqlCommand com;
        DataSet dsL, dsC, dsA;
        SqlDataAdapter daL, daC, daA;
        string message;
        string qry;

        //Change the connection string for running the application on your computer
        //You can copy the full path of the data base by right click on Database1.mdf
        //Paste the full path in the connection string as AttachDbFilename=full_paht;
        string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\andre\Desktop\.NET project\WebService\WebService\App_Data\Database1.mdf;Integrated Security = True; Connect Timeout = 30";
        public static string usernameGlobal = "";
        // modify the connection string with the path of the Database on your computer
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        // returns 0 if the verification failed
        // 1 if login successful and User is Client
        // 2 if login successful and User is Chef
        // -1 if wrong password
        // -2 if user does not exist
        public int verifyLogin(string username, string password)
        {
            int response = 0;
            myCon.ConnectionString = connectionString;
            myCon.Open();

            dsL = new DataSet();
            daL = new SqlDataAdapter(@"SELECT COUNT(*) FROM Login WHERE username ='" + username + "'", myCon);
            daL.Fill(dsL, "Login");
            DataRow dr = dsL.Tables["Login"].Rows[0];
            int noU = int.Parse(dr.ItemArray.GetValue(0).ToString());
            if (noU != 0)
            {
                dsL = new DataSet();
                daL = new SqlDataAdapter(@"SELECT password, id_login FROM Login WHERE username ='" + username + "'", myCon);
                daL.Fill(dsL, "Login");
                dr = dsL.Tables["Login"].Rows[0];
                string passwordDatabase = dr.ItemArray.GetValue(0).ToString();
                if (passwordDatabase != password)
                    response = -1;
                else
                {
                    int id = int.Parse(dr.ItemArray.GetValue(1).ToString());
                    dsC = new DataSet();
                    daC = new SqlDataAdapter(@"SELECT Count(*) FROM Clients WHERE id_login ='" + id + "'", myCon);
                    daC.Fill(dsC, "Clients");
                    dr = dsC.Tables["Clients"].Rows[0];
                    noU = int.Parse(dr.ItemArray.GetValue(0).ToString());
                    if (noU != 0)
                        response = 1; // a client logged in
                    else
                        response = 2; // a chef logged in
                }
            }
            else
                response = -2;
            myCon.Close();
            Console.WriteLine(response);
            return response;
        }
        [WebMethod]
        public int insertLogin(string username, string password)
        {
            int id = -1;
            myCon.ConnectionString = connectionString;
            myCon.Open();

            dsL = new DataSet();
            daL = new SqlDataAdapter(@"SELECT COUNT(id_login) FROM Login WHERE username ='" + username + "'", myCon);
            daL.Fill(dsL, "Login");
            DataRow dr = dsL.Tables["Login"].Rows[0];
            if (int.Parse(dr.ItemArray.GetValue(0).ToString()) == 0)
            {
                com = new SqlCommand();
                com.Connection = myCon;
                qry = "INSERT INTO Login VALUES('" + username + "','" + password + "')";
                com.CommandText = qry;
                com.ExecuteNonQuery();

                dsL = new DataSet();
                daL = new SqlDataAdapter(@"SELECT id_login FROM Login WHERE username ='" + username + "'", myCon);
                daL.Fill(dsL, "Login");
                dr = dsL.Tables["Login"].Rows[0];
                id = int.Parse(dr.ItemArray.GetValue(0).ToString());
            }
            myCon.Close();
            return id;
        }
        [WebMethod]
        public string insertClient(string username, string password, string name, string surname, string address, string birthday, string other_details)
        {
            message = "";
            int id_login; //autogenerated by the next function
            id_login = insertLogin(username, password);
            if (id_login == -1) // username exists
            {
                message += "Username taken!";
            }
            else
            {
                myCon.ConnectionString = connectionString;
                myCon.Open();
                qry = "INSERT INTO Clients VALUES ('" + name + "', '" + surname + "', '" + address + "', '" + birthday + "', '" + other_details + "', " + id_login + ")";
                com.CommandText = qry;
                com.ExecuteNonQuery();
                message += "Client added successfully!";
                myCon.Close();
            }
            return message;
        }
        [WebMethod]
        public string insertChef(string username, string password, string name, string surname, string birthday, int id_loc, string other_details)
        {
            message = "";
            int id_login; //autogenerated by the next function
            id_login = insertLogin(username, password);
            if (id_login == -1) // username exists
            {
                message += "Username taken!";
            }
            else
            {
                myCon.ConnectionString = connectionString;
                myCon.Open();
                qry = "INSERT INTO Chefs VALUES ('" + name + "', '" + surname + "', '" + birthday + "', " + id_loc + ", '" + other_details + "', " + id_login + ")";
                com.CommandText = qry;
                com.ExecuteNonQuery();
                message += "Chef added successfully!";
                myCon.Close();
            }
            return message;
        }

        [WebMethod]
        public List<Chef> getChefs()
        {
            message = "";
            myCon.ConnectionString = connectionString;
            myCon.Open();
            dsC = new DataSet();
            daC = new SqlDataAdapter(@"SELECT id_chef, name, surname, id_loc FROM Chefs", myCon);
            daC.Fill(dsC, "Chefs");
            List<Chef> chefs = new List<Chef>();
            foreach (DataRow ds in dsC.Tables["Chefs"].Rows)
            {
                string location;
                dsL = new DataSet();
                daL = new SqlDataAdapter(@"SELECT address FROM Locations WHERE id_loc = " + int.Parse(ds.ItemArray.GetValue(3).ToString()), myCon);
                daL.Fill(dsL, "Locations");
                DataRow dr = dsL.Tables["Locations"].Rows[0];
                location = dr.ItemArray.GetValue(0).ToString();

                List<string> awards = new List<string>();
                dsA = new DataSet();
                daA = new SqlDataAdapter(@"SELECT name FROM Award WHERE id_chef = " + int.Parse(ds.ItemArray.GetValue(0).ToString()), myCon);
                daA.Fill(dsA, "Awards");
                foreach (DataRow ds2 in dsA.Tables["Awards"].Rows)
                {
                    awards.Add(ds2.ItemArray.GetValue(1).ToString());
                }

                string name = ds.ItemArray.GetValue(1).ToString();
                string surname = ds.ItemArray.GetValue(2).ToString();
                chefs.Add(new Chef(name, surname, location, awards));
            }

            dsL = new DataSet();
            daL = new SqlDataAdapter(@"SELECT id_chef, name, surname, id_location FROM Chefs", myCon);
            daC.Fill(dsC, "Chefs");

            myCon.Close();
            return chefs;
        }

        [WebMethod]
        public string updatePassword(string username, string password)
        {
            message = "";
            myCon.ConnectionString = connectionString;
            myCon.Open();
            com = new SqlCommand();
            com.Connection = myCon;
            com.CommandText = "UPDATE Login SET password = '" + password + "' WHERE username = '" + username + "'";
            com.ExecuteNonQuery();
            message += "Password Updated!";

            myCon.Close();
            return message;
        }
        [WebMethod]
        public string updateNameClient(string username, string name)
        {
            message = "";
            myCon.Open();
            com.Connection = myCon;
            com.CommandText = "UPDATE Clients SET name = '" + name + "' WHERE id_login = (SELECT id_login FROM Login WHERE username = '" + username + "')";
            com.ExecuteNonQuery();
            message += "Name updated!";

            myCon.Close();
            return message;
        }
        [WebMethod]
        public string updateNameChef(string username, string name)
        {
            message = "";
            myCon.Open();
            com.Connection = myCon;
            com.CommandText = "UPDATE Chefs SET name = '" + name + "' WHERE id_login = (SELECT id_login FROM Login WHERE username = '" + username + "')";
            com.ExecuteNonQuery();
            message += "Name updated!";

            myCon.Close();
            return message;
        }
        [WebMethod]
        public string updateDetailsClient(string username, string details)
        {
            message = "";
            myCon.ConnectionString = connectionString;
            myCon.Open();
            com = new SqlCommand();
            com.Connection = myCon;
            com.CommandText = "UPDATE Clients SET other_details = '" + details + "' WHERE id_login = (SELECT id_login FROM Login WHERE username = '" + username + "')";
            com.ExecuteNonQuery();
            message += "Details updated!";

            myCon.Close();
            return message;
        }

        [WebMethod]
        public string updateStuffClient(string username, string name, string surname, string address, string birthday)
        {
            message = "";
            myCon.ConnectionString = connectionString;
            myCon.Open();
            com = new SqlCommand();
            com.Connection = myCon;
            com.CommandText = "UPDATE Clients SET name = '" + name + "', surname = '" + surname + "'" +
                ", address = '" + address + "', birthday = '" + birthday + "' WHERE id_login = (SELECT id_login FROM Login WHERE username = '" + username + "')";
            com.ExecuteNonQuery();
            message += "Updated!";
            myCon.Close();
            return message;
        }

        [WebMethod]
        public string updateDetailsChefs(string username, string details)
        {
            message = "";
            myCon.Open();
            com.Connection = myCon;
            com.CommandText = "UPDATE Clients SET details = '" + details + "' WHERE id_login = (SELECT id_login FROM Login WHERE username = '" + username + "')";
            com.ExecuteNonQuery();
            message += "Details updated!";

            myCon.Close();
            return message;
        }
        [WebMethod]
        public List<int> getAppointmentsClient(string username)
        {
            myCon.ConnectionString = connectionString;
            myCon.Open();
            List<int> appointments = new List<int>();
            dsA = new DataSet();
            daA = new SqlDataAdapter(@"SELECT id FROM Appointments WHERE id_client = (SELECT id_client from Clients WHERE id_login = "
                + "(SELECT id_login FROM Login Where username = '" + username + "'))", myCon);
            daA.Fill(dsA, "Appointments");
            foreach (DataRow ds in dsA.Tables["Appointments"].Rows)
            {
                appointments.Add(int.Parse(ds.ItemArray.GetValue(0).ToString()));
            }

            myCon.Close();
            return appointments;
        }

        [WebMethod]
        public List<string> getDetailsOfAppointment(int id)
        {
            myCon.ConnectionString = connectionString;
            myCon.Open();
            List<string> details = new List<string>();
            dsA = new DataSet();
            daA = new SqlDataAdapter(@"SELECT id_loc, id_chef, date, hour FROM Appointments WHERE id = " + id, myCon);
            daA.Fill(dsA, "Appointments");
            DataRow dr = dsA.Tables["Appointments"].Rows[0];

            dsL = new DataSet();
            daL = new SqlDataAdapter("SELECT address from Locations WHERE id_loc = " + int.Parse(dr.ItemArray.GetValue(0).ToString()), myCon);
            daL.Fill(dsL, "Locations");
            DataRow dr2 = dsL.Tables["Locations"].Rows[0];
            details.Add(dr2.ItemArray.GetValue(0).ToString()); // address of the location

            dsC = new DataSet();
            daC = new SqlDataAdapter("SELECT name, surname from Chefs WHERE id_chef = " + int.Parse(dr.ItemArray.GetValue(1).ToString()), myCon);
            daC.Fill(dsL, "Chefs");
            dr2 = dsL.Tables["Chefs"].Rows[0];

            details.Add(dr2.ItemArray.GetValue(0).ToString()); //name of the reserved chef
            details.Add(dr2.ItemArray.GetValue(1).ToString()); //surname of the reserved chef

            details.Add(dr.ItemArray.GetValue(2).ToString()); // date of the appointment
            details.Add(dr.ItemArray.GetValue(3).ToString()); // hour of the appointment

            myCon.Close();
            return details;
        }
        [WebMethod]
        public List<string> getClientDetails(string username)
        {
            List<string> details = new List<string>();
            myCon.ConnectionString = connectionString;
            myCon.Open();
            dsC = new DataSet();
            daC = new SqlDataAdapter(@"SELECT name, surname, address, birthday, other_details FROM Clients " +
                "WHERE id_login = (SELECT id_login FROM Login WHERE username = '" + username + "')", myCon);
            daC.Fill(dsC, "Clients");

            DataRow dr = dsC.Tables["Clients"].Rows[0];
            for (int i = 0; i < dr.ItemArray.Length; i++)
                details.Add(dr.ItemArray.GetValue(i).ToString());

            myCon.Close();
            return details;
        }
        [WebMethod]
        public List<string> verifyAppointment(string location, string date, int hour)
        {
            List<string> availableChefs = new List<string>();

            myCon.ConnectionString = connectionString;
            myCon.Open();
            dsL = new DataSet();
            daL = new SqlDataAdapter(@"Select id_loc from Locations where address='" + location + "'", myCon);
            daL.Fill(dsL, "Locations");
            DataRow dr3 = dsL.Tables["Locations"].Rows[0];
            int id_loc = int.Parse(dr3.ItemArray.GetValue(0).ToString());
            dsA = new DataSet();
            daA = new SqlDataAdapter(@"SELECT COUNT(*) FROM Chefs WHERE id_chef NOT IN " +
                "(SELECT id_chef FROM Appointments WHERE hour = " + hour + " AND date = '" + date + "' AND id_loc = " +
                "(SELECT id_loc FROM Locations WHERE address = '" + location + "')) AND id_loc=" + id_loc + "", myCon);
            daA.Fill(dsA, "Chefs");
            DataRow dr = dsA.Tables["Chefs"].Rows[0];
            if (int.Parse(dr.ItemArray.GetValue(0).ToString()) == 0)
                availableChefs = null;
            else {
                dsA = new DataSet();
                daA = new SqlDataAdapter(@"SELECT name, surname FROM Chefs WHERE id_chef NOT IN " +
                    "(SELECT id_chef FROM Appointments WHERE hour = " + hour + " AND date = '" + date + "' AND id_loc = " +
                    "(SELECT id_loc FROM Locations WHERE address = '" + location + "')) AND id_loc=" + id_loc + "", myCon);
                daA.Fill(dsA, "Chefs");
                foreach (DataRow dr2 in dsA.Tables["Chefs"].Rows)
                    availableChefs.Add(dr2.ItemArray.GetValue(0) + " " + dr2.ItemArray.GetValue(1));
            }
            myCon.Close();
            return availableChefs;
        }
        [WebMethod]
        public int createAppointment(string username, string location, string date, int hour, string name, string surname)
        {
            int created = 0;
            myCon.ConnectionString = connectionString;
            myCon.Open();
            com = new SqlCommand();
            com.Connection = myCon;
            //string[] name = nameChef.Split(' '); // split choosen chef's name into name and surname for finding id_chef

            dsC = new DataSet();
            daC = new SqlDataAdapter("Select id_chef from Chefs  WHERE name = '" + name + "' AND surname='" +
                surname + "'", myCon);
            daC.Fill(dsC, "Chefs");
            DataRow dr = dsC.Tables["Chefs"].Rows[0];
            int id_chef = int.Parse(dr.ItemArray.GetValue(0).ToString());

            dsC = new DataSet();
            daC = new SqlDataAdapter("Select id_client from Clients WHERE id_login = " +
                "(SELECT id_login from Login where username = '" + username + "')", myCon);
            daC.Fill(dsC, "Clients");
            dr = dsC.Tables["Clients"].Rows[0];
            int id_client = int.Parse(dr.ItemArray.GetValue(0).ToString());

            dsL = new DataSet();
            daL = new SqlDataAdapter("Select id_loc from Locations WHERE address = '" + location + "'", myCon);
            daL.Fill(dsC, "Locations");
            dr = dsC.Tables["Locations"].Rows[0];
            int id_loc = int.Parse(dr.ItemArray.GetValue(0).ToString());

            com.CommandText = "INSERT INTO Appointments Values(" + id_client + ", " +
                id_loc + ", " + id_chef + ", '" + date + "', " + hour + ")";
            com.ExecuteNonQuery();
            created = 1;
            myCon.Close();

            return created;
        }
        [WebMethod]
        public int deleteAppointment(string username, string location, string date, int hour, string nameChef, string surnameChef)
        {
            int deleted = 0;
            myCon.ConnectionString = connectionString;
            myCon.Open();
            com = new SqlCommand();
            com.Connection = myCon;
            //string[] name = nameChef.Split(' '); // split choosen chef's name into name and surname for finding id_chef

            dsC = new DataSet();
            daC = new SqlDataAdapter("Select id_chef from Chefs WHERE name = '" + nameChef + "' AND surname='" +
                surnameChef + "'", myCon);
            daC.Fill(dsC, "Chefs");
            DataRow dr = dsC.Tables["Chefs"].Rows[0];
            int id_chef = int.Parse(dr.ItemArray.GetValue(0).ToString());

            dsC = new DataSet();
            daC = new SqlDataAdapter("Select id_client from Clients WHERE id_login = " +
                "(SELECT id_login from Login where username = '" + username + "')", myCon);
            daC.Fill(dsC, "Clients");
            dr = dsC.Tables["Clients"].Rows[0];
            int id_client = int.Parse(dr.ItemArray.GetValue(0).ToString());

            dsL = new DataSet();
            daL = new SqlDataAdapter("Select id_loc from Locations WHERE address = '" + location + "'", myCon);
            daL.Fill(dsC, "Locations");
            dr = dsC.Tables["Locations"].Rows[0];
            int id_loc = int.Parse(dr.ItemArray.GetValue(0).ToString());

            com.CommandText = "DELETE From Appointments WHERE id_client = " + id_client + " AND id_loc=" +
                id_loc + " AND id_chef=" + id_chef + " AND date='" + date + "' AND hour=" + hour + ";";
            

            com.ExecuteNonQuery();
            deleted = 1;
            myCon.Close();

            return deleted;
        }

        [WebMethod]
        public string getUsername()
        {
            return usernameGlobal;
        }

        [WebMethod]
        public void setUsername(string username)
        {
            usernameGlobal = username;
        }

        [WebMethod]
        public string getPassword(string username)
        {
            myCon.ConnectionString = connectionString;
            myCon.Open();



            dsL = new DataSet();
            daL = new SqlDataAdapter(@"SELECT password FROM Login WHERE username ='" + username + "'", myCon);
            daL.Fill(dsL, "Login");
            DataRow dr = dsL.Tables["Login"].Rows[0];
            string password = dr.ItemArray.GetValue(0).ToString();



            myCon.Close();
            return password;
        }

        [WebMethod]
        public int deleteAccount(string username)
        {
            int response = 0;
            myCon.ConnectionString = connectionString;
            myCon.Open();
            com = new SqlCommand();
            com.Connection = myCon;



            // verify if the user is a client or a chef (in which table does the id_login find itself?)
            dsC = new DataSet();
            daC = new SqlDataAdapter(@"SELECT Count(*) FROM Clients WHERE id_login =" +
                "(SELECT id_login from Login where username = '" + username + "')", myCon);
            daC.Fill(dsC, "Clients");
            DataRow dr = dsL.Tables["Login"].Rows[0];
            int userType = int.Parse(dr.ItemArray.GetValue(0).ToString());
            if (userType == 1) // you are a client and you wanna delete yourself
            {
                com.CommandText = "DELETE * FROM Clients WHERE id_login = " +
                "(SELECT id_login from Login where username = '" + username + "')";
                response = 1;
                // deleted a client
            }
            else // you are a chef and you wanna delete yourself
            {
                com.CommandText = "DELETE * FROM Chefs WHERE id_login = " +
                "(SELECT id_login from Login where username = '" + username + "')";
                response = 2; // deleted a chef
            }
            com.ExecuteNonQuery();



            //after deleting the entry from the Chefs/ Clients, delete the entry from Login
            com.CommandText = "DELETE * From Login where username = '" + username + "'";
            com.ExecuteNonQuery();



            myCon.Close();
            return response;
        }

        [WebMethod]
        public List<string> getAllLocations()
        {
            List<string> listOfLocations = new List<string>();
            myCon.ConnectionString = connectionString;
            myCon.Open();
            dsL = new DataSet();
            daL = new SqlDataAdapter(@"SELECT address FROM Locations", myCon);
            daL.Fill(dsL, "Locations");
            foreach (DataRow dr in dsL.Tables["Locations"].Rows)
            {
                listOfLocations.Add(dr.ItemArray.GetValue(0).ToString());
            }
            
            myCon.Close();
            return listOfLocations;
        }

        [WebMethod]
        public List<string> getChefDetails(string username)
        {
            List<string> list = new List<string>();



            myCon.ConnectionString = connectionString;
            myCon.Open();
            dsC = new DataSet();
            daC = new SqlDataAdapter(@"SELECT id_chef, name, surname,birthday, other_details, id_loc FROM Chefs where id_login = " +
                "(SELECT id_login from Login WHERE username = '" + username + "')", myCon);
            daC.Fill(dsC, "Chefs");
            DataRow dr = dsC.Tables["Chefs"].Rows[0];
            list.Add(dr.ItemArray.GetValue(1).ToString()); // name on 0 in list
            list.Add(dr.ItemArray.GetValue(2).ToString()); // surname on 1 in list
            list.Add(dr.ItemArray.GetValue(3).ToString()); // birthday on 2 in list
            list.Add(dr.ItemArray.GetValue(4).ToString()); // other_details on 3 in list



            dsL = new DataSet();
            daL = new SqlDataAdapter(@"SELECT address, type_of_cuisine FROM Locations where id_loc = " + int.Parse(dr.ItemArray.GetValue(5).ToString()), myCon);
            daL.Fill(dsL, "Locations");
            DataRow dr2 = dsL.Tables["Locations"].Rows[0];
            list.Add(dr2.ItemArray.GetValue(0).ToString()); // location on 4 in list
            list.Add(dr2.ItemArray.GetValue(1).ToString()); // type of cuisine on 5 in list




            dsA = new DataSet();
            daA = new SqlDataAdapter(@"SELECT Count(*) from Awards where id_chef = " + int.Parse(dr.ItemArray.GetValue(0).ToString()), myCon);
            daA.Fill(dsA, "Awards");
            DataRow dr4 = dsA.Tables["Awards"].Rows[0];
            int numberOfAwards = int.Parse(dr4.ItemArray.GetValue(0).ToString());
            if (numberOfAwards == 0)
                list.Add("No awards yet.");
            else
            {
                dsA = new DataSet();
                daA = new SqlDataAdapter(@"SELECT name from Awards where id_chef = " + int.Parse(dr.ItemArray.GetValue(0).ToString()), myCon);
                daA.Fill(dsA, "Awards");
                foreach (DataRow dr3 in dsA.Tables["Awards"].Rows)
                    list.Add(dr3.ItemArray.GetValue(0).ToString()); // from position 6 until the end, the list will contain the name of the awards of the chef
            }
            myCon.Close();



            return list;
        }

        [WebMethod]
        public string updateStuffChefs(string username, string name, string surname, string birthday)
        {
            message = "";
            myCon.ConnectionString = connectionString;
            myCon.Open();
            com = new SqlCommand();
            com.Connection = myCon;
            com.CommandText = "UPDATE Chefs SET name = '" + name + "', surname = '" + surname + "'" +
                ", birthday = '" + birthday + "' WHERE id_login = (SELECT id_login FROM Login WHERE username = '" + username + "')";
            com.ExecuteNonQuery();
            message += "Updated!";



            myCon.Close();
            return message;
        }

        [WebMethod]
        public List<int> getIDsOfAppointmentsChef(string username)
        {
            List<int> list = new List<int>();
            myCon.ConnectionString = connectionString;
            myCon.Open();
            
            dsA = new DataSet();
            daA = new SqlDataAdapter(@"SELECT COUNT(*) from Appointments where id_chef = " +
                "(SELECT id_chef FROM Chefs WHERE id_login = (SELECT id_login from Login WHERE username = '" + username + "'))", myCon);
            daA.Fill(dsA, "Appointments");
            DataRow dr = dsA.Tables["Appointments"].Rows[0];
            int numberOfAppointments = int.Parse(dr.ItemArray.GetValue(0).ToString());
            if (numberOfAppointments == 0)
                list.Add(-1); // daca lista de id-uri returnata contine doar -1 pe prima pozitie => nu exista rezervari pt. seful respectiv.
            else
            {
                dsA = new DataSet();
                daA = new SqlDataAdapter(@"SELECT id from Appointments where id_chef = " +
                    "(SELECT id_chef FROM Chefs WHERE id_login = (SELECT id_login from Login WHERE username = '" + username + "'))", myCon);
                daA.Fill(dsA, "Appointments");
                foreach (DataRow rd1 in dsA.Tables["Appointments"].Rows)
                    list.Add(int.Parse(rd1.ItemArray.GetValue(0).ToString()));
            }



            myCon.Close();
            return list;
        }



        [WebMethod]
        public List<string> getAppDetailsChef(int id_appointment)
        {
            List<string> list = new List<string>();

            myCon.ConnectionString = connectionString;
            myCon.Open();
            
            dsA = new DataSet();
            daA = new SqlDataAdapter(@"SELECT id_loc, id_client, date, hour from Appointments where id= " + id_appointment, myCon);
            daA.Fill(dsA, "Appointments");
            DataRow dr = dsA.Tables["Appointments"].Rows[0];
            int id_loc = int.Parse(dr.ItemArray.GetValue(0).ToString());
            int id_client = int.Parse(dr.ItemArray.GetValue(1).ToString());
           
            dsL = new DataSet();
            daL = new SqlDataAdapter(@"SELECT address from Locations where id_loc= " + id_loc, myCon);
            daL.Fill(dsL, "Locations");
            DataRow dr2 = dsL.Tables["Locations"].Rows[0];
            
            dsC = new DataSet();
            daC = new SqlDataAdapter(@"SELECT name, surname from Clients where id_client= " + id_client, myCon);
            daC.Fill(dsC, "Clients");
            DataRow dr3 = dsC.Tables["Clients"].Rows[0];

            list.Add(dr2.ItemArray.GetValue(0).ToString()); // location at 0
            list.Add(dr3.ItemArray.GetValue(0).ToString()); // name client at 0
            list.Add(dr3.ItemArray.GetValue(1).ToString()); // surname client at 0
            list.Add(dr.ItemArray.GetValue(2).ToString()); // date at 0
            list.Add(dr.ItemArray.GetValue(3).ToString()); // hour at 0

            myCon.Close();
            return list;
        }

        [WebMethod]
        public List<string> getAllUsernamesOfChefs()
        {
            List<string> list = new List<string>();
            myCon.ConnectionString = connectionString;
            myCon.Open();
            dsC = new DataSet();
            daC = new SqlDataAdapter(@"SELECT username from Login where id_login IN (SELECT id_login FROM Chefs)", myCon);
            daC.Fill(dsC, "Chefs");
            foreach (DataRow dr in dsC.Tables["Chefs"].Rows)
                list.Add(dr.ItemArray.GetValue(0).ToString());
            myCon.Close();
            return list;
        }
    }

    public class Chef
    {
        List<string> awards;
        string name, surname;
        string location;
        public Chef()
        {
            this.awards = null;
            this.name = null;
            this.surname = null;
            this.location = null;
        }
        public Chef(string name, string surname, string location, List<string> awards)
        {
            this.name = name;
            this.surname = surname;
            this.location = location;
            this.awards = awards;
        }
    }

}