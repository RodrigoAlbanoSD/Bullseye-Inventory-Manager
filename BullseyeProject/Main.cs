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
    public partial class Main : Form
    {
        //User fields
        public static User user;


        //Table field
        public static string tab;
        private string editOrAdd;
        private string InventoryEditOrAdd;
        public static string updateOrder;

        //txn (orders) fields
        public static int txnID;
        private int itemID;
        public static Txn t;
        public static List<txnItems> productList = new List<txnItems>();
        public static List<txnItems> backorderList = new List<txnItems>();

        //Counters
        private int countItems;
        public static int countOrders;
        public static int countEO;

        //Delivery variables
        public static int deliveryID;
        public double weight;
        public int caseSize;


        public Main()
        {
            InitializeComponent();
        }

        //Dataset connection. Logged to my sql account
        static string connString ="server=localhost;database=bullseyedb2022;" +
           "userid=Rodrigo;password=rororo0808; ";
        MySqlConnection conn = new MySqlConnection(connString);


        private void Main_Load(object sender, EventArgs e)
        {

            //Set user fields
            user = Login.user;

            //Welcoming message
            lblUserName.Text = "Hello " + user.userName;

            
            //Select biginning Tab
            if (user.positionID == Utils.adminPosn)
            {
                tabControl.SelectTab(Utils.adminTab);
            }
            else if(user.positionID == Utils.adminPosn)
            {
                tabControl.SelectTab(Utils.storeOrdersTab);
            }
            else FillHomeTab();

        }



        /// <summary>
        /// Tab functions
        /// Functions related to draw the tabs, control the user permission and fill the tables
        /// </summary>
        /// 
        //Paint all tabs
        private void tabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            Utils.DrawTabs(e);
        }


        //Set up home tab based on user position
        private void FillHomeTab()
        {

            //Check if user is truck driver or bullseye employee
            if (user.positionID == Utils.truckingDeliveryPosn)
            {

                grpPickup.Parent = grpPrepareOrder.Parent;
                //check permission
                if (Utils.CheckPermissions(Utils.permissionDelivery))
                {
                    //change visualization
                    grpPickup.Visible = true;
                    grpPrepareOrder.Visible = false;

                    //Fill table with all orders assembled and in transit
                    this.txnTableAdapter.FillForDlivery(this.bullseyedb2022DataSet.txn, Utils.statusAssembled, Utils.statusInTransit);

                    //Display how many order is available for driver
                    AvailableOrders();

                }
            }
            else if(user.positionID == Utils.warehouseClerkPosn || user.positionID == Utils.warehouseManagerPosn)
            {

                //check permission
                if (Utils.CheckPermissions(Utils.permissionPrepareStoreOrder))
                {

                    //Manager and clerk warehouse workers
                    grpPickup.Visible = false;
                    grpPrepareOrder.Visible = true;

                    //Display how many order is available for WH employeers
                    AvailableOrders();

                    //clean list box
                    lstProductList.Items.Clear();
                    lstProductList.Items.Add("Order\tItemID\tquantity\tCost\tStatus");

                    //clean product list
                    productList.Clear();
                }

                
            }
            else if (user.positionID == Utils.storeClerkPosn || user.positionID == Utils.storeManagerPosn)
                {
                    //no permission required
                    //Manager and clerk warehouse workers
                    grpPickup.Visible = false;
                    grpPrepareOrder.Visible = true;
                    btnAddToBackorder.Enabled = false;

                    //Display how many order is available for Store employeers
                    AvailableOrders();

                    //clean list box
                    lstProductList.Items.Clear();
                    lstProductList.Items.Add("Order\tItemID\tquantity\tCost\tStatus");

                    //clean product list
                    productList.Clear();
                }
            //No alert. Everybody allowed
        }
    

        //Find how many order are available for the user based on their position
        private void AvailableOrders()
        {
            //Reset counters
            countOrders = 0;
            countEO = 0;

            conn.Open();
            if (user.positionID == Utils.truckingDeliveryPosn)
            {
                
                MySqlCommand userPass = new MySqlCommand("SELECT txnID, emergencyDelivery FROM txn WHERE status in('" + Utils.statusAssembled + "', '" + Utils.statusInTransit + "')", conn);
                MySqlDataReader reader = userPass.ExecuteReader();
                while (reader.Read())
                {
                    //count orders
                    if (reader["emergencyDelivery"].ToString() == "1")
                    {
                        countEO++;
                    }
                    else countOrders++;
                }
                
            }
            else if (user.positionID == Utils.warehouseClerkPosn || user.positionID == Utils.warehouseManagerPosn)
            {
                MySqlCommand userPass = new MySqlCommand("SELECT txnID, emergencyDelivery FROM txn WHERE status ='" + Utils.statusAssembling + "' and txnType <> 'Sale' ", conn);
                MySqlDataReader reader = userPass.ExecuteReader();
                //clear list
                cboMissingTxnID.Items.Clear();
                while (reader.Read())
                {
                    //Fill comboBox and count order
                    cboMissingTxnID.Items.Add(reader["txnID"]);
                    if (reader["emergencyDelivery"].ToString() == "1")
                    {
                        countEO++;
                    }
                    else countOrders++;
                }
            }
            else if (user.positionID == Utils.storeClerkPosn || user.positionID == Utils.storeManagerPosn)
            {
                MySqlCommand userPass = new MySqlCommand("SELECT txnID FROM txn WHERE status ='" + Utils.statusAssembling + "' and txnType = 'Sale'", conn);
                MySqlDataReader reader = userPass.ExecuteReader();
                //clear list
                cboMissingTxnID.Items.Clear();
                while (reader.Read())
                {
                    //Fill comboBox and count order
                    cboMissingTxnID.Items.Add(reader["txnID"]);
                    countOrders++;
                }
            }

            //Display counters for user
            lblAvailableOrders.Text = countOrders + " orders available!";
            if (countEO > 0)
            {
                lblAvailableEO.Text = countEO + " emergency orders available for pick up!";
            }
            else lblAvailableEO.Text = "";

            //Reset combobox. Whem index changed the tables will be filled
            if (cboMissingTxnID.Items.Count > 0)
            {
                cboMissingTxnID.SelectedIndex = 0;
            }
            else cboMissingTxnID.SelectedIndex = -1;

            //close connection
            conn.Close();
        }


        //Fill tables based on tab index
        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Assign table field to the current tab
            tab = tabControl.SelectedTab.Name.ToString();

            //check which tab was clicked
            if (tab == Utils.adminTab)
            {
                //check permission
                if (Utils.CheckPermissions(Utils.permissionReadUser))
                {
                    grpAdmin.Visible = true;
                        
                    //EMPLOYEE
                    this.employeeTableAdapter.Fill(this.bullseyedb2022DataSet.employee);
                }
                else { MessageBox.Show("You do not have permission to access this tab", "Alert!"); }
            }
            else if (tab == Utils.homeTab)
            {
                //check permission
                if (Utils.CheckPermissions(Utils.permissionPrepareStoreOrder) || Utils.CheckPermissions(Utils.permissionDelivery))
                {
                    FillHomeTab();
                }
                //No alert. Everybody allowed

            }
            else if (tab == Utils.inventoryTab)
            {
                //check permission
                if (Utils.CheckPermissions(Utils.permissionEditInventory))
                {
                    //make the tab visible
                    grpInventory.Visible = true;

                    //Fill combobox
                    conn.Open();
                    MySqlCommand userPass = new MySqlCommand("select name from site", conn);
                    MySqlDataReader reader = userPass.ExecuteReader();
                    //clear list
                    cboSites.Items.Clear();
                
                    while (reader.Read())
                    {
                        cboSites.Items.Add(reader["name"]);
                    }
                    cboSites.Items.Add("All Sites");
                    conn.Close();
                    
                    //Fill table
                    this.inventoryTableAdapter.FillBySite(this.bullseyedb2022DataSet.inventory, user.siteID);
                }
                else { MessageBox.Show("You do not have permission to access this tab", "Alert!"); }

            }
            else if (tab == Utils.storeOrdersTab)
            {
                //check permission
                if(Utils.CheckPermissions(Utils.permissionViewOrders)){
                    //clean product list
                    productList.Clear();

                    grpStoreOrders.Visible = true;


                    //Fill comboBox sites
                    conn.Open();
                    MySqlCommand userPass = new MySqlCommand("select name from site", conn);
                    MySqlDataReader reader = userPass.ExecuteReader();
                    //clear list
                    cboSitesSO.Items.Clear();

                    while (reader.Read())
                    {
                        cboSitesSO.Items.Add(reader["name"]);
                    }
                    cboSitesSO.Items.Add("All Sites");
                    conn.Close();

                    //Txn
                    //Fill by site and outstanding
                    this.txnTableAdapter.FillByOutstandingPerSite(this.bullseyedb2022DataSet.txn, user.siteID);

                }
                else { MessageBox.Show("You do not have permission to access this tab", "Alert!"); }
            }
            else if (tab == Utils.reportsTab)
            {
                grpReports.Visible = true;
                this.txnauditTableAdapter.Fill(this.bullseyedb2022DataSet.txnaudit);
                //check permision
                if (Utils.CheckPermissions(Utils.permissionModifyRecord))
                {

                }
                //else { MessageBox.Show("You do not have permission to access this tab", "Alert!"); }
                
            }
            else if (tab == Utils.sitesTab)
            {
                //check permision
                if (Utils.CheckPermissions(Utils.permissionViewLocation))
                {
                    grpSites.Visible = true;
                    this.siteTableAdapter.Fill(this.bullseyedb2022DataSet.site);
                }
                else { MessageBox.Show("You do not have permission to access this tab", "Alert!"); }
            }
            else if (tab == Utils.productsTab)
            {
                this.itemTableAdapter.Fill(this.bullseyedb2022DataSet.item);
                
            }
            else if(tab == Utils.chatTab)
            {
                //Only get emails sent to this user
                this.emailsTableAdapter.FillByUserID(this.bullseyedb2022DataSet.emails, user.userID);
            }
        }


        /// <summary>
        /// User function
        /// Functions erlated to logout and receive notifications
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChangeUser_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you really want to Logout?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }



        /// <summary>
        /// Navigator functions
        /// All functions related to navigate throught all tables
        /// </summary>
        
        //For each navigator button, call MoveItem function with the button id
        private void btnFirst_Click(object sender, EventArgs e) => MoveItem(Utils.first);

        private void btnPrevious_Click(object sender, EventArgs e) => MoveItem(Utils.previous);

        private void btnNext_Click(object sender, EventArgs e) => MoveItem(Utils.next);

        private void btnLast_Click(object sender, EventArgs e) => MoveItem(Utils.last);

        private void MoveItem(string key)
        {
            //check which tab the user is and then check the button clicked
            if (tab == Utils.homeTab)
            {
                /*if(grpPickup.Visible == true)
                {
                    if (key == Utils.first) this.txnitemsBindingSource.MoveFirst();
                    else if (key == Utils.previous) this.txnitemsBindingSource.MovePrevious();
                    else if (key == Utils.next) this.txnitemsBindingSource.MoveNext();
                    else if (key == Utils.last) this.txnitemsBindingSource.MoveLast();
                }
                else
                {
                    if (key == Utils.first) this.txnitemsBindingSource.MoveFirst();
                    else if (key == Utils.previous) this.txnitemsBindingSource.MovePrevious();
                    else if (key == Utils.next) this.txnitemsBindingSource.MoveNext();
                    else if (key == Utils.last) this.txnitemsBindingSource.MoveLast();
                }
                */
            }
            else if (tab == Utils.inventoryTab)
            {

                if (key == Utils.first) this.inventoryBindingSource.MoveFirst();
                else if (key == Utils.previous) this.inventoryBindingSource.MovePrevious();
                else if (key == Utils.next) this.inventoryBindingSource.MoveNext();
                else if (key == Utils.last) this.inventoryBindingSource.MoveLast();
            }
            else if (tab == Utils.storeOrdersTab)
            {
                if (key == Utils.first) this.txnBindingSource.MoveFirst();
                else if (key == Utils.previous) this.txnBindingSource.MovePrevious();
                else if (key == Utils.next) this.txnBindingSource.MoveNext();
                else if (key == Utils.last) this.txnBindingSource.MoveLast();
            }
            else if (tab == Utils.sitesTab)
            {
                if (key == Utils.first) this.siteBindingSource.MoveFirst();
                else if (key == Utils.previous) this.siteBindingSource.MovePrevious();
                else if (key == Utils.next) this.siteBindingSource.MoveNext();
                else if (key == Utils.last) this.siteBindingSource.MoveLast();
            }
            else if (tab == Utils.productsTab)
            {
                if (key == Utils.first) this.itemBindingSource.MoveFirst();
                else if (key == Utils.previous) this.itemBindingSource.MovePrevious();
                else if (key == Utils.next) this.itemBindingSource.MoveNext();
                else if (key == Utils.last) this.itemBindingSource.MoveLast();
            }
            else if (tab == Utils.reportsTab)
            {
                if (key == Utils.first) this.txnauditBindingSource.MoveFirst();
                else if (key == Utils.previous) this.txnauditBindingSource.MovePrevious();
                else if (key == Utils.next) this.txnauditBindingSource.MoveNext();
                else if (key == Utils.last) this.txnauditBindingSource.MoveLast();
            }
            else if (tab == Utils.adminTab)
            {
                if (key == Utils.first) this.employeeBindingSource.MoveFirst();
                else if (key == Utils.previous) this.employeeBindingSource.MovePrevious();
                else if (key == Utils.next) this.employeeBindingSource.MoveNext();
                else if (key == Utils.last) this.employeeBindingSource.MoveLast();
            }
        }

        //Connect each table binding dource to the position displayer
        private void employeeBindingSource_PositionChanged(object sender, EventArgs e)
        {
            string msg = (employeeBindingSource.Position + 1) + " of " + employeeBindingSource.Count;

            lblPositionChanged.Text = msg;
        }

        private void itemBindingSource_PositionChanged(object sender, EventArgs e)
        {
            string msg = (itemBindingSource.Position + 1) + " of " + itemBindingSource.Count;

            lblPositionChanged.Text = msg;
        }

        private void inventoryBindingSource_PositionChanged(object sender, EventArgs e)
        {
            string msg = (inventoryBindingSource.Position + 1) + " of " + inventoryBindingSource.Count;

            lblPositionChanged.Text = msg;
        }
        private void txnBindingSource_PositionChanged(object sender, EventArgs e)
        {
            string msg = (txnBindingSource.Position + 1) + " of " + txnBindingSource.Count;

            lblPositionChanged.Text = msg;
        }

        private void txnitemsBindingSource_PositionChanged(object sender, EventArgs e)
        {
            string msg = (txnitemsBindingSource.Position + 1) + " of " + txnitemsBindingSource.Count;

            lblPositionChanged.Text = msg;
        }



        /// <summary>
        /// Admin tab
        /// functions related to admin tab features
        /// </summary>
        /// 

        //Create button
        //check user permision and change box visibility
        private void btnCreate_Click(object sender, EventArgs e)
        {
            //check permision
            if (Utils.CheckPermissions(Utils.permissionAddUser))
            {
                changeVisibility(true, btnCreate.Name);
                editOrAdd = btnCreate.Name;
            }
            else { MessageBox.Show("You do not have permission to add new employees", "Alert!"); }
        }

        //Edit button
        //check user permission and change visibility
        private void btnEdit_Click(object sender, EventArgs e)
        {
            //check permision
            if (Utils.CheckPermissions(Utils.permissionEditUser))
            {
                    changeVisibility(true, btnEdit.Name);
                    editOrAdd = btnEdit.Name;
            }
            else { MessageBox.Show("You do not have permission to edit employees information", "Alert!"); }
        }

        //deactivate button
        //check permission and set user status as deactivated 
        private void btnDeactivate_Click(object sender, EventArgs e)
        {
            //check permision
            if (Utils.CheckPermissions(Utils.permissionEditUser))
            {
                try
                {
                    int employeeID = int.Parse(this.bullseyedb2022DataSet.Tables[2].Rows[employeeBindingSource.Position]["employeeID"].ToString());
                    this.employeeTableAdapter.DeactivateEmployee(0, employeeID);
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Database error # " + ex.Number + ": " +
                        ex.Message, "Error " + ex.GetType().ToString() + " Showing Data");
                }
            }
            else { MessageBox.Show("You do not have permission to edit employees information", "Alert!"); }

        }

        //Discard button
        //change visibility and discard 
        private void btnDiscard_Click(object sender, EventArgs e)
        {
            changeVisibility(false, btnDiscard.Name);
        }

        //Advanced button
        //check user permission and show the Advanced Option. There the admin can change permissions
        //Missing code to protect from admin setting its on permissions off
        private void btnAdvancedOptions_Click(object sender, EventArgs e)
        {

            //check permision
            if (Utils.CheckPermissions(Utils.permissionSetPermissionUser))
            {
                if (grpAdvancedOptions.Visible)
                {
                    grpAdvancedOptions.Visible = false;
                }
                else
                {
                    grpAdvancedOptions.Visible = true;
                }
            }
            else { MessageBox.Show("You don't have permission to Advanced Options", "Alert!"); }

        }

        //Save button
        //check which box is visible
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (grpAddEmployee.Visible)
            {
                
                if (editOrAdd == btnCreate.Name)
                {
                    string text = "Are you sure you want to add this employee?\n" +
                         "\nName: " + txtFirstName.Text + " " + txtLastName +
                         "\nEmail: " + txtEmail.Text +
                         "\nSite: " + txtSite.Text +
                         "\nPosition: " + cboPosition.Text +
                         "\nPassword: " + txtPassword.Text;
                    DialogResult res = MessageBox.Show(text, "Review Employee Fields", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (res == DialogResult.OK)
                    {
                        //for create employee
                        try
                        {
                            //encrypt the password
                            string password = Utils.Encryptation(txtPassword.Text);
                            int posn = Utils.FindPosition(cboPosition.Text);
                            //add new employee
                            this.employeeTableAdapter.NewEmployee
                                (password, txtFirstName.Text, txtLastName.Text, txtEmail.Text, 1,
                                posn, int.Parse(txtSite.Text));
                        }
                        catch (MySqlException ex)
                        {
                            MessageBox.Show("Database error # " + ex.Number + ": " +
                                ex.Message, "Error " + ex.GetType().ToString() + " Showing Data");
                        }
                    }
                    if (res == DialogResult.Cancel)
                    {
                        btnDiscard.PerformClick();
                    }
                    
                }
                else
                {
                    
                    //to edit employee info
                    try
                    {
                        //check if user wants to change password
                        if (txtPassword.Text == "")
                        {
                            string text = "Are you sure you want to edit this employee?" +
                             "\nName: " + txtFirstName.Text + " " + txtLastName +
                             "\nEmail: " + txtEmail.Text +
                             "\nSite: " + txtSite.Text +
                             "\nPosition: " + cboPosition.Text;
                            DialogResult res = MessageBox.Show(text , "Review Employee Fields", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                            if (res == DialogResult.OK)
                            {
                                int posn = Utils.FindPosition(cboPosition.Text);
                                int site = int.Parse(txtSite.Text);
                                int id = int.Parse(txtID.Text);
                                this.employeeTableAdapter.UpdateEmployee(txtFirstName.Text, txtLastName.Text,
                                    txtEmail.Text, posn, site, id);

                            }
                            if (res == DialogResult.Cancel)
                            {
                                btnDiscard.PerformClick();
                            }
                            
                        }
                        else
                        {
                            string text = "Are you sure you want to edit this employee?" +
                             "\nName: " + txtFirstName.Text + " " + txtLastName +
                             "\nEmail: " + txtEmail.Text +
                             "\nSite: " + txtSite.Text +
                             "\nPosition: " + cboPosition.Text +
                             "\nPassword: " + txtPassword.Text;

                            DialogResult res = MessageBox.Show(text, "Review Employee Fields", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                            if (res == DialogResult.OK)
                            {
                                string password = Utils.Encryptation(txtPassword.Text);
                                int posn = Utils.FindPosition(cboPosition.Text);
                                int site = int.Parse(txtSite.Text);
                                int id = int.Parse(txtID.Text);
                                this.employeeTableAdapter.UpdateEmployeePassword(password, txtFirstName.Text, txtLastName.Text,
                                    txtEmail.Text, posn, site, id);

                            }
                            if (res == DialogResult.Cancel)
                            {
                                btnDiscard.PerformClick();
                            }

                        }

                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Database error # " + ex.Number + ": " +
                            ex.Message, "Error " + ex.GetType().ToString() + " Showing Data");
                    }
                }

            }

            //Set addEmployee visibility to false
            changeVisibility(false, btnSave.Name);

            //UpdateAll
            this.Validate();
            this.employeeBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.bullseyedb2022DataSet);

            //Update table
            this.employeeTableAdapter.Fill(this.bullseyedb2022DataSet.employee);
        }

        //Move Button
        //take combo box inputs and change the user permission
        private void btnMove_Click(object sender, EventArgs e)
        {
            if (cboAvailablePermissions.SelectedIndex == -1)
            {
                //remove the choosen permission
                int index = cboCurrentPermissions.SelectedIndex;
                string permission = cboCurrentPermissions.SelectedItem.ToString();
                conn.Open();

                MySqlCommand userPass = new MySqlCommand
                    ("DELETE FROM user_permission WHERE (employeeID = '" + txtID.Text + "' and permissionID = '" + permission + "') ", conn);

                userPass.ExecuteReader();

                conn.Close();

                cboCurrentPermissions.Items.RemoveAt(index);
                cboAvailablePermissions.Items.Add(permission);

            }
            else
            {
                //add the choosen permission
                int index = cboAvailablePermissions.SelectedIndex;
                string permission = cboAvailablePermissions.SelectedItem.ToString();
                conn.Open();

                MySqlCommand userPass = new MySqlCommand
                    ("INSERT INTO user_permission (employeeid, permissionid) VALUES ('"
                    + txtID.Text + "', '" + permission + "')", conn);

                userPass.ExecuteReader();

                conn.Close();

                cboAvailablePermissions.Items.RemoveAt(index);
                cboCurrentPermissions.Items.Add(permission);
            }
        }

        //Employee Table click
        //If a row is clicked, enable edit button
        private void employeeDataGridView_Click(object sender, EventArgs e)
        {
            btnEdit.Enabled = true;
            btnDeactivate.Enabled = true;
        }
        private void employeeDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            btnEdit.Enabled = true;
            btnDeactivate.Enabled = true;
        }

        //Change Visibility
        //Check key and pressed button to change groupboxes vibility and enable buttons 
        //Input: bool, string
        //Output: void
        private void changeVisibility(bool key, string button)
        {
            if (key)
            {
                grpAddEmployee.Visible = true;
                btnCreate.Enabled = false;
                btnDeactivate.Enabled = false;
                btnEdit.Enabled = false;
                txtID.Visible = false;
                if (button == btnEdit.Name)
                {
                    FillEditGroups();
                }

            }
            else
            {

                grpAddEmployee.Visible = false;
                grpAdvancedOptions.Visible = false;
                btnCreate.Enabled = true;
                btnDeactivate.Enabled = false;
                btnEdit.Enabled = false;
                lblPassField.Visible = false;
                btnAdvancedOptions.Visible = false;
                txtID.Visible = false;

                //Clean texts box
                txtFirstName.Clear();
                txtLastName.Clear();
                txtEmail.Clear();
                cboPosition.SelectedIndex = -1;
                txtSite.Clear();
                txtPassword.Clear();
            }

        }

        //Fill Edit groups
        //Fill labels with user status
        //Input: void
        //Output: void
        private void FillEditGroups()
        {

            lblPassField.Visible = true;
            btnAdvancedOptions.Visible = true;
            txtID.Visible = true;
            int position = this.employeeBindingSource.Position;
            int count = 0;
            foreach (DataRow row in this.bullseyedb2022DataSet.employee)
            {
                if (count == position)
                {
                    txtID.Text = row["employeeID"].ToString();
                    txtFirstName.Text = row["firstName"].ToString();
                    txtLastName.Text = row["lastName"].ToString();
                    txtEmail.Text = row["email"].ToString();
                    txtSite.Text = row["siteID"].ToString();


                }
                count++;
            }
            //Create list
            List<string> currentPermissions = new List<string>();
            //CLear combo boxes
            cboAvailablePermissions.Items.Clear();
            cboCurrentPermissions.Items.Clear();

            conn.Open();
            MySqlCommand userPass = new MySqlCommand("select employeeID, permissionID from user_permission", conn);
            MySqlDataReader reader = userPass.ExecuteReader();
            while (reader.Read())
            {
                if (reader["employeeID"].ToString() == txtID.Text)
                {
                    cboCurrentPermissions.Items.Add(reader["permissionID"].ToString());
                    currentPermissions.Add(reader["permissionID"].ToString());
                }
            }
            conn.Close();

            conn.Open();
            userPass = new MySqlCommand("select permissionID from permission", conn);
            reader = userPass.ExecuteReader();

            while (reader.Read())
            {
                count = 0;
                for (int i = 0; i < currentPermissions.Count; i++)
                {
                    if (currentPermissions[i] == reader["permissionID"].ToString())
                    {
                        count++;
                    }
                }
                if (count < 1)
                {
                    cboAvailablePermissions.Items.Add(reader["permissionID"].ToString());
                }

            }
            conn.Close();
        }

        private void cboSites_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSites.SelectedItem.ToString() == "All Sites")
            {
                this.inventoryTableAdapter.Fill(this.bullseyedb2022DataSet.inventory);
            }
            else this.inventoryTableAdapter.FillBySite(this.bullseyedb2022DataSet.inventory, cboSites.SelectedIndex + 1);
        }

        private void cboAvailablePermissions_SelectedIndexChanged(object sender, EventArgs e)
        {
            int temp = cboAvailablePermissions.SelectedIndex;
            cboCurrentPermissions.SelectedIndex = -1;
            cboAvailablePermissions.SelectedIndex = temp;
        }

        private void cboCurrentPermissions_SelectedIndexChanged(object sender, EventArgs e)
        {
            int temp = cboCurrentPermissions.SelectedIndex;
            cboAvailablePermissions.SelectedIndex = -1;
            cboCurrentPermissions.SelectedIndex = temp;
        }

        /// <summary>
        /// Home tab functions
        /// </summary>

        //When comboBox selections changes, fill the txn items table
        //Add all items to product and backorder product list
        private void cboMissingTxnID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMissingTxnID.SelectedIndex != -1)
            {
                //get txnid from combo box
                txnID = Int32.Parse(cboMissingTxnID.SelectedItem.ToString());

                //fill txntable with specified id
                this.txnitemsTableAdapter.FillByTxnID(this.bullseyedb2022DataSet.txnitems, txnID);

            }
        }

        //When table selection changes, fill the item detail
        //check the product availability
        //If warehouse inventory have enough items, enable scan button, else enable backorder button
        private void txnitemsDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            //get txn id
            int position = this.txnitemsBindingSource.Position;
            int count = 0, itemID, quantity;
            countItems = 0;
            foreach (DataRow row in this.bullseyedb2022DataSet.txnitems)
            {
                countItems++;
                if (count == position)
                {
                    itemID = (int)row["itemID"];
                    quantity = (int)row["quantity"];
                    bool test = CheckItemAvailability(itemID, quantity);

                    btnCheck.Enabled = test;
                    btnAddToBackorder.Enabled = !test;

                    this.itemTableAdapter.FillByItemID(this.bullseyedb2022DataSet.item, itemID);
                    //break;
                }
                count++;
            }
        }

        //Scan button is clicked, add item to listbox
        //Check if all items were scanned and fulfill order
        //change orders status to aseembled and location to warehouse-to-order
        private void btnCheck_Click(object sender, EventArgs e)
        {
            //check permision
            if (Utils.CheckPermissions(Utils.permissionFulfilStoreOrder) || user.positionID == Utils.storeClerkPosn || user.positionID == Utils.storeManagerPosn)
            {
                RedirectItem(Utils.statusAssembled);
                //remove item from txnItems

            }
            else { MessageBox.Show("You do not have permission to scan this product", "Alert!"); }
        }

        private void btnAddToBackorder_Click(object sender, EventArgs e)
        {
            //check permision
            if (Utils.CheckPermissions(Utils.permissionCreateBackOrder) || user.positionID == Utils.storeClerkPosn || user.positionID == Utils.storeManagerPosn)
            {
                RedirectItem(Utils.statusPendingBackOrder);
                //remove item from txnItems

            }
            else { MessageBox.Show("You do not have permission to create a backorder", "Alert!"); }
        }

        private void RedirectItem(string status)
        {

            //init the variable for a new txnItem object
            if (itemIDTextBox.Text != "")
            {

                int itemID = Int32.Parse(itemIDTextBox.Text);
                txnItems itemIDTemp = productList.Find(x => x.itemID == itemID);
                if (itemIDTemp == null)
                {
                    double costPrice = Double.Parse(costPriceTextBox.Text);

                    //quantity is the amount of items requested in order
                    int quantity = 0;
                    int quantityInSite = Int32.Parse(txtQuantityInSite.Text);
                    foreach (DataRow row in this.bullseyedb2022DataSet.txnitems)
                    {
                        if (itemID == (int)row["itemID"])
                        {
                            //get item quantity
                            quantity = (int)row["quantity"];
                            break;
                        }
                    }

                    if (status == Utils.statusPendingBackOrder)
                    {
                        quantity -= quantityInSite;
                    }
                    //Instantiate a new txnItens object
                    txnItems t = new txnItems(txnID, itemID, costPrice, quantity, status, quantityInSite);

                    //Add it to list
                    productList.Add(t);
                    //Display it
                    lstProductList.Items.Add(t.ToStringWithStatus());

                    //Check if all items are in list
                    if (countItems == lstProductList.Items.Count - 1)
                    {
                        //fulfill order
                        MessageBox.Show("The order number " + txnID + " is finished", "Mission complete");
                        AssembleOrder();
                    }
                }
                else MessageBox.Show("Product already scanned", "Alert!");

            }


        }
        private void AssembleOrder()
        {
            //Update txn Table with new status as assembled for the current txnID
            this.txnTableAdapter.UpdateStatus(Utils.statusAssembled, txnID);

            //string location = "Warehouse-to-order";

            //Move inventory
            for (int i = 0; i < productList.Count(); i++)
            {
                if (productList[i].status == Utils.statusAssembled)
                {
                    //Update location
                    Utils.MoveLocation(productList[i].itemID, "warehouse-to-order", 2);

                    //Get order param
                    t = Utils.FindTxn(txnID);
                    //Audit Activity
                    Utils.Audit(txnID, t.txnType, t.status, t.createdDate, t.siteIDFrom, t.deliveryID);
                }
                else if (productList[i].status == Utils.statusPendingBackOrder)
                {
                    backorderList.Add(productList[i]);
                }
            }

            //Create new txn for backorder products

            if (backorderList.Count > 0)
            {
                //Set param
                int siteIDTo = 1; // truck ? 
                string status = Utils.statusPendingBackOrder;

                DateTime createdDate = DateTime.Parse(DateTime.Now.ToString("yyyy/MM/d hh:mm:ss"));
                DateTime shipDate = DateTime.Parse(Utils.FindShipDate().ToShortDateString());
                shipDate = DateTime.Parse(shipDate.ToString("yyyy/MM/d"));

                string txnType = Utils.backOrder;
                string barCode = "111222333444";
                deliveryID = 1;
                int emergencyDelivery = 0;

                //Create new txn
                CreateTxn(siteIDTo, status, shipDate, txnType, barCode, createdDate, emergencyDelivery, backorderList);

                //Audit Activity
                Utils.Audit(txnID, txnType, status, createdDate, user.siteID, deliveryID);

                MessageBox.Show("A new order is created for the missing items", "Backorder");
            }
            //Update home page
            FillHomeTab();
        }



        private bool CheckItemAvailability(int itemID, int requestedQuantity)
        {
            int quantityInSite;
            bool data = false;
            try
            {
                conn.Open();
                //check item availability in warehouse site ( 2 )
                MySqlCommand userPass = new MySqlCommand("select quantity from inventory where (itemID = '" + itemID + "' and siteID= 2)", conn);
                MySqlDataReader reader = userPass.ExecuteReader();
                if (reader.Read())
                {
                    //lblTest.Text = siteID.ToString();
                    quantityInSite = (int)reader["quantity"];
                    txtQuantityInSite.Text = quantityInSite.ToString();
                    data = requestedQuantity < quantityInSite;

                }
                conn.Close();
            }
            catch
            {
                //lblTest.Text = "erro";
            }
            return data;

        }


        private void btnPickUp_Click(object sender, EventArgs e)
        {
            //Update status
            this.txnTableAdapter.UpdateStatus(Utils.statusInTransit, txnID);
            //Get order param
            t = Utils.FindTxn(txnID);
            //Audit Activity
            Utils.Audit(txnID, t.txnType, t.status, t.createdDate, t.siteIDFrom, t.deliveryID);

            //Update inventory
            conn.Open();
            MySqlCommand userPass = new MySqlCommand("select itemID, quantity from txnitems where txnID = " + txnID, conn);
            MySqlDataReader reader = userPass.ExecuteReader();

            while (reader.Read())
            {
                int itemID = Int32.Parse(reader["itemID"].ToString());
                int quantity = Int32.Parse(reader["quantity"].ToString());

                Utils.MoveLocation(itemID, "VHCL", 2); // 2 = wh
            }
            conn.Close();

            this.txnTableAdapter.FillForDlivery(this.bullseyedb2022DataSet.txn, Utils.statusAssembled, Utils.statusInTransit);
            btnPickUp.Enabled = false;
        }

        private void btnDelivery_Click(object sender, EventArgs e)
        {
            //Update status
            this.txnTableAdapter.UpdateStatus(Utils.statusDelivered, txnID);
            //Get order param
            t = Utils.FindTxn(txnID);
            //Audit Activity
            Utils.Audit(txnID, t.txnType, t.status, t.createdDate, t.siteIDFrom, t.deliveryID);


            //Update inventory
            conn.Open();
            MySqlCommand userPass = new MySqlCommand("select itemID, quantity from txnitems where txnID = " + txnID, conn);
            MySqlDataReader reader = userPass.ExecuteReader();

            while (reader.Read())
            {
                int itemID = Int32.Parse(reader["itemID"].ToString());
                int quantity = Int32.Parse(reader["quantity"].ToString());

                Utils.MoveLocation(itemID, "VHCL-to-Store", 2); // 2 = wh
            }
            conn.Close();


            this.txnTableAdapter.FillForDlivery(this.bullseyedb2022DataSet.txn, Utils.statusAssembled, Utils.statusInTransit);
            btnDelivery.Enabled = false;
        }

        private void txndgvSO_SelectionChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab.Name.ToString() == Utils.homeTab)
            {
                int position = this.txnBindingSource.Position;
                int count = 0;
                foreach (DataRow row in this.bullseyedb2022DataSet.txn)
                {
                    if (count == position)
                    {
                        txnID = Int32.Parse(row["txnID"].ToString());
                        string status = row["status"].ToString();

                        if (status == Utils.statusAssembled)
                        {
                            grpOrderDetails.Visible = true;
                            //change buttons
                            btnPickUp.Enabled = true;
                            btnDelivery.Enabled = false;
                            //clear list
                            productList.Clear();

                            conn.Open();
                            MySqlCommand userPass = new MySqlCommand("select itemID, quantity from txnitems where txnID = " + txnID, conn);
                            MySqlDataReader reader = userPass.ExecuteReader();
                            //clear list
                            cboItemID.Items.Clear();
                            if (reader.Read())
                            {
                                int itemID = Int32.Parse(reader["itemID"].ToString());
                                int quantity = Int32.Parse(reader["quantity"].ToString());
                                cboItemID.Items.Add(itemID);
                                productList.Add(new txnItems(itemID, quantity));
                            }
                            reader.Close();

                            userPass = new MySqlCommand("select d.notes from delivery d, txn t where d.deliveryID = t.deliveryID and txnID = " + txnID, conn);
                            reader = userPass.ExecuteReader();

                            if (reader.Read())
                            {
                                txtDeliveryNotes.Text = reader["notes"].ToString();
                            }
                            conn.Close();


                            cboItemID.SelectedIndex = 0;
                            FindTotalWeight();

                        }
                        else if (status == Utils.statusInTransit)
                        {
                            btnPickUp.Enabled = false;
                            btnDelivery.Enabled = true;
                        }
                        break;
                    }
                    grpOrderDetails.Visible = false;
                    count++;
                }
                //this.txnTableAdapter.UpdateStatus(Utils.statusInTransit, txnID);

                btnPickUp.Enabled = true;
            }


        }

        private void FindTotalWeight()
        {
            weight = 0.0;
            caseSize = 0;
            int count = cboItemID.Items.Count;

            for (int i = 0; i < count; i++)
            {
                conn.Open();
                MySqlCommand userPass = new MySqlCommand("select weight, caseSize from item  where itemID = " + productList[i].itemID, conn);
                MySqlDataReader reader = userPass.ExecuteReader();
                while (reader.Read())
                {
                    weight += productList[i].quantity * Double.Parse(reader["weight"].ToString());
                    caseSize += productList[i].quantity * Int32.Parse(reader["caseSize"].ToString());
                }
                conn.Close();
            }

            lblOrderDetail1.Text = "The total weight in this transaction is " + weight;
            lblOrderDetail2.Text = "The total size in this transaction is " + caseSize;
        }

        private void cboItemID_SelectedIndexChanged(object sender, EventArgs e)
        {
            int itemID = Int32.Parse(cboItemID.SelectedItem.ToString());

            this.itemTableAdapter.FillByItemID(this.bullseyedb2022DataSet.item, itemID);
        }



        /// <summary>
        /// Email tab
        /// </summary>
        /// 


        private void btnNewEmail_Click(object sender, EventArgs e)
        {
            //Fill contacts comboBox
            conn.Open();
            MySqlCommand userPass = new MySqlCommand("select employeeID, FirstName, LastName from employee", conn);
            MySqlDataReader reader = userPass.ExecuteReader();
            //clear list
            cboContact.Items.Clear();

            while (reader.Read())
            {
                cboContact.Items.Add(reader["FirstName"] + " " + reader["LastName"] + " " + reader["employeeID"]);
            }
            conn.Close();


            txtLinkedTxnID.Clear();
            txtNewEmailSubject.Clear();
            txtNewEmailMessage.Clear();
            cboContact.SelectedIndex = -1;


            //Display interface
            grpNewEmail.Visible = true;
        }

        private void btnDeleteEmail_Click(object sender, EventArgs e)
        {
            //Ask user if his sure
            DialogResult res = MessageBox.Show("You sure you want to delete this email?", "Review Request", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (res == DialogResult.OK)
            {
                //Get variables
                int idfrom = Int32.Parse(employeeIDFromTextBox.Text);
                int idto = user.userID;
                DateTime date = sendDateDateTimePicker.Value;
                int txnID = Int32.Parse(txnIDTextBox1.Text);
                string titulo = subjectTextBox.Text;
                string message = messageTextBox.Text;
                this.emailsTableAdapter.DeleteEmail(idfrom, idto, date, txnID, titulo, message);

                //refresh table
                this.emailsTableAdapter.FillByUserID(this.bullseyedb2022DataSet.emails, user.userID);
            }

        }

        private void emailsDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            btnDeleteEmail.Enabled = true;
            if (txnIDTextBox1.Text != "")
            {
                int i = Int32.Parse(txnIDTextBox1.Text);
                try
                {
                    this.txnTableAdapter.FillByTxnID(this.bullseyedb2022DataSet.txn, i);
                }
                catch
                {
                    MessageBox.Show("txnID not regonized", "Alert");
                }
            }
            else
            {
                siteIDToTextBox1.Clear();
                siteIDFromTextBox1.Clear();
                statusTextBox1.Clear();
                txnTypeTextBox1.Clear();
                barCodeTextBox1.Clear();
                deliveryIDTextBox1.Clear();
            }

        }

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            if (
                subjectTextBox.Text != "" &&
                messageTextBox.Text != "" &&
                cboContact.SelectedIndex > 0
                )
            {
                int userIDTo = Int32.Parse(cboContact.SelectedItem.ToString().Split(' ')[2]);
                string subject = txtNewEmailSubject.Text;
                string message = txtNewEmailMessage.Text;
                DateTime now = DateTime.Now;

                if (txtLinkedTxnID.Text != "")
                {
                    int linkedTxnID = Int32.Parse(txtLinkedTxnID.Text);
                    this.emailsTableAdapter.InsertNewEmail(user.userID, userIDTo, now, linkedTxnID, subject, message);
                }
                else
                {

                    this.emailsTableAdapter.InsertNewEmailNoLinkedTxn(user.userID, userIDTo, now, subject, message);
                }

                //refresh table
                this.emailsTableAdapter.FillByUserID(this.bullseyedb2022DataSet.emails, user.userID);
                btnDiscardNewEmail.PerformClick();

            }
            else
            {
                MessageBox.Show("You should fill the subject and message boxes to send an email", "Alert!");
            }
        }

        private void btnDiscardNewEmail_Click(object sender, EventArgs e)
        {

            txtLinkedTxnID.Clear();
            txtNewEmailSubject.Clear();
            txtNewEmailMessage.Clear();
            cboContact.SelectedIndex = -1;
            grpNewEmail.Visible = false;
            btnDeleteEmail.Enabled = false;
        }



        /// <summary>
        /// Orders tab functions
        /// </summary>

        //Fill Txn table respecting the desired paramenters
        private void cboSitesSO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSitesSO.SelectedItem != null)
            {
                string site = cboSitesSO.SelectedItem.ToString();
                if (chkShowCompleteOrders.Checked)
                {
                    if (site == "All Sites")
                    {
                        this.txnTableAdapter.Fill(this.bullseyedb2022DataSet.txn);
                    }
                    else
                    {
                        this.txnTableAdapter.FillBySite(this.bullseyedb2022DataSet.txn, cboSitesSO.SelectedIndex + 1);

                    }
                }
                else
                {
                    if( site == "All Sites")
                    {
                        this.txnTableAdapter.FillByOutstanding(this.bullseyedb2022DataSet.txn);
                    }
                    else
                    {
                        this.txnTableAdapter.FillByOutstandingPerSite(this.bullseyedb2022DataSet.txn, cboSitesSO.SelectedIndex+1);

                    }
                }
            }

            btnUpdate.Enabled = false;
        }

        //If checked changes, fill txn table
        private void chkShowCompleteOrders_CheckedChanged(object sender, EventArgs e)
        {
            cboSitesSO.SelectedIndex = -1;

            if (chkShowCompleteOrders.Checked)
            {
                this.txnTableAdapter.Fill(this.bullseyedb2022DataSet.txn);
            }
            else
            {
                this.txnTableAdapter.FillByOutstanding(this.bullseyedb2022DataSet.txn);
            }
            btnUpdate.Enabled = false;
        }

        private void btnNewOrderSO_Click(object sender, EventArgs e)
        {
            //check permision
            if (Utils.CheckPermissions(Utils.permissionCreateStoreOrder) || Utils.CheckPermissions(Utils.permissionCreateSupplierOrder))
            {
                //count how many order are available
                AvailableOrders();


                if (countEO == 1 && countOrders >= 2)
                {
                    MessageBox.Show("There is no more order available for site number " + user.siteID, "Alert!");
                }
                else if (countEO == 0 && countOrders == 1)
                {
                    MessageBox.Show("There is only one emergency order available for site number " + user.siteID, "Alert!");
                    CallNewOrder();
                }
                else if (countEO == 1 && countOrders == 1)
                {
                    MessageBox.Show("There is only one normal order available for site number " + user.siteID, "Alert!");
                    CallNewOrder();
                }
                else if (countEO == 0 && countOrders == 0)
                {
                    CallNewOrder();
                }
            }
            else if (Utils.CheckPermissions(Utils.permissionCreateStoreOrder))
            {
                CallNewOrder();
            }
            else { MessageBox.Show("You do not have permission to create new orders", "Alert!"); }

        }
        private void CallNewOrder()
        {
            //Call new form and return a list of products
            NewOrder n = new NewOrder();
            n.ShowDialog();
            if(t != null)
            {
                //Create order
                CreateNewOrder();

                //Update how many order are available
                AvailableOrders();
            }
        }

        private void btnReceiveOrder_Click(object sender, EventArgs e)
        {
            //check permision
            // or Utils.CheckPermissions(Utils.permissionAcceptStoreOrder)
            if (Utils.CheckPermissions(Utils.permissionReceiveStoreOrder) || (user.positionID == Utils.storeManagerPosn || user.positionID == Utils.storeClerkPosn))
            {
                //call new form to process store orders
                ReceiveOrders r = new ReceiveOrders();
                r.ShowDialog();

                //Update how many orders are available
                AvailableOrders();

                //update txn table
                this.txnTableAdapter.FillByOutstanding(this.bullseyedb2022DataSet.txn);
            }
            else { MessageBox.Show("You do not have permission to receive orders", "Alert!"); }
        }

        //Every time a Order is selected update the txnItems table
        private void txnDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            //get txn id
            int position = this.txnBindingSource.Position;
            int count = 0;
            foreach (DataRow row in this.bullseyedb2022DataSet.txn)
            {
                if (count == position)
                {
                    txnID = (int)row["txnID"];
                    //fill txn items table
                    this.txnitemsTableAdapter.FillByTxnID(this.bullseyedb2022DataSet.txnitems, txnID);
                }
                count++;
            }
            btnUpdate.Enabled = true;
            btnReturnSO.Enabled = true;
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //if orders status is assembling, then proceed to update
            //take current status
            int position = this.txnBindingSource.Position;
            int count = 0;
            string statusTemp = "";
            foreach (DataRow row in this.bullseyedb2022DataSet.txn)
            {
                if (count == position)
                {
                    txnID = (int)row["txnID"];
                    statusTemp = row["status"].ToString();
                    break;
                }
                count++;
            }
            //check current status
            if(statusTemp == Utils.statusAssembling)
            {
                productList.Clear();
                //loop through order details to get all products in the list
                foreach (DataGridViewRow row in txnitemsDataGridViewSO.Rows)
                {
                    int itemID = Convert.ToInt32(row.Cells[1]); 
                    int quantity = Convert.ToInt32(row.Cells[2]);
                    string name = "";
                    double costPrice = 0.0;

                    conn.Open();
                    MySqlCommand userPass = new MySqlCommand("select name, costPrice from item where itemID = "+itemID, conn);
                    MySqlDataReader reader = userPass.ExecuteReader();
                    while (reader.Read())
                    {
                        name = reader["name"].ToString();
                        costPrice = (double)reader["costPrice"];
                    }
                    conn.Close();

                    productList.Add(new txnItems(itemID, costPrice*quantity, name, quantity));
                }
                //set key to new form
                updateOrder = Utils.updateOrder;
                NewOrder n = new NewOrder();
                n.ShowDialog();

                //update txnItems table
                this.txnTableAdapter.DeleteTxn(txnID);

                CreateNewOrder();
            }
            else MessageBox.Show("This order is no longer available to changes", "Alert!");


            //disable update button and key value
            btnUpdate.Enabled = false;
            updateOrder = null;
        }

        private void btnFilderSO_Click(object sender, EventArgs e)
        {

        }



        private void btnReturnSO_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("You sure you want to return this order?", "Review Request", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if(res == DialogResult.OK)
            {
                //get txn id
                int position = this.txnBindingSource.Position;
                int count = 0;
                foreach (DataRow row in this.bullseyedb2022DataSet.txn)
                {
                    if (count == position)
                    {
                        txnID = (int)row["txnID"];
                        txtItemIDReturn.Text = row["txnID"].ToString();
                        grpReturn.Visible = true;

                        break;
                    }
                    count++;
                }


            }
        }

        private void chkDamage_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDamage.Checked)
            {
                grpDamageProduct.Visible = true;
            }
            else grpDamageProduct.Visible = false;
        }

        private void btnSaveReturn_Click(object sender, EventArgs e)
        {
            if (txtNotesReturn.Text != "")
            {
               DialogResult res = MessageBox.Show("You sure you want to continue?", "Review Request", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (res == DialogResult.OK)
                {
                    //Update current order
                    this.txnTableAdapter.UpdateType(Utils.Return, txnID);

                    //if damage product then create new loss 
                    if (chkDamage.Checked)
                    {
                        //Set param
                        int siteIDTo = user.siteID;
                        string status = Utils.statusSubmmited; // ????
                        DateTime createdDate = DateTime.Parse(DateTime.Now.ToString("yyyy/MM/d hh:mm:ss"));
                        DateTime shipDate = DateTime.Parse(Utils.FindShipDate().ToShortDateString());
                        shipDate = DateTime.Parse(shipDate.ToString("yyyy/MM/d"));
                        string txnType = radLoss.Checked ? Utils.loss : Utils.damage;
                        int emergencyDelivery = 0;
                        string barCode = "111222333444";
                        deliveryID = 1;

                        //create new list and add the new product
                        List<txnItems> itemsList = new List<txnItems>();

                        itemsList.Add(new txnItems(Int32.Parse(txtDamageItemID.Text), Int32.Parse(nudQuantityReturn.Value.ToString())));

                        //Update status and create loss
                        CreateTxn(siteIDTo, status, shipDate, txnType, barCode, createdDate, emergencyDelivery, itemsList);

                        //Audit Activity
                        Utils.Audit(txnID, txnType, status, createdDate, user.siteID, deliveryID);
                        //return feedback
                        MessageBox.Show("A new order is created for the loss item", "Loss Order");

                    }

                    
                    btnDiscardReturn.PerformClick();
                }
            }
            else MessageBox.Show("You must write an explanation note", "Alert!");
 
        }

        private void btnDiscardReturn_Click(object sender, EventArgs e)
        {
            txtItemIDReturn.Clear();
            txtNotesReturn.Clear();
            chkDamage.Checked = false;
            nudQuantityReturn.Value = 1;
            grpReturn.Visible = false;
            btnReturnSO.Enabled = false;

            //refresh table
            this.txnTableAdapter.FillByOutstandingPerSite(this.bullseyedb2022DataSet.txn, user.siteID);

        }



        /// <summary>
        /// Inventory tab functions
        /// </summary>
        /// 

        private void inventoryDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            btnEditInventory.Enabled = true;
        }
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            InventoryEditOrAdd = "add";
            //display box
            grpEditInventory.Visible = true;
            //fill attributes
            txtItemID.ReadOnly = false;
            txtSiteID.Text = user.siteID.ToString();
            txtItemLocation.ReadOnly = false;
            //enable save button
            btnSaveInventory.Enabled = true;
            //disable edit btn
            btnEditInventory.Enabled = false;
        }
        
        private void btnEditInventory_Click(object sender, EventArgs e)
        {
            InventoryEditOrAdd = "edit";
            //fill products attributes
            FillInventoryEdit();
            //display box
            grpEditInventory.Visible = true;

            //disable add button
            btnAddProduct.Enabled = false;

        }

        private void btnCreateLoss_Click(object sender, EventArgs e)
        {
            //check permision
            if (Utils.CheckPermissions(Utils.permissionCreateLoss))
            {
                FillInventoryEdit();
                string itemID = txtItemID.Text;
                DialogResult res = MessageBox.Show("You sure you want to create a Loss for item " + itemID + "?", "Review Request", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (res == DialogResult.OK)
                {
                    txtItemId2.Text = itemID;

                    grpCreateLoss.Visible = true;
                }
            }
            else { MessageBox.Show("You do not have permission to create a loss", "Alert!"); }
                
        }

        private void FillInventoryEdit()
        {
            
            int position = this.inventoryBindingSource.Position;
            int count = 0;
            foreach (DataRow row in this.bullseyedb2022DataSet.inventory)
            {
                if (count == position)
                {
                    txtItemID.Text = row["itemID"].ToString();
                    txtSiteID.Text = row["siteID"].ToString();
                    txtItemLocation.Text = row["itemLocation"].ToString();
                    nudReorderThreshold.Value = Decimal.Parse(row["reorderThreshold"].ToString());
                    nudMaxReorder.Value = Decimal.Parse(row["maxReorderWarning"].ToString());
                    nudQuantity.Value = Decimal.Parse(row["quantity"].ToString());
                    break;
                }
                count++;
            }

            btnSaveInventory.Enabled = true;
        }

        private void btnSaveInventory_Click(object sender, EventArgs e)
        {
            if (grpEditInventory.Visible == true)
            {
                if (InventoryEditOrAdd == "add")
                {
                    if(txtItemID.Text  == ""|| txtSiteID.Text =="" || txtItemLocation.Text == "") { MessageBox.Show("You should fill all the fields boxes", "Alert!"); return; }
                    //get inputs
                    int quantity = Int32.Parse(nudQuantity.Value.ToString());
                    int reorder = Int32.Parse(nudReorderThreshold.Value.ToString());
                    int maxReoder = Int32.Parse(nudMaxReorder.Value.ToString());
                    int itemID = Int32.Parse(txtItemID.Text);
                    int siteID = Int32.Parse(txtSiteID.Text);

                    //Create product
                    this.inventoryTableAdapter.NewProduct(itemID, siteID, quantity, txtItemLocation.Text, reorder, maxReoder);
                    MessageBox.Show("Product added", "Feedback");
                }
                else
                {
                    //get inputs
                    int quantity = Int32.Parse(nudQuantity.Value.ToString());
                    int reorder = Int32.Parse(nudReorderThreshold.Value.ToString());
                    int maxReoder = Int32.Parse(nudMaxReorder.Value.ToString());
                    int itemID = Int32.Parse(txtItemID.Text);
                    int siteID = Int32.Parse(txtSiteID.Text);

                    //Update product
                    this.inventoryTableAdapter.Update1(quantity, txtItemLocation.Text, reorder, maxReoder, itemID, siteID);
                    MessageBox.Show("Product updated", "Feedback");
                }

            }
            else if(grpCreateLoss.Visible == true)
            {
                //check if notes exists
                if(txtExplanatoryNote.Text != "")
                {
                    //Get product
                    int itemID = Int32.Parse(txtItemId2.Text);

                    //Set param
                    int siteIDTo = user.siteID;
                    string status = Utils.statusSubmmited; // ????
                    DateTime createdDate = DateTime.Parse(DateTime.Now.ToString("yyyy/MM/d hh:mm:ss"));
                    DateTime shipDate = DateTime.Parse(Utils.FindShipDate().ToShortDateString());
                    shipDate = DateTime.Parse(shipDate.ToString("yyyy/MM/d"));
                    string txnType = radLoss.Checked? Utils.loss: Utils.damage;
                    int emergencyDelivery = 0;
                    string barCode = "111222333444";
                    deliveryID = 1;
                    
                    //create new list and add the new product
                    List<txnItems> itemsList = new List<txnItems>();

                    itemsList.Add(new txnItems(itemID, Int32.Parse(nudLossItemQuantity.Value.ToString())));

                    //Update status and create loss
                    CreateTxn(siteIDTo, status, shipDate, txnType, barCode, createdDate, emergencyDelivery, itemsList);

                    //Audit Activity
                    Utils.Audit(txnID, txnType, status, createdDate, user.siteID, deliveryID);
                    //return feedback
                    MessageBox.Show("A new order is created for the loss item", "Loss Order");
                    //clean and hide group box
                    btnDiscardLoss.PerformClick();

                }
            }

            //Update table and clean box
            btnDiscardInventoryEdit.PerformClick();
        }

        private void btnDiscardInventoryEdit_Click(object sender, EventArgs e)
        {
            //hide group box
            grpEditInventory.Visible = false;
            //set buttons
            btnSaveInventory.Enabled = false;
            btnEditInventory.Enabled = false;
            btnAddProduct.Enabled = true;
            //set textboxes to read only
            txtItemID.ReadOnly = true;
            txtSiteID.ReadOnly = true;
            //Clear all text
            txtItemID.Clear();
            txtSiteID.Clear();
            txtItemLocation.Clear();
            //reset values
            nudReorderThreshold.Value = nudReorderThreshold.Minimum;
            nudMaxReorder.Value = nudMaxReorder.Minimum;
            nudQuantity.Value = nudQuantity.Minimum;
            //refresh table
            this.inventoryTableAdapter.FillBySite(this.bullseyedb2022DataSet.inventory, user.siteID);
        }

        private void btnDiscardLoss_Click(object sender, EventArgs e)
        {
            //refresh table and product attributes
            btnDiscardInventoryEdit.PerformClick();
            //hide groupo box
            grpCreateLoss.Visible = false;
            //clear text
            txtItemId2.Clear();
            txtExplanatoryNote.Clear();

        }


        /// <summary>
        /// Sites tab
        /// </summary>
        private void btnNewLocation_Click(object sender, EventArgs e)
        {
            //check permision
            if (Utils.CheckPermissions(Utils.permissionAddLocation))
            {
                grpAddLocation.Visible = true;
                btnSaveSites.Enabled = true;
                btnNewLocation.Enabled = false;
            }
            else { MessageBox.Show("You do not have permission to add a location", "Alert!"); }
        }


        private void btnNewLocationDiscard_Click(object sender, EventArgs e)
        {
            //clear boxes
            txtNewLocationName.Clear();
            txtNewLocationAddress.Clear();
            txtNewLocationAddress2.Clear();
            txtNewLocationPostal.Clear();
            txtNewLocationCountry.Clear();
            txtNewLocationCity.Clear();
            cboNewLocationProvince.SelectedIndex = -1;
            txtNewLocationPhone.Clear();
            cboNewLocationWeekDay.SelectedIndex = -1;
            txtNewLocationWHDistance.Clear();
            txtNewLocationNotes.Clear();

            //make groupbox invisible and enable button
            grpAddLocation.Visible = false;
            btnSaveSites.Enabled = false;
            btnNewLocation.Enabled = true;
        }


        private void btnSaveSites_Click(object sender, EventArgs e)
        {
            string name, address, address2, postal, country, city, province, phone, weekday, notes;

            name = txtNewLocationName.Text;
            address = txtNewLocationAddress.Text;
            address2 = txtNewLocationAddress2.Text;
            postal = txtNewLocationPostal.Text;
            country = txtNewLocationCountry.Text;
            city = txtNewLocationCity.Text;
            province = cboNewLocationProvince.Text;
            phone = txtNewLocationPhone.Text;
            weekday = cboNewLocationWeekDay.Text;
            int warehouseDistance = Int32.Parse(txtNewLocationWHDistance.Text);
            notes = txtNewLocationNotes.Text;
            //this.siteTableAdapter.InsertLocation(name, address, address2, postal, country, city, province, phone, weekday, warehouseDistance, notes);

            try
            {
                conn.Open();
                MySqlCommand userPass = new MySqlCommand(
                    "INSERT INTO site(name, provinceID, address, address2, city, country, postalCode, phone, dayOfWeek, distanceFromWH, notes) " +
                    "values('" + name + "', '" + province + "', '" + address + "', '" + address2 + "', '" + city + "', '" + country + "', '" + postal + "', '" + phone + "', '" + weekday + "', " + warehouseDistance + ", '" + notes + "')", conn);
                userPass.ExecuteReader();
                conn.Close();
            }
            catch { MessageBox.Show("Erro adding location. Did you fill every box?", "Erro"); }
        }

        private void siteDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            btnEditSites.Enabled = true;
        }

        /// <summary>
        /// Products tab
        /// </summary>


        private void btnEditProducts_Click(object sender, EventArgs e)
        {
            chkNewItemActive.Visible = true;
            int position = this.itemBindingSource.Position;
            int count = 0;
            foreach (DataRow row in this.bullseyedb2022DataSet.item)
            {
                if (count == position)
                {
                    itemID = Int32.Parse(row["itemID"].ToString());   
                    txtNewItemName.Text = row["name"].ToString();
                    cboNewItemCategory.Text = row["category"].ToString();
                    txtNewItemDescription.Text = row["description"].ToString();
                    txtNewItemNotes.Text = row["notes"].ToString();
                    nudNewItemSKU.Value = Int32.Parse(row["sku"].ToString());
                    txtNewItemSupplierID.Text = row["supplierID"].ToString();
                    nudNewItemSize.Value = Int32.Parse(row["caseSize"].ToString());
                    chkNewItemActive.Checked = Boolean.Parse(row["active"].ToString());
                    nudNewItemWeight.Value = Decimal.Parse(row["weight"].ToString());
                    nudNewItemCostPrice.Value = Decimal.Parse(row["costPrice"].ToString());
                    nudNewItemRetailPrice.Value = Decimal.Parse(row["retailPrice"].ToString());

                    grpAddProduct.Visible = true;

                    break;
                }
                count++;
            }
        }


        private void btnNewProduct_Click(object sender, EventArgs e)
        {
            //check permision
            if (Utils.CheckPermissions(Utils.permissionAddNewProduct))
            {
                //make groupbox visible and disable button
                grpAddProduct.Visible = true;
                btnSaveSites.Enabled = true;
                btnNewProduct.Enabled = false;
                //lblUserName.Text = this.itemTableAdapter.MaxSKU();
                nudNewItemSKU.Value = Int32.Parse(this.itemTableAdapter.MaxSKU()) + 1;

            }
            else { MessageBox.Show("You do not have permission to add a new product", "Alert!"); }
        }


        private void btnDiscardNewProduct_Click(object sender, EventArgs e)
        {
            //clear boxes
            txtNewItemName.Clear();
            nudNewItemSKU.Value = 60000;
            cboNewItemCategory.SelectedIndex = -1;
            nudNewItemWeight.Value = 5;
            nudNewItemCostPrice.Value = nudNewItemCostPrice.Minimum;
            nudNewItemRetailPrice.Value = nudNewItemRetailPrice.Minimum;
            txtNewItemSupplierID.Clear();
            nudNewItemSize.Value = nudNewItemSize.Minimum;
            txtNewItemDescription.Clear();
            txtNewItemNotes.Clear();

            chkNewItemActive.Checked = false;
            chkNewItemActive.Visible = false;

            //make groupbox invisible and enable button
            btnNewProduct.Enabled = true;
            grpAddProduct.Visible = false;
            btnSaveInventory.Enabled = false;

            //refresh table
            this.itemTableAdapter.Fill(this.bullseyedb2022DataSet.item);
        }

        private void btnSaveProducts_Click(object sender, EventArgs e)
        {
            //get variables
            string name = "", category = "", description = "", notes = "", sku = "";
            int supplierID = 0, size = 1, active = 1;
            decimal weight = 1, costPrice = 1, retailPrice= 1;
            try
            {
                if (txtNewItemName.Text == "") { MessageBox.Show("You need to fill the Name box", "Alert!"); return; }
                else
                {
                    if (cboNewItemCategory.Text == "") { MessageBox.Show("You need to fill the Category box", "Alert!"); return; }
                    else
                    {
                        if (txtNewItemSupplierID.Text == "") { MessageBox.Show("You need to fill the SupplierID box", "Alert!"); return; }
                        else
                        {
                            name = txtNewItemName.Text;
                            sku = nudNewItemSKU.Value.ToString();
                            weight = (decimal)nudNewItemWeight.Value;
                            costPrice = (decimal)nudNewItemCostPrice.Value;
                            retailPrice = (decimal)nudNewItemRetailPrice.Value;
                            category = cboNewItemCategory.Text;
                            size = (int)nudNewItemSize.Value;
                            description = txtNewItemDescription.Text;
                            notes = txtNewItemNotes.Text;
                            supplierID = Int32.Parse(txtNewItemSupplierID.Text);
                        }
                    }
                }
                


            }
            finally
            {

                //check if is an update or an new product
                if(chkNewItemActive.Visible == true)
                {

                    active = chkNewItemActive.Checked? 1: 0;
                    try
                    {
                        //update product
                        this.itemTableAdapter.UpdateProduct(name, sku, description, category, weight, costPrice, retailPrice, supplierID, active, notes, size, itemID);
                    }
                    catch
                    {
                        MessageBox.Show("Erro creating new product. Did you fill every box?", "Erro");
                    }
                }
                else
                {
                    try
                    {
                        //insert new product
                        this.itemTableAdapter.InsertNewProduct(name, sku, description, category, weight, costPrice, retailPrice, supplierID, active, notes, size);
                    }
                    catch
                    {
                        MessageBox.Show("Erro creating new product. Did you fill every box?", "Erro");
                    }
                }


                //clear groupbox and layout
                btnDiscardNewProduct.PerformClick();
            }

        }

        private void dgvItemPTAB_SelectionChanged(object sender, EventArgs e)
        {
            btnEditProducts.Enabled = true;
        }


        /// <summary>
        /// Reports tab
        /// </summary>

        private void txnauditDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            btnEditReports.Enabled = true;
        }

        private void btnEditReports_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab.Name.ToString() == Utils.reportsTab)
            {
                if (Utils.CheckPermissions(Utils.permissionModifyRecord))
                {

                    txnID = 0;
                    int position = this.txnauditBindingSource.Position;
                    int count = 0;
                    foreach (DataRow row in this.bullseyedb2022DataSet.txnaudit)
                    {
                        if (count == position)
                        {
                            txnID = Int32.Parse(row["txnID"].ToString());
                            break;
                        }
                        count++;
                    }

                    conn.Open();
                    MySqlCommand userPass = new MySqlCommand("select txnID from txn WHERE txnType in ('Store Order', 'Back Order', 'Supplier Order') and txnID = " +  txnID, conn);
                    MySqlDataReader reader = userPass.ExecuteReader();

                    if (reader.Read())
                    {
                        grpEditReport.Visible = true;
                        this.txnTableAdapter.FillEdit(this.bullseyedb2022DataSet.txn, txnID);
                        btnSaveReports.Enabled = true;

                    }
                    else MessageBox.Show("The order must be one of the following types: Store orders, Back Orders or Supplier orders", "Alert");
                    conn.Close();
                }
                else { MessageBox.Show("You do not have permission to edit a transaction", "Alert!"); }
                //close conn
                //conn.Close();

            }

        }

        private void btnSaveReports_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The changes in transactions number " + txnID + " are saved!", "Changes completed");
            //  siteIDFrom = @p2, status = @p3, shipDate = @p4, txnType = @p5, barCode = @p6, deliveryID = @p8, emergencyDelivery = @p9
            int siteIDFrom = Int32.Parse(siteIDFromTextBox.Text);
            string status = statusTextBox.Text;
            DateTime shipdate = DateTime.Parse(shipDateDateTimePicker.Value.ToString("yyyy-MM-dd"));
            string txnTYpe = txnTypeTextBox.Text;
            string barcode = barCodeTextBox.Text;
            int deliveryID = Int32.Parse(deliveryIDTextBox.Text);
            bool EO = emergencyDeliveryCheckBox.Checked;

            this.txnTableAdapter.UpdateTxn(siteIDFrom, status, shipdate, txnTYpe, barcode, deliveryID, EO, txnID);

            grpEditReport.Visible = false;
            btnEditReports.Enabled = false;
        }

        private void btnDiscardEditReports_Click(object sender, EventArgs e)
        {
            grpEditReport.Visible = false;
            btnEditReports.Enabled = false;
            btnSaveReports.Enabled = false;
        }

        private void btnCancelTxn_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("The txn number " + txnID + " will be cancelled, you sure you want to continue?", "Review Txn Cancelation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if(res == DialogResult.OK)
            {
                this.txnTableAdapter.UpdateStatus(Utils.statusCancelled, txnID);
                grpEditReport.Visible = false;
                btnEditReports.Enabled = false;
                btnSaveReports.Enabled = false;
            }
        }

        private void CreateNewOrder()
        {

            //Create new order
            CreateTxn(t.siteIDTo, t.status, t.shipDate, t.txnType, t.barcode, t.createdDate, t.emergencyDelivery, productList);


            //clear product list
            productList.Clear();

            //Audit activity
            Utils.Audit(txnID, t.txnType, t.status, t.createdDate, user.siteID, t.deliveryID);

        }

        private void CreateTxn(int siteIDTo, string status, DateTime shipDate, string txnType, string barCode, DateTime createdDate, int emergencyDelivery, List<txnItems> itemsList)
        {
            conn.Open();
            //get shipDate
            shipDate = Utils.FindShipDate();
            //lblUserName.Text = itemsList[0].itemID.ToString();
            deliveryID = 1;
            //Try to find any delivery scheduled in the next days
            if (!Utils.CheckScheduledDelivery())
            {
                //Instantiate txn
                t = new Txn(user.siteID, siteIDTo, status, shipDate, txnType, barCode, createdDate, deliveryID, emergencyDelivery);

                //Create new order
                MySqlCommand userPass = new MySqlCommand("INSERT INTO txn (siteIDTo, siteIDFrom, status, shipDate, txnType, barCode, createdDate, deliveryID, emergencyDelivery) VALUES (" + t.siteIDTo+ ", " + t.siteIDFrom +", '" + t.status+ "', '" + shipDate.ToString("yyyy-MM-dd")+"', '" + t.txnType+"', '" + t.barcode +"', '" + t.createdDate.ToString("yyyy-MM-dd HH:mm:ss") +"', " + t.deliveryID+", " + t.emergencyDelivery+")", conn);
                userPass.ExecuteReader();
                conn.Close();

                //Get last txnID
                txnID = Int32.Parse(this.txnTableAdapter.ReturnLastTxnID().ToString());

                //Fill txnItems for the txnID
                foreach (txnItems item in itemsList)
                {
                    this.txnitemsTableAdapter.NewItemsList(txnID, item.itemID, item.quantity);
                }

                //Get total weight
                FindTotalWeight();

                //Get deliveryID
                deliveryID = Utils.NewDelivery(weight);

                //Update txn
                conn.Open();
                userPass = new MySqlCommand(" UPDATE txn SET deliveryID = " + deliveryID + ", shipDate = " + shipDate.ToString("yyyy-MM-d HH:mm:ss") + " WHERE txnID = " + txnID, conn);
                userPass.ExecuteReader();
                conn.Close();


            }
            //The method return the deliveryID whithin the global variable deliveryID
            else
            {
                //Instantiate txn
                t = new Txn(user.siteID, siteIDTo, status, shipDate, txnType, barCode, createdDate, deliveryID, emergencyDelivery);

                //Create new order
                MySqlCommand userPass = new MySqlCommand("INSERT INTO txn (siteIDTo, siteIDFrom, status, shipDate, txnType, barCode, createdDate, deliveryID, emergencyDelivery) VALUES (" + t.siteIDTo + ", " + t.siteIDFrom + ", '" + t.status + "', '" + shipDate.ToString("yyyy-MM-dd") + "', '" + t.txnType + "', '" + t.barcode + "', '" + t.createdDate.ToString("yyyy-MM-dd HH:mm:ss") + "', " + t.deliveryID + ", " + t.emergencyDelivery + ")", conn);
                userPass.ExecuteReader();


                //Get last txnID
                txnID = Int32.Parse(this.txnTableAdapter.ReturnLastTxnID().ToString());

                //Fill txnItems for the txnID
                foreach (txnItems item in itemsList)
                {
                    this.txnitemsTableAdapter.NewItemsList(txnID, item.itemID, item.quantity);
                }

                conn.Close();
            }
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            //check permision
            if (Utils.CheckPermissions(Utils.permissionCreateReports))
            {
                Reports r = new Reports();
                r.ShowDialog();

            }
            else { MessageBox.Show("You do not have permission to access this tab", "Alert!"); }
        }
    }


    /*
    //check permision
    if (Utils.CheckPermissions(Utils.))
    {

    }
    else { MessageBox.Show("You do not have permission to access this tab", "Alert!"); }



    /* string name = nameTextBox.Text;
    int sku = Int32.Parse(skuTextBox.Text);
    string description = descriptionTextBox.Text;
    string category = categoryTextBox.Text;
    double weight = Double.Parse(weightTextBox.Text);
    double retailPrice = Double.Parse(retailPriceTextBox.Text);
    int supplierID = Int32.Parse(supplierIDTextBox.Text);
    bool active = activeCheckBox.Checked;
    string notes = notesTextBox.Text;
    int caseSize = Int32.Parse(caseSizeTextBox.Text);


    conn.Open();
    MySqlCommand userPass = new MySqlCommand("select name from site", conn);
    MySqlDataReader reader = userPass.ExecuteReader();
    //clear list
    cboSites.Items.Clear();
                
    while (reader.Read())
    {
        cboSites.Items.Add(reader["name"]);
    }
    cboSites.Items.Add("All Sites");
    conn.Close();


    
        //public static int siteIDFrom;
        public static int siteIDTo;
        public static string status;
        public static DateTime shipDate;
        public static string txnType;
        public static string barCode;
        public static DateTime createdDate;
        public static int emergencyDelivery;
        public static int deliveryID;

        

        //Display how many order is available for driver
        conn.Open();
        MySqlCommand userPass = new MySqlCommand("SELECT txnID, emergencyDelivery FROM txn WHERE status in('" + Utils.statusAssembled + "', '" + Utils.statusInTransit + "')", conn);
        MySqlDataReader reader = userPass.ExecuteReader();
        while (reader.Read())
        {
            //count orders
            if(reader["emergencyDelivery"].ToString() == "1")
            {
                countEO++;
            }
            else countOrders++;
        }
        conn.Close();

        
    
    
                DialogResult res = MessageBox.Show("?", "Review Request", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (res == DialogResult.OK)
                {
                    
                }
            
    */
}
