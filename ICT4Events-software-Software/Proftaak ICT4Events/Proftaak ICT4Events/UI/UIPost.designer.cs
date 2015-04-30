namespace Proftaak_ICT4Events
{
    partial class Post
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Post));
            this.btnPostLike = new System.Windows.Forms.Button();
            this.btnPostReageer = new System.Windows.Forms.Button();
            this.lblPostNaam = new System.Windows.Forms.Label();
            this.lblTextPostContent = new System.Windows.Forms.Label();
            this.lblPostLike = new System.Windows.Forms.Label();
            this.lblPostReageer = new System.Windows.Forms.Label();
            this.btnPostReport = new System.Windows.Forms.Button();
            this.pbPostPhoto = new System.Windows.Forms.PictureBox();
            this.pbPostProfPicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbPostPhoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPostProfPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPostLike
            // 
            this.btnPostLike.Location = new System.Drawing.Point(102, 132);
            this.btnPostLike.Name = "btnPostLike";
            this.btnPostLike.Size = new System.Drawing.Size(101, 23);
            this.btnPostLike.TabIndex = 0;
            this.btnPostLike.Text = "Like";
            this.btnPostLike.UseVisualStyleBackColor = true;
            this.btnPostLike.Click += new System.EventHandler(this.btnPostLike_Click);
            // 
            // btnPostReageer
            // 
            this.btnPostReageer.Location = new System.Drawing.Point(264, 132);
            this.btnPostReageer.Name = "btnPostReageer";
            this.btnPostReageer.Size = new System.Drawing.Size(75, 23);
            this.btnPostReageer.TabIndex = 1;
            this.btnPostReageer.Text = "Reageer";
            this.btnPostReageer.UseVisualStyleBackColor = true;
            this.btnPostReageer.Click += new System.EventHandler(this.btnPostReageer_Click);
            // 
            // lblPostNaam
            // 
            this.lblPostNaam.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPostNaam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblPostNaam.Location = new System.Drawing.Point(9, 99);
            this.lblPostNaam.Name = "lblPostNaam";
            this.lblPostNaam.Size = new System.Drawing.Size(84, 48);
            this.lblPostNaam.TabIndex = 3;
            this.lblPostNaam.Text = "Naam";
            // 
            // lblTextPostContent
            // 
            this.lblTextPostContent.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextPostContent.Location = new System.Drawing.Point(99, 12);
            this.lblTextPostContent.Name = "lblTextPostContent";
            this.lblTextPostContent.Size = new System.Drawing.Size(305, 117);
            this.lblTextPostContent.TabIndex = 4;
            this.lblTextPostContent.Text = resources.GetString("lblTextPostContent.Text");
            // 
            // lblPostLike
            // 
            this.lblPostLike.AutoSize = true;
            this.lblPostLike.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPostLike.Location = new System.Drawing.Point(209, 132);
            this.lblPostLike.Name = "lblPostLike";
            this.lblPostLike.Size = new System.Drawing.Size(19, 21);
            this.lblPostLike.TabIndex = 5;
            this.lblPostLike.Text = "1";
            // 
            // lblPostReageer
            // 
            this.lblPostReageer.AutoSize = true;
            this.lblPostReageer.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPostReageer.Location = new System.Drawing.Point(345, 132);
            this.lblPostReageer.Name = "lblPostReageer";
            this.lblPostReageer.Size = new System.Drawing.Size(19, 21);
            this.lblPostReageer.TabIndex = 6;
            this.lblPostReageer.Text = "1";
            // 
            // btnPostReport
            // 
            this.btnPostReport.Location = new System.Drawing.Point(12, 146);
            this.btnPostReport.Name = "btnPostReport";
            this.btnPostReport.Size = new System.Drawing.Size(15, 16);
            this.btnPostReport.TabIndex = 9;
            this.btnPostReport.Text = "X";
            this.btnPostReport.UseVisualStyleBackColor = true;
            this.btnPostReport.Click += new System.EventHandler(this.btnPostReport_Click);
            // 
            // pbPostPhoto
            // 
            this.pbPostPhoto.Enabled = false;
            this.pbPostPhoto.Image = ((System.Drawing.Image)(resources.GetObject("pbPostPhoto.Image")));
            this.pbPostPhoto.Location = new System.Drawing.Point(101, 12);
            this.pbPostPhoto.Name = "pbPostPhoto";
            this.pbPostPhoto.Size = new System.Drawing.Size(240, 205);
            this.pbPostPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPostPhoto.TabIndex = 7;
            this.pbPostPhoto.TabStop = false;
            this.pbPostPhoto.Visible = false;
            // 
            // pbPostProfPicture
            // 
            this.pbPostProfPicture.Image = ((System.Drawing.Image)(resources.GetObject("pbPostProfPicture.Image")));
            this.pbPostProfPicture.Location = new System.Drawing.Point(12, 12);
            this.pbPostProfPicture.Name = "pbPostProfPicture";
            this.pbPostProfPicture.Size = new System.Drawing.Size(81, 81);
            this.pbPostProfPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPostProfPicture.TabIndex = 2;
            this.pbPostProfPicture.TabStop = false;
            // 
            // Post
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.Controls.Add(this.btnPostReport);
            this.Controls.Add(this.lblPostLike);
            this.Controls.Add(this.lblPostReageer);
            this.Controls.Add(this.lblTextPostContent);
            this.Controls.Add(this.lblPostNaam);
            this.Controls.Add(this.pbPostProfPicture);
            this.Controls.Add(this.btnPostReageer);
            this.Controls.Add(this.btnPostLike);
            this.Controls.Add(this.pbPostPhoto);
            this.Name = "Post";
            this.Size = new System.Drawing.Size(400, 172);
            ((System.ComponentModel.ISupportInitialize)(this.pbPostPhoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPostProfPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPostLike;
        private System.Windows.Forms.Button btnPostReageer;
        private System.Windows.Forms.PictureBox pbPostProfPicture;
        private System.Windows.Forms.Label lblPostNaam;
        private System.Windows.Forms.Label lblTextPostContent;
        private System.Windows.Forms.Label lblPostLike;
        private System.Windows.Forms.Label lblPostReageer;
        private System.Windows.Forms.PictureBox pbPostPhoto;

        private System.Windows.Forms.Button btnPostReport;
    }
}
