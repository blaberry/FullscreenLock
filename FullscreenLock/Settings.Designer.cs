namespace FullscreenLock
{
    partial class Settings
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
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageWhitelist = new System.Windows.Forms.TabPage();
            this.dataGridViewWhitelist = new System.Windows.Forms.DataGridView();
            this.ColProgram = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControlMain.SuspendLayout();
            this.tabPageWhitelist.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWhitelist)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageWhitelist);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(639, 450);
            this.tabControlMain.TabIndex = 0;
            // 
            // tabPageWhitelist
            // 
            this.tabPageWhitelist.Controls.Add(this.dataGridViewWhitelist);
            this.tabPageWhitelist.Location = new System.Drawing.Point(4, 22);
            this.tabPageWhitelist.Name = "tabPageWhitelist";
            this.tabPageWhitelist.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageWhitelist.Size = new System.Drawing.Size(631, 424);
            this.tabPageWhitelist.TabIndex = 1;
            this.tabPageWhitelist.Text = "Whitelist";
            this.tabPageWhitelist.UseVisualStyleBackColor = true;
            // 
            // dataGridViewWhitelist
            // 
            this.dataGridViewWhitelist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewWhitelist.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColProgram});
            this.dataGridViewWhitelist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewWhitelist.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewWhitelist.Name = "dataGridViewWhitelist";
            this.dataGridViewWhitelist.Size = new System.Drawing.Size(625, 418);
            this.dataGridViewWhitelist.TabIndex = 0;
            // 
            // ColProgram
            // 
            this.ColProgram.HeaderText = "Full path to the whitelisted program";
            this.ColProgram.Name = "Program";
            this.ColProgram.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColProgram.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColProgram.ToolTipText = "like \'C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe\'";
            this.ColProgram.Width = 550;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(639, 450);
            this.Controls.Add(this.tabControlMain);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(655, 489);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(655, 489);
            this.Name = "Settings";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Settings_FormClosing);
            this.tabControlMain.ResumeLayout(false);
            this.tabPageWhitelist.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWhitelist)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageWhitelist;
        private System.Windows.Forms.DataGridView dataGridViewWhitelist;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColProgram;
    }
}