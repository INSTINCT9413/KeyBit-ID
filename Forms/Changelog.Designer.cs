
namespace KeyBit_ID.Forms
{
    partial class Changelog
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
            this.changelogBrowser = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.txtVersion = new MaterialSkin.Controls.MaterialLabel();
            ((System.ComponentModel.ISupportInitialize)(this.changelogBrowser)).BeginInit();
            this.SuspendLayout();
            // 
            // changelogBrowser
            // 
            this.changelogBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.changelogBrowser.CreationProperties = null;
            this.changelogBrowser.DefaultBackgroundColor = System.Drawing.Color.White;
            this.changelogBrowser.Location = new System.Drawing.Point(6, 68);
            this.changelogBrowser.Name = "changelogBrowser";
            this.changelogBrowser.Size = new System.Drawing.Size(847, 474);
            this.changelogBrowser.TabIndex = 0;
            this.changelogBrowser.ZoomFactor = 1D;
            // 
            // txtVersion
            // 
            this.txtVersion.AutoSize = true;
            this.txtVersion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.txtVersion.Depth = 0;
            this.txtVersion.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtVersion.Location = new System.Drawing.Point(6, 45);
            this.txtVersion.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.Size = new System.Drawing.Size(40, 19);
            this.txtVersion.TabIndex = 0;
            this.txtVersion.Text = "NULL";
            // 
            // Changelog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(859, 547);
            this.Controls.Add(this.txtVersion);
            this.Controls.Add(this.changelogBrowser);
            this.Name = "Changelog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KeyBit ID - Changelog";
            this.Load += new System.EventHandler(this.Changelog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.changelogBrowser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 changelogBrowser;
        private MaterialSkin.Controls.MaterialLabel txtVersion;
    }
}