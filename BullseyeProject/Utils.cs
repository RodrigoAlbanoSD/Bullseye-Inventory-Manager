using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BullseyeProject
{
    class Utils
    {
        //tabs names
        public static string homeTab = "tabHome";
        public static string inventoryTab = "tabInventory";
        public static string warehouseOrdersTab = "tabWarehouseOrders";
        public static string storeOrdersTab = "tabStoreOrders";
        public static string sitesTab = "tabSites";
        public static string productsTab = "tabProducts";
        public static string reportsTab = "tabReports";
        public static string adminTab = "tabAdmin";
        public static string chatTab = "tabChat";
        //static string Tab = "tab";

        //Binding commands fields
        public static string first = "first";
        public static string previous = "previous";
        public static string next = "next";
        public static string last = "last";

        //Position id related to permissionLevel
        public static string regionalManager = "Regional Manage";
        public static string financialManager = "Financial Manager";
        public static string storeManager = "Store Manager";
        public static string warehouseManager = "Warehouse Manager";
        public static string truckingDelivery = "Trucking/Delivery";
        public static string admin = "Admin";
        public static int regionalManagerPosn = 1;
        public static int financialManagerPosn = 2;
        public static int storeManagerPosn = 3;
        public static int warehouseManagerPosn = 4;
        public static int truckingDeliveryPosn = 5;
        public static int storeClerkPosn = 6;
        public static int warehouseClerkPosn = 6;
        public static int adminPosn = 99999999;
        //PermissionID
        public static string permissionAddUser = "ADDUSER";
        public static string permissionEditUser = "EDITUSER";
        public static string permissionDeleteUser = "DELETEUSER";
        public static string permissionReadUser = "READUSER";
        public static string permissionSetPermissionUser = "SETPERMISSION";
        public static string permissionCreateStoreOrder = "CREATESTOREORDER";
        public static string permissionReceiveStoreOrder = "RECEIVESTOREORDER";
        public static string permissionMoveInventory = "MOVEINVENTORY";
        public static string permissionPrepareStoreOrder = "PREPARESTOREORDER";
        public static string permissionFulfilStoreOrder = "FULFILSTOREORDER";
        public static string permissionAddItemToBackOrder = "ADDITEMTOBACKORDER";
        public static string permissionCreateBackOrder = "CREATEBACKORDER";
        public static string permissionViewLocation = "VIEWLOCATION";
        public static string permissionAddLocation = "ADDLOCATION";
        public static string permissionViewOrders = "VIEWORDERS";
        public static string permissionEditLocation = "EDITLOCATION";
        public static string permissionDeleteLocation = "DELETELOCATION";
        public static string permissionEditInventory = "EDITINVENTORY";
        public static string permissionAcceptStoreOrder = "ACCEPTSTOREORDER";
        public static string permissionDelivery = "DELIVERY";
        public static string permissionAddNewProduct = "ADDNEWPRODUCT";
        public static string permissionModifyRecord = "MODIFYRECORD";
        public static string permissionCreateLoss = "CREATELOSS";
        public static string permissionCreateSupplierOrder = "CREATESUPPLIERORDER";
        public static string permissionCreateReports = "CREATEREPORTS";

        //txnTypes
        public static string backOrder = "Back Order";
        public static string damage = "Damage";
        public static string gain = "Gain";
        public static string loss = "Loss";
        public static string rejected = "Rejected";
        public static string Return = "Return";
        public static string sale = "Sale";
        public static string storeOrder = "Store Order";
        public static string supplierOrder = "Supplier Order";
        public static string correction = "Correction";
        //txn status
        public static string statusAssembled = "Assembled";
        public static string statusAssembling = "Assembling";
        public static string statusCompleted = "Complete";
        public static string statusDelivered = "Delivered";
        public static string statusInProgress = "In progress";
        public static string statusInTransit = "In Transit";
        public static string statusPendingBackOrder = "Pending Back Order";
        public static string statusRejected = "Rejected";
        public static string statusSubmmited = "Submitted";
        public static string statusCancelled = "Cancelled";

        public static string updateOrder = "updateOrder";


        //Dataset connection. Logged to my sql account
        private static string connString = "server=localhost;database=bullseyedb2022;" +
           "userid=Rodrigo;password=rororo0808";
        MySqlConnection conn = new MySqlConnection(connString);

        public static string Encryptation(string key)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(key);
            System.Security.Cryptography.SHA256Managed sha256hashstring = new System.Security.Cryptography.SHA256Managed();

            byte[] hash = sha256hashstring.ComputeHash(bytes);
            string hashstring = string.Empty;
            foreach (byte x in hash)
            {
                hashstring += String.Format("{0:x2}", x);
            }
            return hashstring;
        }

        // Unique ID, user, date/time, description
        public static string Audit()
        {
            return "";
            //return Main.user.userID + " " 
        }


        public static void DrawTabs(DrawItemEventArgs e)
        {
            //HomePage h = new HomePage();

            switch (e.Index)
            {
                case 0:
                    e.Graphics.FillRectangle(new SolidBrush(Color.ForestGreen), e.Bounds);
                    e.Graphics.DrawString("Home Page", new Font("Times New Roman", (float)14), Brushes.Black, 40, 10, StringFormat.GenericDefault);
                    break;
                case 1:
                    e.Graphics.FillRectangle(new SolidBrush(Color.ForestGreen), e.Bounds);
                    e.Graphics.DrawString("Inventory", e.Font, Brushes.Black, 200, 10, StringFormat.GenericDefault);
                    break;
                case 2:
                    e.Graphics.FillRectangle(new SolidBrush(Color.ForestGreen), e.Bounds);
                    e.Graphics.DrawString("Warehouse Orders", e.Font, Brushes.Black, 400, 10, StringFormat.GenericDefault);
                    break;
                case 3:
                    e.Graphics.FillRectangle(new SolidBrush(Color.ForestGreen), e.Bounds);
                    e.Graphics.DrawString("Store Orders", e.Font, Brushes.Black, 600, 10, StringFormat.GenericDefault);
                    break;
                case 4:
                    e.Graphics.FillRectangle(new SolidBrush(Color.ForestGreen), e.Bounds);
                    e.Graphics.DrawString("Reports", e.Font, Brushes.Black, 800, 10, StringFormat.GenericTypographic);
                    break;
                case 5:
                    e.Graphics.FillRectangle(new SolidBrush(Color.ForestGreen), e.Bounds);
                    e.Graphics.DrawString("Admin", e.Font, Brushes.Black, 900, 10, StringFormat.GenericDefault);
                    break;
            }


        }

        public static int FindPosition(string permissionLevel)
        {
            if (permissionLevel == Utils.regionalManager)
            {
                return Utils.regionalManagerPosn;
            }
            else if (permissionLevel == Utils.financialManager)
            {
                return Utils.financialManagerPosn;
            }
            else if (permissionLevel == Utils.storeManager)
            {
                return Utils.storeManagerPosn;
            }
            else if (permissionLevel == Utils.warehouseManager)
            {
                return Utils.warehouseManagerPosn;
            }
            else if (permissionLevel == Utils.truckingDelivery)
            {
                return Utils.truckingDeliveryPosn;
            }
            else if (permissionLevel == Utils.admin)
            {
                return Utils.adminPosn;
            }
            else return 6;
        }




        public static bool CheckPermissions(string permission)
        {
            //check permission
            for (int i = 0; i < Main.user.userPermissionID.Count; i++)
            {
                if (Main.user.userPermissionID[i] == permission)
                {
                    return true;
                }
            }

            return false;
        }

        
        public static void MoveInventory(int itemID, int siteIDFrom, int siteIDTo)
        {
            MySqlConnection conn = new MySqlConnection(connString);

            //int reorderThreshold, maxReorderWarning;
            //location = "Warehouse-to-Order";
            //siteID = 2; //warehouse

            conn.Open();
            MySqlCommand userPass = new MySqlCommand("UPDATE inventory SET siteID = " + siteIDTo + " where (itemID = " + itemID + " and siteID= " + siteIDFrom + ")", conn);
            userPass.ExecuteReader();

        }

        public static void MoveLocation(int itemID, string location, int siteID)
        {
            MySqlConnection conn = new MySqlConnection(connString);

            //int reorderThreshold, maxReorderWarning;
            //location = "Warehouse-to-Order";
            //siteID = 2; //warehouse

            conn.Open();
            MySqlCommand userPass = new MySqlCommand("UPDATE inventory SET itemLocation = '" + location + "' where (itemID = " + itemID + " and siteID= " + siteID + ")", conn);
            userPass.ExecuteReader();

        }

        public static void MoveFromSite(int itemID, int siteIDTo, int siteIDFrom)
        {
            MySqlConnection conn = new MySqlConnection(connString);


            conn.Open();
            MySqlCommand userPass = new MySqlCommand("UPDATE inventory SET itemLocation = '" + 0 + "', siteID = " + siteIDTo + " where (itemID = " + itemID + " and siteID= " + siteIDFrom + ")", conn);
            userPass.ExecuteReader();
        }

        public static void Audit(int txnID, string txnType, string status, DateTime txnDate, int siteID, int deliviveryID)
        {
            MySqlConnection conn = new MySqlConnection(connString);
            //INSERT INTO `txnaudit` (`txnID`, `txnType`, `status`, `txnDate`, `SiteID`, `deliveryID`) VALUES (@p1, @p2, @p3, @p4, @p5, @p6)
            conn.Open();
            MySqlCommand userPass = new MySqlCommand("INSERT INTO txnaudit (txnID, txnType, status, txnDate, SiteID, deliveryID) VALUES (" + txnID+", '" + txnType +"', '" + status +"', '" + txnDate.ToString("yyyy/MM/d hh:mm:ss") + "', " + siteID +", " + deliviveryID +")", conn);

            userPass.ExecuteReader();
            conn.Close();
        }

        public static Txn FindTxn(int txnID)
        {
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand userPass = new MySqlCommand("select siteIDTo, siteIDFrom, status, shipDate, txnType, barCode, createdDate, deliveryID, emergencyDelivery from txn where txnID = " + txnID, conn);
            MySqlDataReader reader = userPass.ExecuteReader();
            Txn t = new Txn();
            if (reader.Read())
            {
                int siteIDFrom = Int32.Parse(reader["siteIDFrom"].ToString());
                int siteIDTo = Int32.Parse(reader["siteIDTo"].ToString());
                string status = reader["status"].ToString();
                DateTime shipDate = DateTime.Parse(reader["shipDate"].ToString());
                string txnType = reader["txnType"].ToString();
                string barCode = reader["barCode"].ToString();
                DateTime createdDate = DateTime.Parse(reader["createdDate"].ToString());
                int deliveryID;
                if (reader["deliveryID"].ToString() == null)
                {
                    deliveryID = 1;
                }
                else deliveryID = Int32.Parse(reader["deliveryID"].ToString());
                bool eo =  Boolean.Parse(reader["emergencyDelivery"].ToString());

                t = new Txn(txnID, siteIDTo, siteIDFrom, status, shipDate, txnType, barCode, createdDate, deliveryID, eo ? 1 : 0);  
            }
            conn.Close();

            return t;
        }

        public static bool CheckScheduledDelivery()
        {
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();

            //Get distance from WH
            MySqlCommand userPass = new MySqlCommand("select deliveryID from txn WHERE shipDate > NOW() and siteIDFrom = " + Main.user.siteID, conn);
            MySqlDataReader reader = userPass.ExecuteReader();

            if (reader.Read())
            {
                Main.deliveryID = Int32.Parse(reader["deliveryID"].ToString());

                reader.Close();

                return true;
            }
            reader.Close();

            return false;
        }
        public static int NewDelivery(double weight)
        {
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            
            string vehicleType = "";
            int distanceFromWH = 0, deliveryID = 0;
            double HourlyTruckCost, costPerKem = 0.0, distanceCost;

            //Get distance from WH
            MySqlCommand userPass = new MySqlCommand("select dayOfWeek, distanceFromWH from site where siteID = " + Main.user.siteID, conn);
            MySqlDataReader reader = userPass.ExecuteReader();

            if (reader.Read())
            {
                distanceFromWH = Int32.Parse(reader["distanceFromWH"].ToString());
            }
            reader.Close();

            //check best suitable truck
            userPass = new MySqlCommand("select vehicleType, maxWeight, HourlyTruckCost, costPerKem from vehicle where maxWeight >= " + weight + " order by maxWeight limit 1", conn);
            reader = userPass.ExecuteReader();
            if (reader.Read())
            {
                HourlyTruckCost = Double.Parse(reader["HourlyTruckCost"].ToString());
                costPerKem = Double.Parse(reader["costPerKem"].ToString());
                vehicleType = reader["vehicleType"].ToString();
            }
            reader.Close();

            //Insert new delivery
            distanceCost = distanceFromWH * costPerKem;

            userPass = new MySqlCommand("INSERT INTO delivery(distanceCost, vehicleType, notes) VALUES (" + distanceCost + ", '" + vehicleType + "', '' )", conn);
            reader = userPass.ExecuteReader();
            reader.Close();
            // Get last deliveryID
            userPass = new MySqlCommand("select Max(deliveryID) from delivery", conn);
            reader = userPass.ExecuteReader();
            if (reader.Read())
            {
                deliveryID = Int32.Parse(reader["Max(deliveryID)"].ToString());
            }
            reader.Close();

            conn.Close();
            return deliveryID;
        }


        public static DateTime FindShipDate()
        {
            string dayOfWeek = "";
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand userPass = new MySqlCommand("select dayOfWeek, distanceFromWH from site where siteID = " + Main.user.siteID, conn);
            MySqlDataReader reader = userPass.ExecuteReader();

            if (reader.Read())
            {
                dayOfWeek = reader["dayOfWeek"].ToString();
            }
            reader.Close();


            DateTime today = DateTime.Parse(DateTime.Now.ToString("yyyy/MM/d"));
            DayOfWeek deliveryWeekDay = DayOfWeek.Monday;
            switch (dayOfWeek)
            {
                case "MONDAY": deliveryWeekDay = DayOfWeek.Monday; break;
                case "TUESDAY": deliveryWeekDay = DayOfWeek.Tuesday; break;
                case "WEDNESDAY": deliveryWeekDay = DayOfWeek.Wednesday; break;
                case "THURSDAY": deliveryWeekDay = DayOfWeek.Thursday; break;
                case "FRIDAY": deliveryWeekDay = DayOfWeek.Friday; break;
                case "SATURDAY": deliveryWeekDay = DayOfWeek.Saturday; break;
                case "SUNDAY": deliveryWeekDay = DayOfWeek.Sunday; break;
            }
            DateTime newShipDate = System.Linq.Enumerable.Range(0, 6)
              .Select(i => today.AddDays(i))
              .Single(day => day.DayOfWeek == deliveryWeekDay);

            conn.Close();

            return newShipDate;
        }
    }
}
