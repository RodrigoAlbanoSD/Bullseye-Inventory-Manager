
namespace BullseyeProject
{
    partial class ReceiveOrders
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label txnIDLabel;
            System.Windows.Forms.Label siteIDToLabel;
            System.Windows.Forms.Label siteIDFromLabel;
            System.Windows.Forms.Label statusLabel;
            System.Windows.Forms.Label shipDateLabel;
            System.Windows.Forms.Label txnTypeLabel;
            System.Windows.Forms.Label createdDateLabel;
            System.Windows.Forms.Label deliveryIDLabel;
            System.Windows.Forms.Label emergencyDeliveryLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReceiveOrders));
            this.bullseyedb2022DataSet = new BullseyeProject.bullseyedb2022DataSet();
            this.txnBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txnTableAdapter = new BullseyeProject.bullseyedb2022DataSetTableAdapters.txnTableAdapter();
            this.tableAdapterManager = new BullseyeProject.bullseyedb2022DataSetTableAdapters.TableAdapterManager();
            this.txnBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.txnBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.txnDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnProcessOrder = new System.Windows.Forms.Button();
            this.txnIDTextBox = new System.Windows.Forms.TextBox();
            this.siteIDToTextBox = new System.Windows.Forms.TextBox();
            this.siteIDFromTextBox = new System.Windows.Forms.TextBox();
            this.statusTextBox = new System.Windows.Forms.TextBox();
            this.shipDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.txnTypeTextBox = new System.Windows.Forms.TextBox();
            this.createdDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.deliveryIDTextBox = new System.Windows.Forms.TextBox();
            this.emergencyDeliveryCheckBox = new System.Windows.Forms.CheckBox();
            this.grpTxnDetails = new System.Windows.Forms.GroupBox();
            this.btnAcceptOrder = new System.Windows.Forms.Button();
            this.btnFinishedReceive = new System.Windows.Forms.Button();
            txnIDLabel = new System.Windows.Forms.Label();
            siteIDToLabel = new System.Windows.Forms.Label();
            siteIDFromLabel = new System.Windows.Forms.Label();
            statusLabel = new System.Windows.Forms.Label();
            shipDateLabel = new System.Windows.Forms.Label();
            txnTypeLabel = new System.Windows.Forms.Label();
            createdDateLabel = new System.Windows.Forms.Label();
            deliveryIDLabel = new System.Windows.Forms.Label();
            emergencyDeliveryLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bullseyedb2022DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txnBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txnBindingNavigator)).BeginInit();
            this.txnBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txnDataGridView)).BeginInit();
            this.grpTxnDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // txnIDLabel
            // 
            txnIDLabel.AutoSize = true;
            txnIDLabel.Location = new System.Drawing.Point(6, 87);
            txnIDLabel.Name = "txnIDLabel";
            txnIDLabel.Size = new System.Drawing.Size(78, 24);
            txnIDLabel.TabIndex = 23;
            txnIDLabel.Text = "Txn ID:";
            // 
            // siteIDToLabel
            // 
            siteIDToLabel.AutoSize = true;
            siteIDToLabel.Location = new System.Drawing.Point(289, 87);
            siteIDToLabel.Name = "siteIDToLabel";
            siteIDToLabel.Size = new System.Drawing.Size(39, 24);
            siteIDToLabel.TabIndex = 25;
            siteIDToLabel.Text = "To:";
            // 
            // siteIDFromLabel
            // 
            siteIDFromLabel.AutoSize = true;
            siteIDFromLabel.Location = new System.Drawing.Point(498, 87);
            siteIDFromLabel.Name = "siteIDFromLabel";
            siteIDFromLabel.Size = new System.Drawing.Size(67, 24);
            siteIDFromLabel.TabIndex = 27;
            siteIDFromLabel.Text = "From:";
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.Location = new System.Drawing.Point(6, 181);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new System.Drawing.Size(78, 24);
            statusLabel.TabIndex = 29;
            statusLabel.Text = "Status:";
            // 
            // shipDateLabel
            // 
            shipDateLabel.AutoSize = true;
            shipDateLabel.Location = new System.Drawing.Point(330, 343);
            shipDateLabel.Name = "shipDateLabel";
            shipDateLabel.Size = new System.Drawing.Size(109, 24);
            shipDateLabel.TabIndex = 31;
            shipDateLabel.Text = "Ship Date:";
            // 
            // txnTypeLabel
            // 
            txnTypeLabel.AutoSize = true;
            txnTypeLabel.Location = new System.Drawing.Point(6, 258);
            txnTypeLabel.Name = "txnTypeLabel";
            txnTypeLabel.Size = new System.Drawing.Size(62, 24);
            txnTypeLabel.TabIndex = 33;
            txnTypeLabel.Text = "Type:";
            // 
            // createdDateLabel
            // 
            createdDateLabel.AutoSize = true;
            createdDateLabel.Location = new System.Drawing.Point(330, 181);
            createdDateLabel.Name = "createdDateLabel";
            createdDateLabel.Size = new System.Drawing.Size(140, 24);
            createdDateLabel.TabIndex = 37;
            createdDateLabel.Text = "Created Date:";
            // 
            // deliveryIDLabel
            // 
            deliveryIDLabel.AutoSize = true;
            deliveryIDLabel.Location = new System.Drawing.Point(6, 343);
            deliveryIDLabel.Name = "deliveryIDLabel";
            deliveryIDLabel.Size = new System.Drawing.Size(95, 24);
            deliveryIDLabel.TabIndex = 39;
            deliveryIDLabel.Text = "Delivery:";
            // 
            // emergencyDeliveryLabel
            // 
            emergencyDeliveryLabel.AutoSize = true;
            emergencyDeliveryLabel.Location = new System.Drawing.Point(6, 34);
            emergencyDeliveryLabel.Name = "emergencyDeliveryLabel";
            emergencyDeliveryLabel.Size = new System.Drawing.Size(124, 24);
            emergencyDeliveryLabel.TabIndex = 41;
            emergencyDeliveryLabel.Text = "Emergency:";
            // 
            // bullseyedb2022DataSet
            // 
            this.bullseyedb2022DataSet.DataSetName = "bullseyedb2022DataSet";
            this.bullseyedb2022DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txnBindingSource
            // 
            this.txnBindingSource.DataMember = "txn";
            this.txnBindingSource.DataSource = this.bullseyedb2022DataSet;
            // 
            // txnTableAdapter
            // 
            this.txnTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.categoryTableAdapter = null;
            this.tableAdapterManager.deliveryTableAdapter = null;
            this.tableAdapterManager.employeeTableAdapter = null;
            this.tableAdapterManager.inventoryTableAdapter = null;
            this.tableAdapterManager.itemTableAdapter = null;
            this.tableAdapterManager.permissionTableAdapter = null;
            this.tableAdapterManager.posnTableAdapter = null;
            this.tableAdapterManager.provinceTableAdapter = null;
            this.tableAdapterManager.siteTableAdapter = null;
            this.tableAdapterManager.supplierTableAdapter = null;
            this.tableAdapterManager.txnauditTableAdapter = null;
            this.tableAdapterManager.txnitemsTableAdapter = null;
            this.tableAdapterManager.txnstatusTableAdapter = null;
            this.tableAdapterManager.txnTableAdapter = this.txnTableAdapter;
            this.tableAdapterManager.txntypeTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = BullseyeProject.bullseyedb2022DataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.user_permissionTableAdapter = null;
            this.tableAdapterManager.vehicleTableAdapter = null;
            // 
            // txnBindingNavigator
            // 
            this.txnBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.txnBindingNavigator.BindingSource = this.txnBindingSource;
            this.txnBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.txnBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.txnBindingNavigator.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.txnBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.txnBindingNavigatorSaveItem});
            this.txnBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.txnBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.txnBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.txnBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.txnBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.txnBindingNavigator.Name = "txnBindingNavigator";
            this.txnBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.txnBindingNavigator.Size = new System.Drawing.Size(1512, 27);
            this.txnBindingNavigator.TabIndex = 0;
            this.txnBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(45, 24);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 27);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // txnBindingNavigatorSaveItem
            // 
            this.txnBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.txnBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("txnBindingNavigatorSaveItem.Image")));
            this.txnBindingNavigatorSaveItem.Name = "txnBindingNavigatorSaveItem";
            this.txnBindingNavigatorSaveItem.Size = new System.Drawing.Size(29, 24);
            this.txnBindingNavigatorSaveItem.Text = "Save Data";
            this.txnBindingNavigatorSaveItem.Click += new System.EventHandler(this.txnBindingNavigatorSaveItem_Click);
            // 
            // txnDataGridView
            // 
            this.txnDataGridView.AutoGenerateColumns = false;
            this.txnDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.txnDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewCheckBoxColumn1});
            this.txnDataGridView.DataSource = this.txnBindingSource;
            this.txnDataGridView.Location = new System.Drawing.Point(192, 92);
            this.txnDataGridView.Name = "txnDataGridView";
            this.txnDataGridView.RowHeadersWidth = 51;
            this.txnDataGridView.RowTemplate.Height = 24;
            this.txnDataGridView.Size = new System.Drawing.Size(554, 526);
            this.txnDataGridView.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "txnID";
            this.dataGridViewTextBoxColumn1.HeaderText = "txnID";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 89;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "siteIDTo";
            this.dataGridViewTextBoxColumn2.HeaderText = "siteIDTo";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Visible = false;
            this.dataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "siteIDFrom";
            this.dataGridViewTextBoxColumn3.HeaderText = "siteIDFrom";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Visible = false;
            this.dataGridViewTextBoxColumn3.Width = 125;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "status";
            this.dataGridViewTextBoxColumn4.HeaderText = "status";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 24;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "shipDate";
            this.dataGridViewTextBoxColumn5.HeaderText = "shipDate";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Visible = false;
            this.dataGridViewTextBoxColumn5.Width = 125;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "txnType";
            this.dataGridViewTextBoxColumn6.HeaderText = "txnType";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Visible = false;
            this.dataGridViewTextBoxColumn6.Width = 125;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "barCode";
            this.dataGridViewTextBoxColumn7.HeaderText = "barCode";
            this.dataGridViewTextBoxColumn7.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Visible = false;
            this.dataGridViewTextBoxColumn7.Width = 125;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn8.DataPropertyName = "createdDate";
            this.dataGridViewTextBoxColumn8.HeaderText = "Created At";
            this.dataGridViewTextBoxColumn8.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 140;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "deliveryID";
            this.dataGridViewTextBoxColumn9.HeaderText = "deliveryID";
            this.dataGridViewTextBoxColumn9.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Visible = false;
            this.dataGridViewTextBoxColumn9.Width = 125;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "emergencyDelivery";
            this.dataGridViewCheckBoxColumn1.HeaderText = "Emergency";
            this.dataGridViewCheckBoxColumn1.MinimumWidth = 6;
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Width = 125;
            // 
            // cboStatus
            // 
            this.cboStatus.Enabled = false;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(209, 48);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(195, 32);
            this.cboStatus.TabIndex = 22;
            this.cboStatus.SelectedIndexChanged += new System.EventHandler(this.cboStatus_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Helvetica LT Pro", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(22, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(180, 28);
            this.label10.TabIndex = 21;
            this.label10.Text = "Choose Status";
            // 
            // btnProcessOrder
            // 
            this.btnProcessOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(212)))));
            this.btnProcessOrder.Enabled = false;
            this.btnProcessOrder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnProcessOrder.Font = new System.Drawing.Font("Helvetica LT Pro", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcessOrder.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnProcessOrder.Location = new System.Drawing.Point(6, 92);
            this.btnProcessOrder.Name = "btnProcessOrder";
            this.btnProcessOrder.Size = new System.Drawing.Size(161, 147);
            this.btnProcessOrder.TabIndex = 23;
            this.btnProcessOrder.Text = "Process\r\nOrder\r\n";
            this.btnProcessOrder.UseVisualStyleBackColor = false;
            this.btnProcessOrder.Click += new System.EventHandler(this.btnProcessOrder_Click);
            // 
            // txnIDTextBox
            // 
            this.txnIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.txnBindingSource, "txnID", true));
            this.txnIDTextBox.Location = new System.Drawing.Point(113, 87);
            this.txnIDTextBox.Name = "txnIDTextBox";
            this.txnIDTextBox.Size = new System.Drawing.Size(109, 27);
            this.txnIDTextBox.TabIndex = 24;
            // 
            // siteIDToTextBox
            // 
            this.siteIDToTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.txnBindingSource, "siteIDTo", true));
            this.siteIDToTextBox.Location = new System.Drawing.Point(347, 87);
            this.siteIDToTextBox.Name = "siteIDToTextBox";
            this.siteIDToTextBox.Size = new System.Drawing.Size(82, 27);
            this.siteIDToTextBox.TabIndex = 26;
            // 
            // siteIDFromTextBox
            // 
            this.siteIDFromTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.txnBindingSource, "siteIDFrom", true));
            this.siteIDFromTextBox.Location = new System.Drawing.Point(586, 87);
            this.siteIDFromTextBox.Name = "siteIDFromTextBox";
            this.siteIDFromTextBox.Size = new System.Drawing.Size(81, 27);
            this.siteIDFromTextBox.TabIndex = 28;
            // 
            // statusTextBox
            // 
            this.statusTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.txnBindingSource, "status", true));
            this.statusTextBox.Location = new System.Drawing.Point(113, 178);
            this.statusTextBox.Name = "statusTextBox";
            this.statusTextBox.Size = new System.Drawing.Size(155, 27);
            this.statusTextBox.TabIndex = 30;
            // 
            // shipDateDateTimePicker
            // 
            this.shipDateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.txnBindingSource, "shipDate", true));
            this.shipDateDateTimePicker.Location = new System.Drawing.Point(476, 340);
            this.shipDateDateTimePicker.Name = "shipDateDateTimePicker";
            this.shipDateDateTimePicker.Size = new System.Drawing.Size(241, 27);
            this.shipDateDateTimePicker.TabIndex = 32;
            // 
            // txnTypeTextBox
            // 
            this.txnTypeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.txnBindingSource, "txnType", true));
            this.txnTypeTextBox.Location = new System.Drawing.Point(113, 255);
            this.txnTypeTextBox.Name = "txnTypeTextBox";
            this.txnTypeTextBox.Size = new System.Drawing.Size(155, 27);
            this.txnTypeTextBox.TabIndex = 34;
            // 
            // createdDateDateTimePicker
            // 
            this.createdDateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.txnBindingSource, "createdDate", true));
            this.createdDateDateTimePicker.Location = new System.Drawing.Point(476, 181);
            this.createdDateDateTimePicker.Name = "createdDateDateTimePicker";
            this.createdDateDateTimePicker.Size = new System.Drawing.Size(241, 27);
            this.createdDateDateTimePicker.TabIndex = 38;
            // 
            // deliveryIDTextBox
            // 
            this.deliveryIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.txnBindingSource, "deliveryID", true));
            this.deliveryIDTextBox.Location = new System.Drawing.Point(113, 340);
            this.deliveryIDTextBox.Name = "deliveryIDTextBox";
            this.deliveryIDTextBox.Size = new System.Drawing.Size(155, 27);
            this.deliveryIDTextBox.TabIndex = 40;
            // 
            // emergencyDeliveryCheckBox
            // 
            this.emergencyDeliveryCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.txnBindingSource, "emergencyDelivery", true));
            this.emergencyDeliveryCheckBox.Location = new System.Drawing.Point(136, 35);
            this.emergencyDeliveryCheckBox.Name = "emergencyDeliveryCheckBox";
            this.emergencyDeliveryCheckBox.Size = new System.Drawing.Size(25, 24);
            this.emergencyDeliveryCheckBox.TabIndex = 42;
            this.emergencyDeliveryCheckBox.UseVisualStyleBackColor = true;
            // 
            // grpTxnDetails
            // 
            this.grpTxnDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(145)))), ((int)(((byte)(0)))));
            this.grpTxnDetails.Controls.Add(txnIDLabel);
            this.grpTxnDetails.Controls.Add(this.txnIDTextBox);
            this.grpTxnDetails.Controls.Add(this.emergencyDeliveryCheckBox);
            this.grpTxnDetails.Controls.Add(siteIDToLabel);
            this.grpTxnDetails.Controls.Add(emergencyDeliveryLabel);
            this.grpTxnDetails.Controls.Add(this.siteIDToTextBox);
            this.grpTxnDetails.Controls.Add(this.deliveryIDTextBox);
            this.grpTxnDetails.Controls.Add(siteIDFromLabel);
            this.grpTxnDetails.Controls.Add(deliveryIDLabel);
            this.grpTxnDetails.Controls.Add(this.siteIDFromTextBox);
            this.grpTxnDetails.Controls.Add(this.createdDateDateTimePicker);
            this.grpTxnDetails.Controls.Add(statusLabel);
            this.grpTxnDetails.Controls.Add(createdDateLabel);
            this.grpTxnDetails.Controls.Add(this.statusTextBox);
            this.grpTxnDetails.Controls.Add(shipDateLabel);
            this.grpTxnDetails.Controls.Add(this.shipDateDateTimePicker);
            this.grpTxnDetails.Controls.Add(this.txnTypeTextBox);
            this.grpTxnDetails.Controls.Add(txnTypeLabel);
            this.grpTxnDetails.Location = new System.Drawing.Point(765, 92);
            this.grpTxnDetails.Name = "grpTxnDetails";
            this.grpTxnDetails.Size = new System.Drawing.Size(735, 526);
            this.grpTxnDetails.TabIndex = 43;
            this.grpTxnDetails.TabStop = false;
            this.grpTxnDetails.Text = "Order Details";
            // 
            // btnAcceptOrder
            // 
            this.btnAcceptOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(212)))));
            this.btnAcceptOrder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAcceptOrder.Font = new System.Drawing.Font("Helvetica LT Pro", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAcceptOrder.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAcceptOrder.Location = new System.Drawing.Point(6, 245);
            this.btnAcceptOrder.Name = "btnAcceptOrder";
            this.btnAcceptOrder.Size = new System.Drawing.Size(161, 147);
            this.btnAcceptOrder.TabIndex = 44;
            this.btnAcceptOrder.Text = "Accept\r\nOrder\r\n";
            this.btnAcceptOrder.UseVisualStyleBackColor = false;
            this.btnAcceptOrder.Click += new System.EventHandler(this.btnAcceptOrder_Click);
            // 
            // btnFinishedReceive
            // 
            this.btnFinishedReceive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(212)))));
            this.btnFinishedReceive.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFinishedReceive.Font = new System.Drawing.Font("Helvetica LT Pro", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinishedReceive.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnFinishedReceive.Location = new System.Drawing.Point(6, 657);
            this.btnFinishedReceive.Name = "btnFinishedReceive";
            this.btnFinishedReceive.Size = new System.Drawing.Size(161, 147);
            this.btnFinishedReceive.TabIndex = 45;
            this.btnFinishedReceive.Text = "Finish";
            this.btnFinishedReceive.UseVisualStyleBackColor = false;
            this.btnFinishedReceive.Click += new System.EventHandler(this.btnFinishedReceive_Click);
            // 
            // ReceiveOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(1512, 816);
            this.Controls.Add(this.btnFinishedReceive);
            this.Controls.Add(this.btnAcceptOrder);
            this.Controls.Add(this.btnProcessOrder);
            this.Controls.Add(this.cboStatus);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txnDataGridView);
            this.Controls.Add(this.txnBindingNavigator);
            this.Controls.Add(this.grpTxnDetails);
            this.Font = new System.Drawing.Font("Helvetica LT Pro", 12F, System.Drawing.FontStyle.Bold);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ReceiveOrders";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReceiveOrders";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ReceiveOrders_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bullseyedb2022DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txnBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txnBindingNavigator)).EndInit();
            this.txnBindingNavigator.ResumeLayout(false);
            this.txnBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txnDataGridView)).EndInit();
            this.grpTxnDetails.ResumeLayout(false);
            this.grpTxnDetails.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private bullseyedb2022DataSet bullseyedb2022DataSet;
        private System.Windows.Forms.BindingSource txnBindingSource;
        private bullseyedb2022DataSetTableAdapters.txnTableAdapter txnTableAdapter;
        private bullseyedb2022DataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator txnBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton txnBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView txnDataGridView;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnProcessOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.TextBox txnIDTextBox;
        private System.Windows.Forms.TextBox siteIDToTextBox;
        private System.Windows.Forms.TextBox siteIDFromTextBox;
        private System.Windows.Forms.TextBox statusTextBox;
        private System.Windows.Forms.DateTimePicker shipDateDateTimePicker;
        private System.Windows.Forms.TextBox txnTypeTextBox;
        private System.Windows.Forms.DateTimePicker createdDateDateTimePicker;
        private System.Windows.Forms.TextBox deliveryIDTextBox;
        private System.Windows.Forms.CheckBox emergencyDeliveryCheckBox;
        private System.Windows.Forms.GroupBox grpTxnDetails;
        private System.Windows.Forms.Button btnAcceptOrder;
        private System.Windows.Forms.Button btnFinishedReceive;
    }
}