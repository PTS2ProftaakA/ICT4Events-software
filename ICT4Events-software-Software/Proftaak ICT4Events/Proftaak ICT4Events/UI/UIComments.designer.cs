namespace Proftaak_ICT4Events
{
    partial class Comments
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
            this.flpReactionsPost = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCommentsPost = new System.Windows.Forms.Button();
            this.tbCommentsPost = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // flpReactionsPost
            // 
            this.flpReactionsPost.AutoScroll = true;
            this.flpReactionsPost.Location = new System.Drawing.Point(12, 12);
            this.flpReactionsPost.Name = "flpReactionsPost";
            this.flpReactionsPost.Size = new System.Drawing.Size(808, 468);
            this.flpReactionsPost.TabIndex = 1;
            // 
            // btnCommentsPost
            // 
            this.btnCommentsPost.Location = new System.Drawing.Point(13, 506);
            this.btnCommentsPost.Name = "btnCommentsPost";
            this.btnCommentsPost.Size = new System.Drawing.Size(75, 23);
            this.btnCommentsPost.TabIndex = 2;
            this.btnCommentsPost.Text = "Post";
            this.btnCommentsPost.UseVisualStyleBackColor = true;
            this.btnCommentsPost.Click += new System.EventHandler(this.btnCommentsPost_Click);
            // 
            // tbCommentsPost
            // 
            this.tbCommentsPost.Location = new System.Drawing.Point(127, 508);
            this.tbCommentsPost.Name = "tbCommentsPost";
            this.tbCommentsPost.Size = new System.Drawing.Size(693, 20);
            this.tbCommentsPost.TabIndex = 3;
            // 
            // Reacties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 547);
            this.Controls.Add(this.tbCommentsPost);
            this.Controls.Add(this.btnCommentsPost);
            this.Controls.Add(this.flpReactionsPost);
            this.Name = "Reacties";
            this.Text = "Reacties";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpReactionsPost;
        private System.Windows.Forms.Button btnCommentsPost;
        private System.Windows.Forms.TextBox tbCommentsPost;

    }
}