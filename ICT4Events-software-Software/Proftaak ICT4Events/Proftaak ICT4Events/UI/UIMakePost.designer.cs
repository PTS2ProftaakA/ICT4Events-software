namespace Proftaak_ICT4Events.UI
{
    partial class makePost
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
            this.lblPostMakeType = new System.Windows.Forms.Label();
            this.cbPostMakeType = new System.Windows.Forms.ComboBox();
            this.lblPostMakeText = new System.Windows.Forms.Label();
            this.tbPostMakeText = new System.Windows.Forms.TextBox();
            this.btnMakePostBrowse = new System.Windows.Forms.Button();
            this.btnMakePostPost = new System.Windows.Forms.Button();
            this.tbMakePostPath = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblPostMakeType
            // 
            this.lblPostMakeType.AutoSize = true;
            this.lblPostMakeType.Location = new System.Drawing.Point(47, 13);
            this.lblPostMakeType.Name = "lblPostMakeType";
            this.lblPostMakeType.Size = new System.Drawing.Size(31, 13);
            this.lblPostMakeType.TabIndex = 0;
            this.lblPostMakeType.Text = "Type";
            // 
            // cbPostMakeType
            // 
            this.cbPostMakeType.FormattingEnabled = true;
            this.cbPostMakeType.Location = new System.Drawing.Point(50, 29);
            this.cbPostMakeType.Name = "cbPostMakeType";
            this.cbPostMakeType.Size = new System.Drawing.Size(121, 21);
            this.cbPostMakeType.TabIndex = 1;
            // 
            // lblPostMakeText
            // 
            this.lblPostMakeText.AutoSize = true;
            this.lblPostMakeText.Location = new System.Drawing.Point(50, 57);
            this.lblPostMakeText.Name = "lblPostMakeText";
            this.lblPostMakeText.Size = new System.Drawing.Size(28, 13);
            this.lblPostMakeText.TabIndex = 2;
            this.lblPostMakeText.Text = "Text";
            // 
            // tbPostMakeText
            // 
            this.tbPostMakeText.Location = new System.Drawing.Point(50, 83);
            this.tbPostMakeText.Multiline = true;
            this.tbPostMakeText.Name = "tbPostMakeText";
            this.tbPostMakeText.Size = new System.Drawing.Size(174, 150);
            this.tbPostMakeText.TabIndex = 3;
            // 
            // btnMakePostBrowse
            // 
            this.btnMakePostBrowse.Location = new System.Drawing.Point(253, 81);
            this.btnMakePostBrowse.Name = "btnMakePostBrowse";
            this.btnMakePostBrowse.Size = new System.Drawing.Size(133, 23);
            this.btnMakePostBrowse.TabIndex = 4;
            this.btnMakePostBrowse.Text = "browse for file";
            this.btnMakePostBrowse.UseVisualStyleBackColor = true;
            this.btnMakePostBrowse.Click += new System.EventHandler(this.btnMakePostBrowse_Click);
            // 
            // btnMakePostPost
            // 
            this.btnMakePostPost.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnMakePostPost.Location = new System.Drawing.Point(50, 286);
            this.btnMakePostPost.Name = "btnMakePostPost";
            this.btnMakePostPost.Size = new System.Drawing.Size(75, 23);
            this.btnMakePostPost.TabIndex = 6;
            this.btnMakePostPost.Text = "Post";
            this.btnMakePostPost.UseVisualStyleBackColor = true;
            this.btnMakePostPost.Click += new System.EventHandler(this.btnMakePostPost_Click);
            // 
            // tbMakePostPath
            // 
            this.tbMakePostPath.Location = new System.Drawing.Point(253, 110);
            this.tbMakePostPath.Name = "tbMakePostPath";
            this.tbMakePostPath.Size = new System.Drawing.Size(202, 20);
            this.tbMakePostPath.TabIndex = 7;
            // 
            // makePost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 352);
            this.Controls.Add(this.tbMakePostPath);
            this.Controls.Add(this.btnMakePostPost);
            this.Controls.Add(this.btnMakePostBrowse);
            this.Controls.Add(this.tbPostMakeText);
            this.Controls.Add(this.lblPostMakeText);
            this.Controls.Add(this.cbPostMakeType);
            this.Controls.Add(this.lblPostMakeType);
            this.Name = "makePost";
            this.Text = "MakePost";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPostMakeType;
        private System.Windows.Forms.ComboBox cbPostMakeType;
        private System.Windows.Forms.Label lblPostMakeText;
        private System.Windows.Forms.TextBox tbPostMakeText;
        private System.Windows.Forms.Button btnMakePostBrowse;
        private System.Windows.Forms.Button btnMakePostPost;
        private System.Windows.Forms.TextBox tbMakePostPath;
    }
}