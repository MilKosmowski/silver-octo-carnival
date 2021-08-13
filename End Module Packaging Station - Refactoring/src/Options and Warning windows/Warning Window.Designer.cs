namespace Central_pack_Refactoring
{
    partial class PopupWindow
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
            this.labelMsgBox = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.labelTime = new System.Windows.Forms.Label();
            this.timerClose = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // labelMsgBox
            // 
            this.labelMsgBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelMsgBox.BackColor = System.Drawing.Color.LightGreen;
            this.labelMsgBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelMsgBox.Location = new System.Drawing.Point(58, 9);
            this.labelMsgBox.MaximumSize = new System.Drawing.Size(650, 350);
            this.labelMsgBox.Name = "labelMsgBox";
            this.labelMsgBox.Size = new System.Drawing.Size(649, 350);
            this.labelMsgBox.TabIndex = 0;
            this.labelMsgBox.Text = "-";
            // 
            // buttonClose
            // 
            this.buttonClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonClose.Location = new System.Drawing.Point(158, 410);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(446, 71);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.Text = "OK";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // labelTime
            // 
            this.labelTime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelTime.BackColor = System.Drawing.Color.Transparent;
            this.labelTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelTime.Location = new System.Drawing.Point(351, 370);
            this.labelTime.MaximumSize = new System.Drawing.Size(650, 350);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(89, 37);
            this.labelTime.TabIndex = 2;
            this.labelTime.Text = "3.";
            // 
            // timerClose
            // 
            this.timerClose.Enabled = true;
            this.timerClose.Interval = 500;
            this.timerClose.Tick += new System.EventHandler(this.timerClose_Tick);
            // 
            // PopupWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGreen;
            this.ClientSize = new System.Drawing.Size(762, 493);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.labelMsgBox);
            this.Name = "PopupWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Uwaga";
            this.TopMost = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyExit);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelMsgBox;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Timer timerClose;
    }
}