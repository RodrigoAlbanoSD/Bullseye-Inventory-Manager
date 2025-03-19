
namespace BullseyeProject
{
    partial class NewOrder
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label itemIDLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewOrder));
            this.bullseyedb2022DataSet = new BullseyeProject.bullseyedb2022DataSet();
            this.itemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.itemTableAdapter = new BullseyeProject.bullseyedb2022DataSetTableAdapters.itemTableAdapter();
            this.tableAdapterManager = new BullseyeProject.bullseyedb2022DataSetTableAdapters.TableAdapterManager();
            this.itemBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
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
            this.itemBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.itemDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnFinishOrder = new System.Windows.Forms.Button();
            this.nudProductQuantity = new System.Windows.Forms.NumericUpDown();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.itemIDTextBox = new System.Windows.Forms.TextBox();
            this.costPriceTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lstProductList = new System.Windows.Forms.ListBox();
            this.btnFilterItems = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.grpProductDetail = new System.Windows.Forms.GroupBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.grpFilterItems = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.btnDiscard = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cboSuggestedItems = new System.Windows.Forms.ComboBox();
            this.btnEO = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            itemIDLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bullseyedb2022DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemBindingNavigator)).BeginInit();
            this.itemBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudProductQuantity)).BeginInit();
            this.grpProductDetail.SuspendLayout();
            this.grpFilterItems.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(6, 106);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(106, 24);
            label1.TabIndex = 17;
            label1.Text = "Unit Cost:";
            // 
            // itemIDLabel
            // 
            itemIDLabel.AutoSize = true;
            itemIDLabel.Location = new System.Drawing.Point(9, 66);
            itemIDLabel.Name = "itemIDLabel";
            itemIDLabel.Size = new System.Drawing.Size(85, 24);
            itemIDLabel.TabIndex = 13;
            itemIDLabel.Text = "item ID:";
            // 
            // bullseyedb2022DataSet
            // 
            this.bullseyedb2022DataSet.DataSetName = "bullseyedb2022DataSet";
            this.bullseyedb2022DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // itemBindingSource
            // 
            this.itemBindingSource.DataMember = "item";
            this.itemBindingSource.DataSource = this.bullseyedb2022DataSet;
            // 
            // itemTableAdapter
            // 
            this.itemTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.categoryTableAdapter = null;
            this.tableAdapterManager.deliveryTableAdapter = null;
            this.tableAdapterManager.employeeTableAdapter = null;
            this.tableAdapterManager.inventoryTableAdapter = null;
            this.tableAdapterManager.itemTableAdapter = this.itemTableAdapter;
            this.tableAdapterManager.permissionTableAdapter = null;
            this.tableAdapterManager.posnTableAdapter = null;
            this.tableAdapterManager.provinceTableAdapter = null;
            this.tableAdapterManager.siteTableAdapter = null;
            this.tableAdapterManager.supplierTableAdapter = null;
            this.tableAdapterManager.txnauditTableAdapter = null;
            this.tableAdapterManager.txnitemsTableAdapter = null;
            this.tableAdapterManager.txnstatusTableAdapter = null;
            this.tableAdapterManager.txnTableAdapter = null;
            this.tableAdapterManager.txntypeTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = BullseyeProject.bullseyedb2022DataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.user_permissionTableAdapter = null;
            this.tableAdapterManager.vehicleTableAdapter = null;
            // 
            // itemBindingNavigator
            // 
            this.itemBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.itemBindingNavigator.BindingSource = this.itemBindingSource;
            this.itemBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.itemBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.itemBindingNavigator.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.itemBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.itemBindingNavigatorSaveItem});
            this.itemBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.itemBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.itemBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.itemBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.itemBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.itemBindingNavigator.Name = "itemBindingNavigator";
            this.itemBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.itemBindingNavigator.Size = new System.Drawing.Size(1512, 31);
            this.itemBindingNavigator.TabIndex = 0;
            this.itemBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(29, 28);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(45, 28);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(29, 28);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(29, 28);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(29, 28);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 31);
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
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(29, 28);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(29, 28);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // itemBindingNavigatorSaveItem
            // 
            this.itemBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.itemBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("itemBindingNavigatorSaveItem.Image")));
            this.itemBindingNavigatorSaveItem.Name = "itemBindingNavigatorSaveItem";
            this.itemBindingNavigatorSaveItem.Size = new System.Drawing.Size(29, 28);
            this.itemBindingNavigatorSaveItem.Text = "Save Data";
            this.itemBindingNavigatorSaveItem.Click += new System.EventHandler(this.itemBindingNavigatorSaveItem_Click);
            // 
            // itemDataGridView
            // 
            this.itemDataGridView.AutoGenerateColumns = false;
            this.itemDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.itemDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn8,
            this.costPrice,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11});
            this.itemDataGridView.DataSource = this.itemBindingSource;
            this.itemDataGridView.Location = new System.Drawing.Point(195, 92);
            this.itemDataGridView.Name = "itemDataGridView";
            this.itemDataGridView.ReadOnly = true;
            this.itemDataGridView.RowHeadersWidth = 51;
            this.itemDataGridView.RowTemplate.Height = 24;
            this.itemDataGridView.Size = new System.Drawing.Size(802, 550);
            this.itemDataGridView.TabIndex = 1;
            this.itemDataGridView.SelectionChanged += new System.EventHandler(this.itemDataGridView_SelectionChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "itemID";
            this.dataGridViewTextBoxColumn1.HeaderText = "itemID";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 101;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "name";
            this.dataGridViewTextBoxColumn2.HeaderText = "name";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 91;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "sku";
            this.dataGridViewTextBoxColumn3.HeaderText = "sku";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Visible = false;
            this.dataGridViewTextBoxColumn3.Width = 125;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "description";
            this.dataGridViewTextBoxColumn4.HeaderText = "description";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 125;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "category";
            this.dataGridViewTextBoxColumn5.HeaderText = "category";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 24;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "weight";
            this.dataGridViewTextBoxColumn6.HeaderText = "weight";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Visible = false;
            this.dataGridViewTextBoxColumn6.Width = 125;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn8.DataPropertyName = "retailPrice";
            this.dataGridViewTextBoxColumn8.HeaderText = "retailPrice";
            this.dataGridViewTextBoxColumn8.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 137;
            // 
            // costPrice
            // 
            this.costPrice.DataPropertyName = "costPrice";
            this.costPrice.HeaderText = "costPrice";
            this.costPrice.MinimumWidth = 6;
            this.costPrice.Name = "costPrice";
            this.costPrice.ReadOnly = true;
            this.costPrice.Visible = false;
            this.costPrice.Width = 125;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "supplierID";
            this.dataGridViewTextBoxColumn9.HeaderText = "supplierID";
            this.dataGridViewTextBoxColumn9.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Visible = false;
            this.dataGridViewTextBoxColumn9.Width = 125;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "active";
            this.dataGridViewCheckBoxColumn1.HeaderText = "active";
            this.dataGridViewCheckBoxColumn1.MinimumWidth = 6;
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.ReadOnly = true;
            this.dataGridViewCheckBoxColumn1.Visible = false;
            this.dataGridViewCheckBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "notes";
            this.dataGridViewTextBoxColumn10.HeaderText = "notes";
            this.dataGridViewTextBoxColumn10.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 125;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "caseSize";
            this.dataGridViewTextBoxColumn11.HeaderText = "caseSize";
            this.dataGridViewTextBoxColumn11.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Visible = false;
            this.dataGridViewTextBoxColumn11.Width = 125;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(212)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdd.Font = new System.Drawing.Font("Helvetica LT Pro", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAdd.Location = new System.Drawing.Point(12, 92);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(161, 147);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Add\r\n";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnFinishOrder
            // 
            this.btnFinishOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(212)))));
            this.btnFinishOrder.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnFinishOrder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFinishOrder.Font = new System.Drawing.Font("Helvetica LT Pro", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinishOrder.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnFinishOrder.Location = new System.Drawing.Point(12, 657);
            this.btnFinishOrder.Name = "btnFinishOrder";
            this.btnFinishOrder.Size = new System.Drawing.Size(161, 147);
            this.btnFinishOrder.TabIndex = 10;
            this.btnFinishOrder.Text = "Finish\r\n";
            this.btnFinishOrder.UseVisualStyleBackColor = false;
            this.btnFinishOrder.Click += new System.EventHandler(this.btnFinishOrder_Click);
            // 
            // nudProductQuantity
            // 
            this.nudProductQuantity.Location = new System.Drawing.Point(278, 151);
            this.nudProductQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudProductQuantity.Name = "nudProductQuantity";
            this.nudProductQuantity.Size = new System.Drawing.Size(81, 27);
            this.nudProductQuantity.TabIndex = 12;
            this.nudProductQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nameTextBox
            // 
            this.nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.itemBindingSource, "name", true));
            this.nameTextBox.Location = new System.Drawing.Point(24, 26);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(416, 27);
            this.nameTextBox.TabIndex = 13;
            // 
            // itemIDTextBox
            // 
            this.itemIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.itemBindingSource, "itemID", true));
            this.itemIDTextBox.Location = new System.Drawing.Point(132, 66);
            this.itemIDTextBox.Name = "itemIDTextBox";
            this.itemIDTextBox.Size = new System.Drawing.Size(102, 27);
            this.itemIDTextBox.TabIndex = 14;
            // 
            // costPriceTextBox
            // 
            this.costPriceTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.itemBindingSource, "costPrice", true));
            this.costPriceTextBox.Location = new System.Drawing.Point(132, 103);
            this.costPriceTextBox.Name = "costPriceTextBox";
            this.costPriceTextBox.Size = new System.Drawing.Size(100, 27);
            this.costPriceTextBox.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(263, 24);
            this.label2.TabIndex = 18;
            this.label2.Text = "Quantity to Add / Remove:";
            // 
            // lstProductList
            // 
            this.lstProductList.FormattingEnabled = true;
            this.lstProductList.ItemHeight = 24;
            this.lstProductList.Location = new System.Drawing.Point(1013, 305);
            this.lstProductList.Name = "lstProductList";
            this.lstProductList.Size = new System.Drawing.Size(446, 484);
            this.lstProductList.TabIndex = 20;
            this.lstProductList.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // btnFilterItems
            // 
            this.btnFilterItems.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(212)))));
            this.btnFilterItems.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFilterItems.Font = new System.Drawing.Font("Helvetica LT Pro", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilterItems.Location = new System.Drawing.Point(13, 564);
            this.btnFilterItems.Name = "btnFilterItems";
            this.btnFilterItems.Size = new System.Drawing.Size(160, 54);
            this.btnFilterItems.TabIndex = 21;
            this.btnFilterItems.Text = "Filter";
            this.btnFilterItems.UseVisualStyleBackColor = false;
            this.btnFilterItems.Click += new System.EventHandler(this.btnFilterItems_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(212)))));
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRemove.Font = new System.Drawing.Font("Helvetica LT Pro", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnRemove.Location = new System.Drawing.Point(12, 245);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(161, 147);
            this.btnRemove.TabIndex = 22;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click_1);
            // 
            // grpProductDetail
            // 
            this.grpProductDetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(145)))), ((int)(((byte)(0)))));
            this.grpProductDetail.Controls.Add(itemIDLabel);
            this.grpProductDetail.Controls.Add(this.nudProductQuantity);
            this.grpProductDetail.Controls.Add(this.nameTextBox);
            this.grpProductDetail.Controls.Add(this.label2);
            this.grpProductDetail.Controls.Add(this.costPriceTextBox);
            this.grpProductDetail.Controls.Add(this.itemIDTextBox);
            this.grpProductDetail.Controls.Add(label1);
            this.grpProductDetail.Location = new System.Drawing.Point(1013, 92);
            this.grpProductDetail.Name = "grpProductDetail";
            this.grpProductDetail.Size = new System.Drawing.Size(446, 194);
            this.grpProductDetail.TabIndex = 23;
            this.grpProductDetail.TabStop = false;
            this.grpProductDetail.Text = "Product";
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(145)))), ((int)(((byte)(0)))));
            this.label21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label21.Font = new System.Drawing.Font("Helvetica LT Pro", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(1054, 78);
            this.label21.Margin = new System.Windows.Forms.Padding(0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(360, 5);
            this.label21.TabIndex = 42;
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Azure;
            this.label3.Font = new System.Drawing.Font("Helvetica LT Pro", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1054, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(360, 37);
            this.label3.TabIndex = 41;
            this.label3.Text = "Order Details";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(145)))), ((int)(((byte)(0)))));
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Helvetica LT Pro", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(376, 78);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(360, 5);
            this.label4.TabIndex = 44;
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Azure;
            this.label5.Font = new System.Drawing.Font("Helvetica LT Pro", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(376, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(360, 37);
            this.label5.TabIndex = 43;
            this.label5.Text = "Available Products";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpFilterItems
            // 
            this.grpFilterItems.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(145)))), ((int)(((byte)(0)))));
            this.grpFilterItems.Controls.Add(this.label8);
            this.grpFilterItems.Controls.Add(this.cboCategory);
            this.grpFilterItems.Controls.Add(this.txtProductName);
            this.grpFilterItems.Controls.Add(this.label7);
            this.grpFilterItems.Controls.Add(this.btnSearch);
            this.grpFilterItems.Controls.Add(this.lblName);
            this.grpFilterItems.Controls.Add(this.btnDiscard);
            this.grpFilterItems.Location = new System.Drawing.Point(195, 657);
            this.grpFilterItems.Name = "grpFilterItems";
            this.grpFilterItems.Size = new System.Drawing.Size(802, 147);
            this.grpFilterItems.TabIndex = 45;
            this.grpFilterItems.TabStop = false;
            this.grpFilterItems.Text = "Filter";
            this.grpFilterItems.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(320, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 24);
            this.label8.TabIndex = 12;
            this.label8.Text = "Category";
            // 
            // cboCategory
            // 
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(437, 31);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(156, 32);
            this.cboCategory.TabIndex = 11;
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(110, 34);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(165, 27);
            this.txtProductName.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 24);
            this.label7.TabIndex = 9;
            this.label7.Text = "Name:";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(190)))), ((int)(((byte)(255)))));
            this.btnSearch.Location = new System.Drawing.Point(674, 34);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(107, 44);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(28, 102);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(335, 24);
            this.lblName.TabIndex = 7;
            this.lblName.Text = "*By name, price range or category";
            // 
            // btnDiscard
            // 
            this.btnDiscard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(190)))), ((int)(((byte)(255)))));
            this.btnDiscard.Location = new System.Drawing.Point(674, 88);
            this.btnDiscard.Name = "btnDiscard";
            this.btnDiscard.Size = new System.Drawing.Size(107, 44);
            this.btnDiscard.TabIndex = 5;
            this.btnDiscard.Text = "Discard";
            this.btnDiscard.UseVisualStyleBackColor = false;
            this.btnDiscard.Click += new System.EventHandler(this.btnDiscard_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(192, 24);
            this.label6.TabIndex = 46;
            this.label6.Text = "Suggested Product";
            // 
            // cboSuggestedItems
            // 
            this.cboSuggestedItems.FormattingEnabled = true;
            this.cboSuggestedItems.Location = new System.Drawing.Point(207, 48);
            this.cboSuggestedItems.Name = "cboSuggestedItems";
            this.cboSuggestedItems.Size = new System.Drawing.Size(121, 32);
            this.cboSuggestedItems.TabIndex = 47;
            this.cboSuggestedItems.SelectedIndexChanged += new System.EventHandler(this.cboSuggestedItems_SelectedIndexChanged);
            // 
            // btnEO
            // 
            this.btnEO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnEO.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEO.Font = new System.Drawing.Font("Helvetica LT Pro", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEO.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnEO.Location = new System.Drawing.Point(12, 398);
            this.btnEO.Name = "btnEO";
            this.btnEO.Size = new System.Drawing.Size(161, 147);
            this.btnEO.TabIndex = 48;
            this.btnEO.Text = "Emergency\r\nOrder\r\n";
            this.btnEO.UseVisualStyleBackColor = false;
            this.btnEO.Click += new System.EventHandler(this.btnEO_Click);
            // 
            // NewOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(1512, 816);
            this.Controls.Add(this.btnEO);
            this.Controls.Add(this.cboSuggestedItems);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.grpFilterItems);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.grpProductDetail);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnFilterItems);
            this.Controls.Add(this.lstProductList);
            this.Controls.Add(this.btnFinishOrder);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.itemDataGridView);
            this.Controls.Add(this.itemBindingNavigator);
            this.Font = new System.Drawing.Font("Helvetica LT Pro", 12F, System.Drawing.FontStyle.Bold);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "NewOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Order";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.NewOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bullseyedb2022DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemBindingNavigator)).EndInit();
            this.itemBindingNavigator.ResumeLayout(false);
            this.itemBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudProductQuantity)).EndInit();
            this.grpProductDetail.ResumeLayout(false);
            this.grpProductDetail.PerformLayout();
            this.grpFilterItems.ResumeLayout(false);
            this.grpFilterItems.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private bullseyedb2022DataSet bullseyedb2022DataSet;
        private System.Windows.Forms.BindingSource itemBindingSource;
        private bullseyedb2022DataSetTableAdapters.itemTableAdapter itemTableAdapter;
        private bullseyedb2022DataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator itemBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton itemBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView itemDataGridView;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnFinishOrder;
        private System.Windows.Forms.NumericUpDown nudProductQuantity;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox itemIDTextBox;
        private System.Windows.Forms.TextBox costPriceTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstProductList;
        private System.Windows.Forms.Button btnFilterItems;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.GroupBox grpProductDetail;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox grpFilterItems;
        private System.Windows.Forms.Button btnDiscard;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboSuggestedItems;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn costPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.Button btnEO;
    }
}