namespace Proftaak_ICT4Events
{
    partial class UIMainForm
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
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnGetHobby = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(12, 202);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(262, 39);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnGetHobby
            // 
            this.btnGetHobby.Location = new System.Drawing.Point(12, 156);
            this.btnGetHobby.Name = "btnGetHobby";
            this.btnGetHobby.Size = new System.Drawing.Size(262, 40);
            this.btnGetHobby.TabIndex = 1;
            this.btnGetHobby.Text = "Get hobby";
            this.btnGetHobby.UseVisualStyleBackColor = true;
            this.btnGetHobby.Click += new System.EventHandler(this.btnGetHobby_Click);
            // 
            // UIMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 253);
            this.Controls.Add(this.btnGetHobby);
            this.Controls.Add(this.btnConnect);
            this.Name = "UIMainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnGetHobby;
    }
}

