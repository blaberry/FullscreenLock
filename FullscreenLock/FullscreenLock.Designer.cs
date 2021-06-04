using System.Windows.Forms;

namespace FullscreenLock
{
    partial class FullscreenLock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FullscreenLock));
            this.ToggleButton = new System.Windows.Forms.Button();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.MadeByLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ToggleButton
            // 
            this.ToggleButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ToggleButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToggleButton.Location = new System.Drawing.Point(57, 12);
            this.ToggleButton.Name = "ToggleButton";
            this.ToggleButton.Size = new System.Drawing.Size(113, 37);
            this.ToggleButton.TabIndex = 0;
            this.ToggleButton.Text = "Toggle";
            this.ToggleButton.UseVisualStyleBackColor = true;
            this.ToggleButton.Click += new System.EventHandler(this.ToggleButton_Click);
            // 
            // StatusLabel
            // 
            this.StatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.StatusLabel.Location = new System.Drawing.Point(-1, 52);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(230, 24);
            this.StatusLabel.TabIndex = 1;
            this.StatusLabel.Text = "Waiting for focus";
            this.StatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MadeByLabel
            // 
            this.MadeByLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.MadeByLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.MadeByLabel.Location = new System.Drawing.Point(12, 88);
            this.MadeByLabel.Name = "MadeByLabel";
            this.MadeByLabel.Size = new System.Drawing.Size(205, 44);
            this.MadeByLabel.TabIndex = 2;
            this.MadeByLabel.Text = "✨ Made by Blåberry and the community ✨";
            this.MadeByLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FullscreenLock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(229, 141);
            this.Controls.Add(this.ToggleButton);
            this.Controls.Add(this.MadeByLabel);
            this.Controls.Add(this.StatusLabel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(245, 180);
            this.MinimumSize = new System.Drawing.Size(245, 180);
            this.Name = "FullscreenLock";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "FullscreenLock";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FullscreenLock_FormClosed);
            this.Resize += new System.EventHandler(this.FullscreenLock_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ToggleButton;
        public System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Label MadeByLabel;
    }
}
