namespace Proftaak_ICT4Events
{
    partial class UIComment
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
            this.pbCommentProfile = new System.Windows.Forms.PictureBox();
            this.lblCommentName = new System.Windows.Forms.Label();
            this.lblComment = new System.Windows.Forms.Label();
            this.btnCommentLike = new System.Windows.Forms.Button();
            this.btnCommentReageer = new System.Windows.Forms.Button();
            this.lblCommentLike = new System.Windows.Forms.Label();
            this.lblCommentComment = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbCommentProfile)).BeginInit();
            this.SuspendLayout();
            // 
            // pbCommentProfile
            // 
            
            this.pbCommentProfile.Location = new System.Drawing.Point(3, 3);
            this.pbCommentProfile.Name = "pbCommentProfile";
            this.pbCommentProfile.Size = new System.Drawing.Size(80, 80);
            this.pbCommentProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCommentProfile.TabIndex = 0;
            this.pbCommentProfile.TabStop = false;
            // 
            // lblCommentName
            // 
            this.lblCommentName.AutoSize = true;
            this.lblCommentName.Location = new System.Drawing.Point(3, 86);
            this.lblCommentName.Name = "lblCommentName";
            this.lblCommentName.Size = new System.Drawing.Size(33, 13);
            this.lblCommentName.TabIndex = 1;
            this.lblCommentName.Text = "naam";
            // 
            // lblComment
            // 
            this.lblComment.Location = new System.Drawing.Point(90, 4);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(194, 79);
            this.lblComment.TabIndex = 2;
            this.lblComment.Text = "label1";
            // 
            // btnCommentLike
            // 
            this.btnCommentLike.Location = new System.Drawing.Point(83, 98);
            this.btnCommentLike.Name = "btnCommentLike";
            this.btnCommentLike.Size = new System.Drawing.Size(75, 23);
            this.btnCommentLike.TabIndex = 3;
            this.btnCommentLike.Text = "Like";
            this.btnCommentLike.UseVisualStyleBackColor = true;
            this.btnCommentLike.Click += new System.EventHandler(this.btnCommentLike_Click);
            // 
            // btnCommentReageer
            // 
            this.btnCommentReageer.Location = new System.Drawing.Point(195, 98);
            this.btnCommentReageer.Name = "btnCommentReageer";
            this.btnCommentReageer.Size = new System.Drawing.Size(75, 23);
            this.btnCommentReageer.TabIndex = 4;
            this.btnCommentReageer.Text = "Reageer";
            this.btnCommentReageer.UseVisualStyleBackColor = true;
            this.btnCommentReageer.Click += new System.EventHandler(this.btnCommentReageer_Click);
            // 
            // lblCommentLike
            // 
            this.lblCommentLike.AutoSize = true;
            this.lblCommentLike.Location = new System.Drawing.Point(164, 103);
            this.lblCommentLike.Name = "lblCommentLike";
            this.lblCommentLike.Size = new System.Drawing.Size(25, 13);
            this.lblCommentLike.TabIndex = 5;
            this.lblCommentLike.Text = "100";
            // 
            // lblCommentComment
            // 
            this.lblCommentComment.AutoSize = true;
            this.lblCommentComment.Location = new System.Drawing.Point(276, 103);
            this.lblCommentComment.Name = "lblCommentComment";
            this.lblCommentComment.Size = new System.Drawing.Size(25, 13);
            this.lblCommentComment.TabIndex = 6;
            this.lblCommentComment.Text = "100";
            // 
            // Reactie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblCommentComment);
            this.Controls.Add(this.lblCommentLike);
            this.Controls.Add(this.btnCommentReageer);
            this.Controls.Add(this.btnCommentLike);
            this.Controls.Add(this.lblComment);
            this.Controls.Add(this.lblCommentName);
            this.Controls.Add(this.pbCommentProfile);
            this.Name = "Reactie";
            this.Size = new System.Drawing.Size(337, 141);
            ((System.ComponentModel.ISupportInitialize)(this.pbCommentProfile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbCommentProfile;
        private System.Windows.Forms.Label lblCommentName;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.Button btnCommentLike;
        private System.Windows.Forms.Button btnCommentReageer;
        private System.Windows.Forms.Label lblCommentLike;
        private System.Windows.Forms.Label lblCommentComment;
    }
}
