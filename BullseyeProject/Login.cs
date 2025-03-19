using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BullseyeProject
{
    public partial class Login : Form
    {
        //User Fields
        public int userID;
        public string FirstName;
        public string LastName;
        public string Email;
        public int siteID;
        public int positionID;
        public string permissionLevel;
        public bool active;
        public List<string> userPermissionID;
        public static User user;
        public Login()
        {
            InitializeComponent();
        }

        //Create dataset connection
        static string connString =
           "server=localhost;database=bullseyedb2022;" +
           "userid=Rodrigo;password=rororo0808";

        MySqlConnection conn = new MySqlConnection(connString);

        ///summary
        ///When the program loads, try to open the connection
        ///return exceptions if catch any errors
        ///summary
        private void Login_Load(object sender, EventArgs e)
        {
            txtUserID.Text = "1003";
            txtPass.Text = "1003";

        }

        ///summary
        ///Call checkuser, if user is valid then call user status to set the user fields
        ///Open Home page if any mistake is found
        ///summary

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (CheckUser())
            {
                if (UserStatus())
                {
                    //set user
                    user = new User(userID, FirstName, LastName, Email, siteID, positionID, permissionLevel, userPermissionID);
                    //close conn
                    conn.Close();
                    //Open form
                    Main h = new Main();
                    h.ShowDialog();
                }
            }
        }

        private bool CheckUser()
        {
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message + "\nClosing the form", "Connection error");
                Close();
            }
            //Get password input
            string password = Utils.Encryptation(txtPass.Text);

            //Find password in db
            MySqlCommand userPass = new MySqlCommand("select employeeID, password, firstName, lastName, positionID, active, siteID from employee where password = '" + password + "'", conn);
            MySqlDataReader reader = userPass.ExecuteReader();

            if (reader.Read())
            {
                //set user fields
                userID = Convert.ToInt32(reader["employeeID"].ToString());
                positionID = Int32.Parse(reader["positionID"].ToString());
                siteID = Int32.Parse(reader["siteID"].ToString());
                active = (bool)reader["active"];

                //validate if user is still active

                //validate user id
                if (userID == Convert.ToInt32(txtUserID.Text))
                {



                    if (active)
                    {
                        txtPass.Text = "";
                        FirstName = reader["firstName"].ToString();
                        //Check if user is the admin or acadia 
                        if (userID == 1 || userID == 2)
                        {
                            LastName = "";
                        }
                        else
                        {
                            LastName = reader["lastName"].ToString();
                        }

                        reader.Close();

                        //Give all permissions to admin
                        //AdminPermission();
                        
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("User not active anymore");
                    }
                    txtPass.Text = "";
                    reader.Close();
                    //return true;


                }
                else { MessageBox.Show("User ID or Password not valid"); }
            }
            else { MessageBox.Show("User ID or Password not valid"); }

            reader.Close();
            return false;

        }

        private bool UserStatus()
        {
            bool goodData = true;

            //Find the user position
            MySqlCommand userPosition = new MySqlCommand("select permissionLevel from posn where positionID = '" + positionID + "'", conn);
            MySqlDataReader position = userPosition.ExecuteReader();

            if (position.Read())
            {
                permissionLevel = position["permissionLevel"].ToString();

                //close reader
                position.Close();

                //Find user permission
                MySqlCommand userPermission = new MySqlCommand("select permissionID from user_permission where employeeID = '" + userID + "'", conn);
                MySqlDataReader permissionID = userPermission.ExecuteReader();

                //Instantiate the list object
                userPermissionID = new List<string>();
                while (permissionID.Read()) { userPermissionID.Add(permissionID["permissionID"].ToString()); }


                //Close the reader 
                permissionID.Close();


            }
            else
            {
                MessageBox.Show("Permission Level not found!");
                goodData = false;
            }

            return goodData;

        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Close();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked)
            {
                txtPass.PasswordChar = '\0';
            }
            else txtPass.PasswordChar = '*';
        }


        /*
        private void AdminPermission()
        {
            //get all permissions
            conn.Open();
            MySqlCommand permissions = new MySqlCommand("SELECT * FROM permission", conn);
            MySqlDataReader permissionReader = permissions.ExecuteReader();

            while (permissionReader.Read())
            {
                AllPermissions.Add(permissionReader["permissionID"].ToString());
            }

            conn.Close();
            //delete all admin permissions
            conn.Open();
            MySqlCommand deleteAll = new MySqlCommand
                    ("DELETE FROM user_permission WHERE (employeeID = '" + employeeID + "')", conn);

            deleteAll.ExecuteReader();

            conn.Close();

            //set all admin permission
            foreach(string permission in AllPermissions)
            {
                MySqlCommand userPass = new MySqlCommand("INSERT INTO user_permission (employeeID, permissionID) VALUES (employeeID = '" + employeeID + "', permissionID = '" + permission + "')", conn);
                userPass.ExecuteReader();
            }


            conn.Close();
        }

        */
    }
}
