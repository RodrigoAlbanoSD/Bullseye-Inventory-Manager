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
    public partial class Reports : Form
    {
        private string reportType;
        private int siteID = -1;
        private DateTime dateFrom;
        private DateTime dateTo;
        private List<string> reportList;
        public Reports()
        {
            InitializeComponent();
        }

        //Dataset connection. Logged to my sql account
        static string connString = "server=localhost;database=bullseyedb2022;" +
           "userid=Rodrigo;password=rororo0808";
        MySqlConnection conn = new MySqlConnection(connString);

        private void Reports_Load(object sender, EventArgs e)
        {
            //Fill available stores into comboBox. Only select stores
            conn.Open();
            MySqlCommand userPass = new MySqlCommand("select name, siteID from site", conn);
            MySqlDataReader reader = userPass.ExecuteReader();
            //clear list
            cboAvailableStores.Items.Clear();
            cboAvailableStores.Items.Add("All Sites");

            while (reader.Read())
            {
                if(Int32.Parse(reader["siteID"].ToString()) >= 4)
                {
                    cboAvailableStores.Items.Add(reader["siteID"].ToString() + " " + reader["name"].ToString());
                }
                
            }
            conn.Close();
        }

        //Add all rows in listBox
        private void FillProductList()
        {
            //clear text
            lstReports.Items.Clear();
            //fill text
            //lstReports.Items.Add(reportList);
            // lstReports.Items.Add(reportType + "\t\t\t From: " + dateFrom.ToString("d-MM")+ "\t To: " + dateTo.ToString("d-MM"));

            foreach (string row in reportList)
            {
                lstReports.Items.Add(row);
            }
        }
        private void cboReportsTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            //get report type
            reportType = cboReportsTypes.SelectedItem.ToString();
            switch (reportType)
            {
                case "Delivery Reports": DeliveryReports(); break;
                //case "Store Order": StoreOrder(); break;
                case "Shipping Receipt": break;
                //case "Supplier Order": SupplierOrder(); break;
                case "Users": break; //do nothing
                default: grpAvailableStores.Visible = true; break;
                /*case "Inventory": grpAvailableStores.Visible = true; break;
                case "Sale": grpAvailableStores.Visible = true; break;
                case "Orders": grpAvailableStores.Visible = true; break;
                case "Emergency Orders": grpAvailableStores.Visible = true; break;
                case "Backorders": grpAvailableStores.Visible = true; break;*/
                
            }

        }
        private void cboAvailableStores_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboAvailableStores.SelectedIndex == 0)
            {
                siteID = 999;
            }
            else
            {
                siteID = Int32.Parse(cboAvailableStores.SelectedItem.ToString().Split(' ')[0]);
            }
        }
        private void btnSeach_Click(object sender, EventArgs e)
        {
            
            dateFrom = dtpFrom.Value;
            dateTo = dtpTo.Value;
            reportList = new List<string>();
            switch (reportType)
            {
                case "Delivery Reports": DeliveryReports(); break;
                case "Store Order": StoreOrder(); break;
                case "Shipping Receipt": ShippingReceipt(); break;
                case "Inventory": Inventory(); break;
                case "Sale": Sale(); break;
                case "Orders": Orders(); break;
                case "Emergency Orders": EmergencyOrders(); break;
                case "Users": Users(); break;
                case "Backorders": Backorders(); break;
                case "Supplier Order": SupplierOrder(); break;
            }

            grpAvailableStores.Visible = false;
            grpWeekDays.Visible = false;
        }

        private void DeliveryReports(){
            if(cboWeekDay.SelectedIndex == -1) { MessageBox.Show("You should select a day", "Alert"); return; }
            conn.Open();
            MySqlCommand userPass = new MySqlCommand("select t.txnID, t.siteIDTo, s.dayOfWeek from txn t, site s where dayOfWeek = '" + cboWeekDay.SelectedItem.ToString().ToUpper() + "' and t.siteIDTo = s.siteID", conn);
            MySqlDataReader reader = userPass.ExecuteReader();
            reportList.Add("txn \t siteIDTo \t day of week ");
            while (reader.Read())
            {
                reportList.Add(String.Format("{0, 2} \t {1, 2} \t {2, 10} ", reader["t.txnID"].ToString(), reader["t.siteIDTo"].ToString(), reader["s.dayOfWeek"].ToString()));
            }

            conn.Close();
            FillProductList();
        }
        private void StoreOrder()
        {

            FillProductList();
        }
        private void ShippingReceipt()
        {
            conn.Open();
            MySqlCommand userPass = new MySqlCommand("select txnID, siteIDTo, status, txnType FROM txn WHERE status = 'Delivered' and shipDate between '" + dateFrom.ToString("yyyy-MM-d") + "' and '" + dateTo.ToString("yyyy-MM-d") + "'", conn);
            MySqlDataReader reader = userPass.ExecuteReader();
            reportList.Add("txn \t siteIDTo \t status \t\t txnType");
            while (reader.Read())
            {
                reportList.Add(String.Format("{0, 2} \t {1, 2} \t {2, 10} \t {3, 13}", reader["txnID"].ToString(), reader["siteIDTo"].ToString(), reader["status"].ToString(), reader["txnType"].ToString()));
            }

            conn.Close();
            FillProductList();
        }
        private void Inventory()
        {
            //get data
            conn.Open();
            if(siteID == -1 )
            {
                MessageBox.Show("You should select a store", "Alert");
                conn.Close();
                return;
            }
            else if(siteID == 999)
            {
                MySqlCommand userPass = new MySqlCommand("select itemID, name, quantity, siteID FROM inventory INNER JOIN item USING (itemID)", conn);
                MySqlDataReader reader = userPass.ExecuteReader();
                reportList.Add("ItemID \t\t\t Product Name \t\t Quantity \t\tSite");
                while (reader.Read())
                {
                    reportList.Add(String.Format("{0, 3} {1, 60} \t {2, 6} \t\t {3, 6}", reader["itemID"].ToString(), reader["name"].ToString(), reader["quantity"].ToString(), reader["siteID"].ToString()));
                }
            }
            else
            {
                MySqlCommand userPass = new MySqlCommand("select itemID, name, quantity FROM inventory INNER JOIN item USING (itemID) WHERE siteID = " + siteID, conn);
                MySqlDataReader reader = userPass.ExecuteReader();
                reportList.Add("ItemID \t\t\t Product Name \t\t Quantity");
                while (reader.Read())
                {
                    reportList.Add(String.Format("{0, 3} {1, 60} \t {2, 3}", reader["itemID"].ToString(), reader["name"].ToString(), reader["quantity"].ToString()));
                }
            }
            conn.Close();

            //Fill list
            FillProductList();

        }
        private void Sale()
        {
            //get data
            conn.Open();
            if (siteID == -1)
            {
                MessageBox.Show("You should select a store", "Alert");
                conn.Close();
                return;
            }
            else if (siteID == 999)
            {
                MySqlCommand userPass = new MySqlCommand("select txnID, status, shipDate, createdDate, siteIDTo FROM txn WHERE txnType = 'Sale'", conn);
                MySqlDataReader reader = userPass.ExecuteReader();
                reportList.Add("txnID \t Site \t createdDate \t shipDate \t\t status");
                while (reader.Read())
                {
                    DateTime s = DateTime.Parse(reader["shipDate"].ToString());
                    DateTime c = DateTime.Parse(reader["createdDate"].ToString());
                    reportList.Add(String.Format("{0, 3} \t {1, 3} \t {2, 13} \t {3, 13} \t {4, 10}", reader["txnID"].ToString(), reader["siteIDTo"].ToString(), c.ToString("yyyy-MM-d"), s.ToString("yyyy-MM-d"), reader["status"].ToString()));
                }
            }
            else
            {
                MySqlCommand userPass = new MySqlCommand("select txnID, status, shipDate, createdDate FROM txn WHERE siteIDTo = " + siteID, conn);
                MySqlDataReader reader = userPass.ExecuteReader();
                reportList.Add("txnID \t createdDate \t shipDate \t\t status");
                while (reader.Read())
                {
                    DateTime s = DateTime.Parse(reader["shipDate"].ToString());
                    DateTime c = DateTime.Parse(reader["createdDate"].ToString());
                    reportList.Add(String.Format("{0, 3} \t {1, 13} \t {2, 13} \t {3, 3}", reader["txnID"].ToString(), c.ToString("yyyy-MM-d"), s.ToString("yyyy-MM-d"), reader["status"].ToString()));
                }
            }
            conn.Close();

            //Fill list
            FillProductList();
        }
        private void Orders()
        {
            //get data
            conn.Open();
            if (siteID == -1)
            {
                MessageBox.Show("You should select a store", "Alert");
                conn.Close();
                return;
            }
            else if (siteID == 999)
            {
                MySqlCommand userPass = new MySqlCommand("select txnID, txnType, status, shipDate, createdDate, siteIDTo, siteIDFrom FROM txn WHERE txnType not in('Sale', 'Back Order') and emergencyDelivery = 0", conn);
                MySqlDataReader reader = userPass.ExecuteReader();
                reportList.Add("txnID \t Site From\tSite To \t createdDate \t shipDate \t\t Type \t\t status");
                while (reader.Read())
                {
                    DateTime s = DateTime.Parse(reader["shipDate"].ToString());
                    DateTime c = DateTime.Parse(reader["createdDate"].ToString());
                    reportList.Add(String.Format("{0, 3} \t {2, 4} \t {3, 4} \t {4, 11} \t {5, 11} \t {6, 12} \t{1,10}", reader["txnID"].ToString(), reader["txnType"].ToString(), reader["siteIDFrom"].ToString(), reader["siteIDTo"].ToString(), c.ToString("yyyy-MM-d"), s.ToString("yyyy-MM-d"), reader["status"].ToString()));
                }
            }
            else
            {
                MySqlCommand userPass = new MySqlCommand("select txnID, txnType, status, shipDate, createdDate, siteIDTo FROM txn WHERE txnType not in('Sale', 'Back Order') and emergencyDelivery = 0 and siteIDTo = " + siteID, conn);
                MySqlDataReader reader = userPass.ExecuteReader();
                reportList.Add("txnID \t Type \t\t createdDate \t shipDate \t\t status");
                while (reader.Read())
                {
                    DateTime s = DateTime.Parse(reader["shipDate"].ToString());
                    DateTime c = DateTime.Parse(reader["createdDate"].ToString());
                    reportList.Add(String.Format("{0, 3} \t {1, 12} \t {2, 11} \t {3, 11} \t {4, 3}", reader["txnID"].ToString(), reader["txnType"].ToString(), c.ToString("yyyy-MM-d"), s.ToString("yyyy-MM-d"), reader["status"].ToString()));
                }
            }
            conn.Close();

            //Fill list
            FillProductList();
        }
        private void EmergencyOrders()
        {
            //get data
            conn.Open();
            if (siteID == -1)
            {
                MessageBox.Show("You should select a store", "Alert");
                conn.Close();
                return;
            }
            else if (siteID == 999)
            {
                MySqlCommand userPass = new MySqlCommand("select txnID, txnType, status, shipDate, createdDate, siteIDTo, siteIDFrom FROM txn WHERE txnType not in('Sale', 'Back Order') and emergencyDelivery = 1", conn);
                MySqlDataReader reader = userPass.ExecuteReader();
                reportList.Add("txnID \t Site From\tSite To \t createdDate \t shipDate \t\t Type \t\t status");
                while (reader.Read())
                {
                    DateTime s = DateTime.Parse(reader["shipDate"].ToString());
                    DateTime c = DateTime.Parse(reader["createdDate"].ToString());
                    reportList.Add(String.Format("{0, 3} \t {2, 4} \t {3, 4} \t {4, 11} \t {5, 11} \t {6, 12} \t{1,10}", reader["txnID"].ToString(), reader["txnType"].ToString(), reader["siteIDFrom"].ToString(), reader["siteIDTo"].ToString(), c.ToString("yyyy-MM-d"), s.ToString("yyyy-MM-d"), reader["status"].ToString()));
                }
            }
            else
            {
                MySqlCommand userPass = new MySqlCommand("select txnID, txnType, status, shipDate, createdDate, siteIDTo FROM txn WHERE txnType not in('Sale', 'Back Order') and emergencyDelivery = 1 and siteIDTo = " + siteID, conn);
                MySqlDataReader reader = userPass.ExecuteReader();
                reportList.Add("txnID \t Type \t\t createdDate \t shipDate \t\t status");
                while (reader.Read())
                {
                    DateTime s = DateTime.Parse(reader["shipDate"].ToString());
                    DateTime c = DateTime.Parse(reader["createdDate"].ToString());
                    reportList.Add(String.Format("{0, 3} \t {1, 12} \t {2, 11} \t {3, 11} \t {4, 3}", reader["txnID"].ToString(), reader["txnType"].ToString(), c.ToString("yyyy-MM-d"), s.ToString("yyyy-MM-d"), reader["status"].ToString()));
                }
            }
            conn.Close();

            //Fill list
            FillProductList();
        }
        private void Users()
        {
            conn.Open();
            MySqlCommand userPass = new MySqlCommand("select CONCAT(FirstName, ' ', LastName)  as name, permissionLevel, siteID from employee INNER JOIN posn USING(positionID) ORDER BY siteID", conn);
            MySqlDataReader reader = userPass.ExecuteReader();
            reportList.Add("Site \t\t Position \t\t\t Name");
            while (reader.Read())
            {
                reportList.Add(String.Format("{2, 3} \t {1, 25} \t {0, 25}", reader["name"].ToString(), reader["permissionLevel"].ToString(), reader["siteID"].ToString()));
            }

            conn.Close();
            FillProductList();
        }
        private void Backorders()
        {
            //get data
            conn.Open();
            if (siteID == -1)
            {
                MessageBox.Show("You should select a store", "Alert");
                conn.Close();
                return;
            }
            else if (siteID == 999)
            {
                MySqlCommand userPass = new MySqlCommand("select txnID, txnType, status, shipDate, createdDate, siteIDTo, siteIDFrom FROM txn WHERE txnType in('Back Order') and emergencyDelivery = 0", conn);
                MySqlDataReader reader = userPass.ExecuteReader();
                reportList.Add("txnID \t Site From\tSite To \t createdDate \t shipDate \t\t Type \t\t status");
                while (reader.Read())
                {
                    DateTime s = DateTime.Parse(reader["shipDate"].ToString());
                    DateTime c = DateTime.Parse(reader["createdDate"].ToString());
                    reportList.Add(String.Format("{0, 3} \t {2, 4} \t {3, 4} \t {4, 11} \t {5, 11} \t {6, 12} \t{1,10}", reader["txnID"].ToString(), reader["txnType"].ToString(), reader["siteIDFrom"].ToString(), reader["siteIDTo"].ToString(), c.ToString("yyyy-MM-d"), s.ToString("yyyy-MM-d"), reader["status"].ToString()));
                }
            }
            else
            {
                MySqlCommand userPass = new MySqlCommand("select txnID, txnType, status, shipDate, createdDate, siteIDTo FROM txn WHERE txnType in('Back Order') and emergencyDelivery = 0 and siteIDTo = " + siteID, conn);
                MySqlDataReader reader = userPass.ExecuteReader();
                reportList.Add("txnID \t Type \t\t createdDate \t shipDate \t\t status");
                while (reader.Read())
                {
                    DateTime s = DateTime.Parse(reader["shipDate"].ToString());
                    DateTime c = DateTime.Parse(reader["createdDate"].ToString());
                    reportList.Add(String.Format("{0, 3} \t {1, 12} \t {2, 11} \t {3, 11} \t {4, 3}", reader["txnID"].ToString(), reader["txnType"].ToString(), c.ToString("yyyy-MM-d"), s.ToString("yyyy-MM-d"), reader["status"].ToString()));
                }
            }
            conn.Close();

            //Fill list
            FillProductList();
        }
        private void SupplierOrder()
        {

            FillProductList();
        }


    }
}
