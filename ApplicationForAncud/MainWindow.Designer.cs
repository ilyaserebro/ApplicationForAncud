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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvFileCRC = new System.Windows.Forms.DataGridView();
            this.columnFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnCRC32 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addButton = new System.Windows.Forms.Button();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.deleteButton = new System.Windows.Forms.Button();
            this.helpButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFileCRC)).BeginInit();
            this.tlpMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvFileCRC
            // 
            this.dgvFileCRC.AllowUserToAddRows = false;
            this.dgvFileCRC.AllowUserToResizeRows = false;
            this.dgvFileCRC.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFileCRC.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvFileCRC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFileCRC.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnId,
            this.columnFile,
            this.columnCRC32});
            this.tlpMain.SetColumnSpan(this.dgvFileCRC, 4);
            this.dgvFileCRC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFileCRC.EnableHeadersVisualStyles = false;
            this.dgvFileCRC.Location = new System.Drawing.Point(3, 3);
            this.dgvFileCRC.Name = "dgvFileCRC";
            this.dgvFileCRC.ReadOnly = true;
            this.dgvFileCRC.RowHeadersVisible = false;
            this.dgvFileCRC.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFileCRC.Size = new System.Drawing.Size(659, 284);
            this.dgvFileCRC.TabIndex = 0;
            this.dgvFileCRC.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFileCRC_CellClick);
            // 
            // columnFile
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            this.columnFile.DefaultCellStyle = dataGridViewCellStyle2;
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
            // columnId
            // 
            this.columnId.HeaderText = "ID";
            this.columnId.Name = "columnId";
            this.columnId.Visible = false;
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
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 4;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpMain.Controls.Add(this.dgvFileCRC, 0, 0);
            this.tlpMain.Controls.Add(this.deleteButton, 3, 1);
            this.tlpMain.Controls.Add(this.addButton, 2, 1);
            this.tlpMain.Controls.Add(this.helpButton, 0, 1);
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
            // deleteButton
            // 
            this.deleteButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deleteButton.Enabled = false;
            this.deleteButton.Location = new System.Drawing.Point(568, 293);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(94, 30);
            this.deleteButton.TabIndex = 2;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // helpButton
            // 
            this.helpButton.Location = new System.Drawing.Point(3, 293);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(94, 30);
            this.helpButton.TabIndex = 3;
            this.helpButton.Text = "Help";
            this.helpButton.UseVisualStyleBackColor = true;
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
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
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnCRC32;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnId;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button helpButton;
    }
}

