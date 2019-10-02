namespace BillApp
{
    partial class View
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
            this.tvList = new System.Windows.Forms.TreeView();
            this.lbList = new System.Windows.Forms.Label();
            this.btAddItem = new System.Windows.Forms.Button();
            this.btDelItem = new System.Windows.Forms.Button();
            this.btBillPath = new System.Windows.Forms.Button();
            this.lbBill = new System.Windows.Forms.Label();
            this.tbBillPath = new System.Windows.Forms.TextBox();
            this.tbOutputFolder = new System.Windows.Forms.TextBox();
            this.btOutputFolder = new System.Windows.Forms.Button();
            this.lbOutputFolder = new System.Windows.Forms.Label();
            this.btGenerate = new System.Windows.Forms.Button();
            this.tbOutputFileName = new System.Windows.Forms.TextBox();
            this.lbOutputFileName = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.sbInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.rbES = new System.Windows.Forms.RadioButton();
            this.rbEN = new System.Windows.Forms.RadioButton();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvList
            // 
            this.tvList.CheckBoxes = true;
            this.tvList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvList.Location = new System.Drawing.Point(12, 35);
            this.tvList.Name = "tvList";
            this.tvList.Size = new System.Drawing.Size(697, 184);
            this.tvList.TabIndex = 2;
            // 
            // lbList
            // 
            this.lbList.AutoSize = true;
            this.lbList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbList.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbList.Location = new System.Drawing.Point(12, 13);
            this.lbList.Name = "lbList";
            this.lbList.Size = new System.Drawing.Size(100, 16);
            this.lbList.TabIndex = 1;
            this.lbList.Text = "Packing Lists";
            // 
            // btAddItem
            // 
            this.btAddItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAddItem.Location = new System.Drawing.Point(603, 9);
            this.btAddItem.Name = "btAddItem";
            this.btAddItem.Size = new System.Drawing.Size(106, 23);
            this.btAddItem.TabIndex = 0;
            this.btAddItem.Text = "Select";
            this.btAddItem.UseVisualStyleBackColor = true;
            this.btAddItem.Click += new System.EventHandler(this.btAddItem_Click);
            // 
            // btDelItem
            // 
            this.btDelItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDelItem.Location = new System.Drawing.Point(491, 9);
            this.btDelItem.Name = "btDelItem";
            this.btDelItem.Size = new System.Drawing.Size(106, 23);
            this.btDelItem.TabIndex = 1;
            this.btDelItem.Text = "Remove";
            this.btDelItem.UseVisualStyleBackColor = true;
            this.btDelItem.Click += new System.EventHandler(this.btDelItem_Click);
            // 
            // btBillPath
            // 
            this.btBillPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBillPath.Location = new System.Drawing.Point(603, 225);
            this.btBillPath.Name = "btBillPath";
            this.btBillPath.Size = new System.Drawing.Size(106, 23);
            this.btBillPath.TabIndex = 3;
            this.btBillPath.Text = "Select";
            this.btBillPath.UseVisualStyleBackColor = true;
            this.btBillPath.Click += new System.EventHandler(this.btBillPath_Click);
            // 
            // lbBill
            // 
            this.lbBill.AutoSize = true;
            this.lbBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBill.Location = new System.Drawing.Point(12, 229);
            this.lbBill.Name = "lbBill";
            this.lbBill.Size = new System.Drawing.Size(30, 16);
            this.lbBill.TabIndex = 5;
            this.lbBill.Text = "Bill";
            // 
            // tbBillPath
            // 
            this.tbBillPath.Location = new System.Drawing.Point(12, 250);
            this.tbBillPath.Name = "tbBillPath";
            this.tbBillPath.ReadOnly = true;
            this.tbBillPath.Size = new System.Drawing.Size(697, 20);
            this.tbBillPath.TabIndex = 8;
            // 
            // tbOutputFolder
            // 
            this.tbOutputFolder.Location = new System.Drawing.Point(12, 302);
            this.tbOutputFolder.Name = "tbOutputFolder";
            this.tbOutputFolder.ReadOnly = true;
            this.tbOutputFolder.Size = new System.Drawing.Size(697, 20);
            this.tbOutputFolder.TabIndex = 11;
            // 
            // btOutputFolder
            // 
            this.btOutputFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btOutputFolder.Location = new System.Drawing.Point(603, 276);
            this.btOutputFolder.Name = "btOutputFolder";
            this.btOutputFolder.Size = new System.Drawing.Size(106, 23);
            this.btOutputFolder.TabIndex = 4;
            this.btOutputFolder.Text = "Select";
            this.btOutputFolder.UseVisualStyleBackColor = true;
            this.btOutputFolder.Click += new System.EventHandler(this.btOutputFolder_Click);
            // 
            // lbOutputFolder
            // 
            this.lbOutputFolder.AutoSize = true;
            this.lbOutputFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOutputFolder.Location = new System.Drawing.Point(12, 280);
            this.lbOutputFolder.Name = "lbOutputFolder";
            this.lbOutputFolder.Size = new System.Drawing.Size(101, 16);
            this.lbOutputFolder.TabIndex = 9;
            this.lbOutputFolder.Text = "Output Folder";
            // 
            // btGenerate
            // 
            this.btGenerate.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btGenerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btGenerate.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btGenerate.Location = new System.Drawing.Point(521, 336);
            this.btGenerate.Name = "btGenerate";
            this.btGenerate.Size = new System.Drawing.Size(188, 42);
            this.btGenerate.TabIndex = 6;
            this.btGenerate.Text = "Generate";
            this.btGenerate.UseVisualStyleBackColor = false;
            this.btGenerate.Click += new System.EventHandler(this.btGenerate_Click);
            // 
            // tbOutputFileName
            // 
            this.tbOutputFileName.Location = new System.Drawing.Point(12, 358);
            this.tbOutputFileName.Name = "tbOutputFileName";
            this.tbOutputFileName.Size = new System.Drawing.Size(469, 20);
            this.tbOutputFileName.TabIndex = 5;
            // 
            // lbOutputFileName
            // 
            this.lbOutputFileName.AutoSize = true;
            this.lbOutputFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOutputFileName.Location = new System.Drawing.Point(12, 336);
            this.lbOutputFileName.Name = "lbOutputFileName";
            this.lbOutputFileName.Size = new System.Drawing.Size(135, 16);
            this.lbOutputFileName.TabIndex = 13;
            this.lbOutputFileName.Text = "Output Files Name";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbInfo});
            this.statusStrip1.Location = new System.Drawing.Point(0, 392);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(723, 22);
            this.statusStrip1.TabIndex = 14;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // sbInfo
            // 
            this.sbInfo.Name = "sbInfo";
            this.sbInfo.Size = new System.Drawing.Size(0, 17);
            // 
            // rbES
            // 
            this.rbES.AutoSize = true;
            this.rbES.Checked = true;
            this.rbES.Location = new System.Drawing.Point(335, 225);
            this.rbES.Name = "rbES";
            this.rbES.Size = new System.Drawing.Size(63, 17);
            this.rbES.TabIndex = 15;
            this.rbES.TabStop = true;
            this.rbES.Text = "Spanish";
            this.rbES.UseVisualStyleBackColor = true;
            // 
            // rbEN
            // 
            this.rbEN.AutoSize = true;
            this.rbEN.Location = new System.Drawing.Point(450, 225);
            this.rbEN.Name = "rbEN";
            this.rbEN.Size = new System.Drawing.Size(59, 17);
            this.rbEN.TabIndex = 16;
            this.rbEN.Text = "English";
            this.rbEN.UseVisualStyleBackColor = true;
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 414);
            this.Controls.Add(this.rbEN);
            this.Controls.Add(this.rbES);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tbOutputFileName);
            this.Controls.Add(this.lbOutputFileName);
            this.Controls.Add(this.btGenerate);
            this.Controls.Add(this.tbOutputFolder);
            this.Controls.Add(this.btOutputFolder);
            this.Controls.Add(this.lbOutputFolder);
            this.Controls.Add(this.tbBillPath);
            this.Controls.Add(this.btBillPath);
            this.Controls.Add(this.lbBill);
            this.Controls.Add(this.btDelItem);
            this.Controls.Add(this.btAddItem);
            this.Controls.Add(this.lbList);
            this.Controls.Add(this.tvList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "View";
            this.Text = "BillApp";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvList;
        private System.Windows.Forms.Label lbList;
        private System.Windows.Forms.Button btAddItem;
        private System.Windows.Forms.Button btDelItem;
        private System.Windows.Forms.Button btBillPath;
        private System.Windows.Forms.Label lbBill;
        private System.Windows.Forms.TextBox tbBillPath;
        private System.Windows.Forms.TextBox tbOutputFolder;
        private System.Windows.Forms.Button btOutputFolder;
        private System.Windows.Forms.Label lbOutputFolder;
        private System.Windows.Forms.Button btGenerate;
        private System.Windows.Forms.TextBox tbOutputFileName;
        private System.Windows.Forms.Label lbOutputFileName;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel sbInfo;
        private System.Windows.Forms.RadioButton rbES;
        private System.Windows.Forms.RadioButton rbEN;
    }
}

