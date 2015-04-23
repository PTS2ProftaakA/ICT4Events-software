namespace Proftaak_ICT4Events.UI
{
    partial class UILogIn
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
            this.lblInlogName = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.tbInlogName = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.lblExplain = new System.Windows.Forms.Label();
            this.btnLogIn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblInlogName
            // 
            this.lblInlogName.AutoSize = true;
            this.lblInlogName.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInlogName.Location = new System.Drawing.Point(16, 11);
            this.lblInlogName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInlogName.Name = "lblInlogName";
            this.lblInlogName.Size = new System.Drawing.Size(194, 40);
            this.lblInlogName.TabIndex = 1;
            this.lblInlogName.Text = "Inlognaam";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(16, 84);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(230, 40);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Wachtwoord";
            // 
            // tbInlogName
            // 
            this.tbInlogName.Location = new System.Drawing.Point(24, 55);
            this.tbInlogName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbInlogName.Name = "tbInlogName";
            this.tbInlogName.Size = new System.Drawing.Size(241, 22);
            this.tbInlogName.TabIndex = 3;
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(24, 128);
            this.tbPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(241, 22);
            this.tbPassword.TabIndex = 4;
            // 
            // lblExplain
            // 
            this.lblExplain.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExplain.Location = new System.Drawing.Point(16, 220);
            this.lblExplain.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblExplain.Name = "lblExplain";
            this.lblExplain.Size = new System.Drawing.Size(256, 153);
            this.lblExplain.TabIndex = 5;
            this.lblExplain.Text = "Of log in door je RFID te scannen!";
            // 
            // btnLogIn
            // 
            this.btnLogIn.Location = new System.Drawing.Point(291, 55);
            this.btnLogIn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLogIn.Name = "btnLogIn";
            this.btnLogIn.Size = new System.Drawing.Size(117, 101);
            this.btnLogIn.TabIndex = 6;
            this.btnLogIn.Text = "Inloggen";
            this.btnLogIn.UseVisualStyleBackColor = true;
            this.btnLogIn.Click += new System.EventHandler(this.btnLogIn_Click);
            // 
            // UILogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 409);
            this.Controls.Add(this.btnLogIn);
            this.Controls.Add(this.lblExplain);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbInlogName);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblInlogName);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "UILogIn";
            this.Text = "Inloggen";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UILogIn_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInlogName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox tbInlogName;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label lblExplain;
        private System.Windows.Forms.Button btnLogIn;
    }
}