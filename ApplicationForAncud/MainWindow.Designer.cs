namespace ApplicationForAncud
{
    partial class MainWindow
    {

        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        private void InitializeComponent()
        {
            this.dgvFileCRC = new System.Windows.Forms.DataGridView();
            this.addButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.columnFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnCRC32 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFileCRC)).BeginInit();
            this.tlpMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvFileCRC
            // 
            this.dgvFileCRC.AllowUserToAddRows = false;
            this.dgvFileCRC.AllowUserToResizeColumns = false;
            this.dgvFileCRC.AllowUserToResizeRows = false;
            this.dgvFileCRC.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFileCRC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFileCRC.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnFile,
            this.columnCRC32});
            this.tlpMain.SetColumnSpan(this.dgvFileCRC, 3);
            this.dgvFileCRC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFileCRC.Location = new System.Drawing.Point(3, 3);
            this.dgvFileCRC.MultiSelect = false;
            this.dgvFileCRC.Name = "dgvFileCRC";
            this.dgvFileCRC.ReadOnly = true;
            this.dgvFileCRC.RowHeadersVisible = false;
            this.dgvFileCRC.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFileCRC.Size = new System.Drawing.Size(659, 284);
            this.dgvFileCRC.TabIndex = 0;
            this.dgvFileCRC.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFileCRC_CellContentClick);
            // 
            // addButton
            // 
            this.addButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addButton.Location = new System.Drawing.Point(468, 293);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(94, 30);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deleteButton.Location = new System.Drawing.Point(568, 293);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(94, 30);
            this.deleteButton.TabIndex = 2;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 3;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpMain.Controls.Add(this.dgvFileCRC, 0, 0);
            this.tlpMain.Controls.Add(this.deleteButton, 2, 1);
            this.tlpMain.Controls.Add(this.addButton, 1, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Margin = new System.Windows.Forms.Padding(10);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlpMain.Size = new System.Drawing.Size(665, 326);
            this.tlpMain.TabIndex = 3;
            // 
            // columnFile
            // 
            this.columnFile.HeaderText = "File";
            this.columnFile.Name = "columnFile";
            this.columnFile.ReadOnly = true;
            // 
            // columnCRC32
            // 
            this.columnCRC32.HeaderText = "CRC32";
            this.columnCRC32.Name = "columnCRC32";
            this.columnCRC32.ReadOnly = true;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 326);
            this.Controls.Add(this.tlpMain);
            this.Name = "MainWindow";
            this.Text = "Application for Ancud";
            this.Load += new System.EventHandler(this.AppForAncud_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFileCRC)).EndInit();
            this.tlpMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvFileCRC;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnCRC32;
    }
}

