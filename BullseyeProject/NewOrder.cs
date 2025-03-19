using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BullseyeProject
{
    public partial class NewOrder : Form
    {
        public NewOrder()
        {
            InitializeComponent();
        }

        //txn Fields
        List<txnItems> productList = new List<txnItems>();
        public static int siteIDFrom;
        public static int siteIDTo;
        public static string status;
        public static DateTime shipDate;
        public static string txnType;
        public static string barCode;
        public static DateTime createdDate;
        public static int emergencyDelivery = 0; // 1 = true
        public static int deliveryID;

        public Txn t;


        //Dataset connection. Logged to my sql account
        static string connString = "server=localhost;database=bullseyedb2022;" +
           "userid=Rodrigo;password=rororo0808";
        MySqlConnection conn = new MySqlConnection(connString);

        //New order button
        private void NewOrder_Load(object sender, EventArgs e)
        {
            //Fill site fields
            siteIDFrom = Main.user.siteID;
            
            //clear product list
            productList.Clear();

            // Items table
            //Only active items
            this.itemTableAdapter.FillByActive(this.bullseyedb2022DataSet.item);
            lstProductList.Text = "Qtd\tProduct\t\t\tCost";




            if(Main.user.positionID == Utils.storeClerkPosn || Main.user.positionID == Utils.storeManagerPosn)
            {

                //check if its an update
                if(Main.updateOrder == Utils.updateOrder)
                {
                    productList = Main.productList;
                    
                }

                //check if there emergency orders available
                if(Main.countEO == 1)
                {
                    btnEO.Enabled = false;
                }
                else if (Main.countOrders == 1 && Main.countEO == 0)
                {
                    emergencyDelivery = 1;
                }


                DialogResult res = MessageBox.Show("Do you wish to add all low stock product to this order?", "Review Request", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (res == DialogResult.OK)
                {
                    AddLowStockToProductList();
                }

            }
            else if (Main.user.positionID == Utils.warehouseManagerPosn)
            {

                DialogResult res = MessageBox.Show("Do you wish to add all low stock product to this order?", "Review Request", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (res == DialogResult.OK)
                {
                    AddLowStockToProductList();
                }

            }

            //refresh table
            FillProductList();

            //Fill combobox with low stock products
            CheckReorderThreshold();
        }

        /// <summary>
        /// Buttons methods
        /// </summary>
        /// 

        //Add selected item into list of products
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //check if products comes from combobox
            if(cboSuggestedItems.SelectedIndex != -1)
            {
                cboSuggestedItems.Items.Remove(cboSuggestedItems.SelectedItem);
            }

            int itemID = Int32.Parse(itemIDTextBox.Text);
            int quantity = (int)nudProductQuantity.Value;

            double costPrice = Convert.ToDouble(costPriceTextBox.Text);
            double totalCost = quantity * costPrice;
            txnItems t = new txnItems(itemID, totalCost, nameTextBox.Text, quantity);

            //Add txnItem object to list
            productList.Add(t);

            //Refresh table
            FillProductList();

            //Refresh value
            nudProductQuantity.Value = 1;
        }

        //Remove item from listbox
        private void btnRemove_Click_1(object sender, EventArgs e)
        {
            int index = lstProductList.SelectedIndex;
            if (index > 0)
            {
                productList.RemoveAt(index - 1);
            }

            FillProductList();

            nudProductQuantity.Value = 1;
        }

        //Show the filter options
        private void btnFilterItems_Click(object sender, EventArgs e)
        {
            if (grpFilterItems.Visible)
            {
                grpFilterItems.Visible = false;
            }
            else 
            {
                grpFilterItems.Visible = true;
                
                conn.Open();
                MySqlCommand userPass = new MySqlCommand("SELECT categoryName FROM category", conn);
                MySqlDataReader reader = userPass.ExecuteReader();
                //clear list
                cboCategory.Items.Clear();
                while (reader.Read())
                {
                    //Fill comboBox and count order
                    cboCategory.Items.Add(reader["categoryName"]);
                }
                conn.Close();
            } 
        }

        //Clean all boxes
        //Turn off filter box
        private void btnDiscard_Click(object sender, EventArgs e)
        {
            grpFilterItems.Visible = false;
            txtProductName.Clear();

            this.itemTableAdapter.FillByActive(this.bullseyedb2022DataSet.item);
        }

        //Get boxes values
        //filter table with 
        private void btnSearch_Click(object sender, EventArgs e)
        {

            if (cboCategory.SelectedIndex == -1)
            {
                //lblTest4.Text = "name";
                string name = txtProductName.Text;
                this.itemTableAdapter.FillByName(this.bullseyedb2022DataSet.item, name);
            }
            else if(txtProductName.Text == "")
            {
                string category = cboCategory.Text;
                this.itemTableAdapter.FillByCategory(this.bullseyedb2022DataSet.item, category);
            }
            else
            {
                string name = txtProductName.Text;
                string category = cboCategory.Text;
                this.itemTableAdapter.FillByNameAndCategory(this.bullseyedb2022DataSet.item, name, category);
            }

        }
        //Finish the order
        //Send all field value to main form
        private void btnFinishOrder_Click(object sender, EventArgs e)
        {
            if (lstProductList.Items.Count > 1)
            {
                DialogResult res = MessageBox.Show("Are you sure you want to summit?\n", "Review Order Products", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (res == DialogResult.OK)
                {
                    siteIDTo = 2; //1= truck,  2= warehouse
                    //set up the status and txnType
                    //siteIDFrom == 2
                    if (Main.user.positionID == Utils.warehouseManagerPosn)
                    {
                        status = Utils.statusPendingBackOrder;
                        txnType = Utils.supplierOrder;
                    }
                    else 
                    {
                        status = Utils.statusSubmmited;
                        txnType = Utils.storeOrder;
                    }


                    shipDate = DateTime.Parse(DateTime.Now.ToString("yyyy/MM/d"));
                    createdDate = DateTime.Parse(DateTime.Now.ToString("yyyy/MM/d hh:mm:ss"));
                    barCode = "111222333444";
                    deliveryID = 1;

                    t = new Txn(Main.user.siteID, siteIDTo, status, shipDate, txnType, barCode, createdDate, deliveryID, emergencyDelivery);
                    Main.t = this.t;
                    Main.productList = this.productList;

                    this.Close();
                }
            }
            else this.Close();

        }

        //Add all item within the product List
        private void FillProductList()
        {
            //clear text
            lstProductList.Items.Clear();
            //fill text
            lstProductList.Items.Add("Qtd\tProduct\t\t\tCost");

            foreach (txnItems product in productList)
            {
                lstProductList.Items.Add(product.ToString());
            }
        }



        //When comboBox change selected, fill items table with item selected
        private void cboSuggestedItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboSuggestedItems.SelectedIndex != -1)
            {
                int itemID = Int32.Parse(cboSuggestedItems.SelectedItem.ToString());
                this.itemTableAdapter.FillByItemID(this.bullseyedb2022DataSet.item, itemID);
            }
            else
            {
                this.itemTableAdapter.FillByActive(this.bullseyedb2022DataSet.item);
            }
        }


        private void CheckReorderThreshold()
        {
            //Fill comboBox sites
            conn.Open();
            MySqlCommand userPass = new MySqlCommand("select itemID from inventory WHERE reorderThreshold > quantity and siteID  = " + siteIDFrom, conn);
            MySqlDataReader reader = userPass.ExecuteReader();
            //clear list
            cboSuggestedItems.Items.Clear();

            while (reader.Read())
            {
                cboSuggestedItems.Items.Add(reader["itemID"]);
            }
            conn.Close();
        }

        private void AddLowStockToProductList()
        {
            //Fill comboBox sites
            conn.Open();
            MySqlCommand userPass = new MySqlCommand("select itemID, quantity, costPrice, reorderThreshold, maxReorderWarning from inventory  INNER JOIN item USING (itemID) WHERE (reorderThreshold > quantity and siteID  = " + siteIDFrom + " )", conn);
            MySqlDataReader reader = userPass.ExecuteReader();

            while (reader.Read())
            {
                int itemID = Int32.Parse(reader["itemID"].ToString());
                int quantity = Int32.Parse(reader["maxReorderWarning"].ToString()) - Int32.Parse(reader["quantity"].ToString());

                double costPrice = Convert.ToDouble(reader["costPrice"].ToString());
                double totalCost = quantity * costPrice;

                txnItems t = new txnItems(itemID, totalCost, nameTextBox.Text, quantity);

                //Add txnItem object to list
                productList.Add(t);
            }
            conn.Close();
            //refresh atable
            FillProductList();
        }


        //Binding Navigator Save click
        private void itemBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.itemBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.bullseyedb2022DataSet);

        }

        //When any row in table is selected, turn Add button on, and Remove Button off
        private void itemDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            btnAdd.Enabled = true;
            btnRemove.Enabled = false;
        }

        //When any row in listBox is selected, turn Add button off, and Remove Button on
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAdd.Enabled = false;
            btnRemove.Enabled = true;
        }

        private void btnEO_Click(object sender, EventArgs e)
        {
            if (lstProductList.Items.Count > 1)
            {
                DialogResult res = MessageBox.Show("Are you sure you want to set this order as an Emergency?\n", "Emergency Order", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (res == DialogResult.OK)
                {
                    emergencyDelivery = 1;
                }
            }
        }
    }
}
