namespace Proftaak_ICT4Events
{
    partial class UIInloggen
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
            this.btnInloggen = new System.Windows.Forms.Button();
            this.lblGebruikersNaam = new System.Windows.Forms.Label();
            this.tbGebruikersNaam = new System.Windows.Forms.TextBox();
            this.lblEmailAddress = new System.Windows.Forms.Label();
            this.tbEmailAdress = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnInloggen
            // 
            this.btnInloggen.Font = new System.Drawing.Font("Roboto", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInloggen.Location = new System.Drawing.Point(101, 148);
            this.btnInloggen.Margin = new System.Windows.Forms.Padding(2);
            this.btnInloggen.Name = "btnInloggen";
            this.btnInloggen.Size = new System.Drawing.Size(193, 35);
            this.btnInloggen.TabIndex = 8;
            this.btnInloggen.Text = "Inloggen";
            this.btnInloggen.UseVisualStyleBackColor = true;
            // 
            // lblGebruikersNaam
            // 
            this.lblGebruikersNaam.AutoSize = true;
            this.lblGebruikersNaam.Font = new System.Drawing.Font("Roboto", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGebruikersNaam.Location = new System.Drawing.Point(90, 16);
            this.lblGebruikersNaam.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGebruikersNaam.Name = "lblGebruikersNaam";
            this.lblGebruikersNaam.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblGebruikersNaam.Size = new System.Drawing.Size(224, 35);
            this.lblGebruikersNaam.TabIndex = 10;
            this.lblGebruikersNaam.Text = "Gebruikers Naam";
            // 
            // tbGebruikersNaam
            // 
            this.tbGebruikersNaam.Location = new System.Drawing.Point(101, 53);
            this.tbGebruikersNaam.Margin = new System.Windows.Forms.Padding(2);
            this.tbGebruikersNaam.Name = "tbGebruikersNaam";
            this.tbGebruikersNaam.Size = new System.Drawing.Size(193, 20);
            this.tbGebruikersNaam.TabIndex = 11;
            // 
            // lblEmailAddress
            // 
            this.lblEmailAddress.AutoSize = true;
            this.lblEmailAddress.Font = new System.Drawing.Font("Roboto", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmailAddress.Location = new System.Drawing.Point(122, 75);
            this.lblEmailAddress.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEmailAddress.Name = "lblEmailAddress";
            this.lblEmailAddress.Size = new System.Drawing.Size(158, 35);
            this.lblEmailAddress.TabIndex = 12;
            this.lblEmailAddress.Text = "E-mailadres";
            // 
            // tbEmailAdress
            // 
            this.tbEmailAdress.Location = new System.Drawing.Point(101, 113);
            this.tbEmailAdress.Name = "tbEmailAdress";
            this.tbEmailAdress.Size = new System.Drawing.Size(193, 20);
            this.tbEmailAdress.TabIndex = 13;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblGebruikersNaam);
            this.groupBox1.Controls.Add(this.btnInloggen);
            this.groupBox1.Controls.Add(this.tbEmailAdress);
            this.groupBox1.Controls.Add(this.tbGebruikersNaam);
            this.groupBox1.Controls.Add(this.lblEmailAddress);
            this.groupBox1.Location = new System.Drawing.Point(44, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(391, 204);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            // 
            // UIInloggen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 286);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UIInloggen";
            this.Text = "UIInloggen";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnInloggen;
        private System.Windows.Forms.Label lblGebruikersNaam;
        private System.Windows.Forms.TextBox tbGebruikersNaam;
        private System.Windows.Forms.Label lblEmailAddress;
        private System.Windows.Forms.TextBox tbEmailAdress;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}