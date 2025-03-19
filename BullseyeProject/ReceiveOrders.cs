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
    public partial class ReceiveOrders : Form
    {
        //User Fields
        private List<string> userPermissionID;
        private int userPosnID;
        private int siteID;

        public ReceiveOrders()
        {
            InitializeComponent();
        }

        //Dataset connection. Logged to my sql account
        static string connString = "server=localhost;database=bullseyedb2022;" +
           "userid=Rodrigo;password=rororo0808";
        MySqlConnection conn = new MySqlConnection(connString);

        private void txnBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.txnBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.bullseyedb2022DataSet);

        }

        private void ReceiveOrders_Load(object sender, EventArgs e)
        {
            userPermissionID = Main.user.userPermissionID;
            userPosnID = Main.user.positionID;
            siteID = Main.user.siteID;
            //permissionLevel = Main.permissionLevel;

            /*
            //Fill comboBox
            conn.Open();
            MySqlCommand userPass = new MySqlCommand("select statusName from txnStatus", conn);
            MySqlDataReader reader = userPass.ExecuteReader();
            //clear list
            cboStatus.Items.Clear();

            while (reader.Read())
            {
                cboStatus.Items.Add(reader["statusName"]);
            }
            cboStatus.Items.Add("All Orders");
            conn.Close();
            */

            if (Utils.CheckPermissions(Utils.permissionReceiveStoreOrder))
            {

                this.txnTableAdapter.FillByStatus(this.bullseyedb2022DataSet.txn, Utils.statusSubmmited);
                btnProcessOrder.Enabled = true;
                btnAcceptOrder.Enabled = false;

            }
            else
            {
                btnProcessOrder.Enabled = true;
                if (Utils.CheckPermissions(Utils.permissionAcceptStoreOrder))
                {
                    btnAcceptOrder.Enabled = true;
                }

                this.txnTableAdapter.FillForStore(this.bullseyedb2022DataSet.txn, siteID);
            }
        }
        
        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboStatus.SelectedItem.ToString() == "All Orders")
            {
                this.txnTableAdapter.Fill(this.bullseyedb2022DataSet.txn);
            }
            else
            {
                this.txnTableAdapter.FillByStatus(this.bullseyedb2022DataSet.txn, cboStatus.SelectedItem.ToString());
            }
        }

        private void btnProcessOrder_Click(object sender, EventArgs e)
        {
            if (txnIDTextBox.Text != "") 
            {
                //Update status
                this.txnTableAdapter.UpdateStatus(Utils.statusAssembling, Int32.Parse(txnIDTextBox.Text));
                //Audit Activity
                Utils.Audit(Int32.Parse(txnIDTextBox.Text), txnTypeTextBox.Text, Utils.statusAssembling, DateTime.Parse(createdDateDateTimePicker.Text), Main.user.siteID, Int32.Parse(deliveryIDTextBox.Text));
            
                //check permission
                if (Utils.CheckPermissions(Utils.permissionPrepareStoreOrder))
                {
                    //Fill table again
                    this.txnTableAdapter.FillByStatus(this.bullseyedb2022DataSet.txn, Utils.statusSubmmited);
                }
                else 
                {
                    //Fill table again
                    this.txnTableAdapter.FillForStore(this.bullseyedb2022DataSet.txn, siteID);
                }
            }


        }

        private void btnAcceptOrder_Click(object sender, EventArgs e)
        {
            //check permission
            if (Utils.CheckPermissions(Utils.permissionAcceptStoreOrder))
            {
                if (txnIDTextBox.Text != null)
                {
                    //Update status
                    this.txnTableAdapter.UpdateStatus(Utils.statusCompleted, Int32.Parse(txnIDTextBox.Text));
                    //Update site
                    Utils.MoveFromSite(Int32.Parse(txnIDTextBox.Text), Int32.Parse(siteIDToTextBox.Text), Int32.Parse(siteIDFromTextBox.Text));
                    //Audit Activity
                    Utils.Audit(Int32.Parse(txnIDTextBox.Text), txnTypeTextBox.Text, Utils.statusCompleted, DateTime.Parse(createdDateDateTimePicker.Text), Int32.Parse(siteIDFromTextBox.Text), Int32.Parse(deliveryIDTextBox.Text));
                    //Fill table again
                    this.txnTableAdapter.FillByStatus(this.bullseyedb2022DataSet.txn, Utils.statusInTransit);
                }

            }
            else MessageBox.Show("You do not have permission to accepet a order");
        }

        private void btnFinishedReceive_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
