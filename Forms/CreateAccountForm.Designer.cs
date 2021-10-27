
namespace KeyBit_ID.Forms
{
    partial class CreateAccountForm
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
            this.linklblLogin = new System.Windows.Forms.LinkLabel();
            this.lblHaveAccount = new System.Windows.Forms.Label();
            this.lblCreate = new System.Windows.Forms.Label();
            this.btnCreateAccount = new MaterialSkin.Controls.MaterialButton();
            this.txtPassword = new MaterialSkin.Controls.MaterialTextBox();
            this.txtFirstName = new MaterialSkin.Controls.MaterialTextBox();
            this.cbShowPass = new MaterialSkin.Controls.MaterialCheckbox();
            this.txtLastName = new MaterialSkin.Controls.MaterialTextBox();
            this.txtEmail = new MaterialSkin.Controls.MaterialTextBox();
            this.txtMasterPassword = new MaterialSkin.Controls.MaterialTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // linklblLogin
            // 
            this.linklblLogin.AutoSize = true;
            this.linklblLogin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linklblLogin.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linklblLogin.LinkColor = System.Drawing.Color.DodgerBlue;
            this.linklblLogin.Location = new System.Drawing.Point(198, 46);
            this.linklblLogin.Name = "linklblLogin";
            this.linklblLogin.Size = new System.Drawing.Size(49, 21);
            this.linklblLogin.TabIndex = 11;
            this.linklblLogin.TabStop = true;
            this.linklblLogin.Text = "Login";
            this.linklblLogin.VisitedLinkColor = System.Drawing.Color.DodgerBlue;
            this.linklblLogin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinklblLogin_LinkClicked);
            // 
            // lblHaveAccount
            // 
            this.lblHaveAccount.AutoSize = true;
            this.lblHaveAccount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHaveAccount.ForeColor = System.Drawing.Color.White;
            this.lblHaveAccount.Location = new System.Drawing.Point(15, 46);
            this.lblHaveAccount.Name = "lblHaveAccount";
            this.lblHaveAccount.Size = new System.Drawing.Size(186, 21);
            this.lblHaveAccount.TabIndex = 10;
            this.lblHaveAccount.Text = "Already have an account?";
            // 
            // lblCreate
            // 
            this.lblCreate.AutoSize = true;
            this.lblCreate.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreate.ForeColor = System.Drawing.Color.White;
            this.lblCreate.Location = new System.Drawing.Point(12, 9);
            this.lblCreate.Name = "lblCreate";
            this.lblCreate.Size = new System.Drawing.Size(197, 37);
            this.lblCreate.TabIndex = 9;
            this.lblCreate.Text = "Create Account";
            // 
            // btnCreateAccount
            // 
            this.btnCreateAccount.AutoSize = false;
            this.btnCreateAccount.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCreateAccount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreateAccount.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnCreateAccount.Depth = 0;
            this.btnCreateAccount.HighEmphasis = true;
            this.btnCreateAccount.Icon = null;
            this.btnCreateAccount.Location = new System.Drawing.Point(93, 435);
            this.btnCreateAccount.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCreateAccount.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCreateAccount.Name = "btnCreateAccount";
            this.btnCreateAccount.Size = new System.Drawing.Size(187, 45);
            this.btnCreateAccount.TabIndex = 21;
            this.btnCreateAccount.Text = "Create Account";
            this.btnCreateAccount.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnCreateAccount.UseAccentColor = false;
            this.btnCreateAccount.UseVisualStyleBackColor = true;
            this.btnCreateAccount.Click += new System.EventHandler(this.BtnCreateAccount_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.Depth = 0;
            this.txtPassword.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtPassword.Hint = "Password";
            this.txtPassword.LeadingIcon = null;
            this.txtPassword.Location = new System.Drawing.Point(40, 277);
            this.txtPassword.MaxLength = 50;
            this.txtPassword.MouseState = MaterialSkin.MouseState.OUT;
            this.txtPassword.Multiline = false;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Password = true;
            this.txtPassword.Size = new System.Drawing.Size(304, 50);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.Text = "";
            this.txtPassword.TrailingIcon = null;
            // 
            // txtFirstName
            // 
            this.txtFirstName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFirstName.Depth = 0;
            this.txtFirstName.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtFirstName.Hint = "First Name";
            this.txtFirstName.LeadingIcon = null;
            this.txtFirstName.Location = new System.Drawing.Point(40, 88);
            this.txtFirstName.MaxLength = 50;
            this.txtFirstName.MouseState = MaterialSkin.MouseState.OUT;
            this.txtFirstName.Multiline = false;
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(304, 50);
            this.txtFirstName.TabIndex = 0;
            this.txtFirstName.Text = "";
            this.txtFirstName.TrailingIcon = null;
            // 
            // cbShowPass
            // 
            this.cbShowPass.AutoSize = true;
            this.cbShowPass.Depth = 0;
            this.cbShowPass.ForeColor = System.Drawing.Color.White;
            this.cbShowPass.Location = new System.Drawing.Point(40, 392);
            this.cbShowPass.Margin = new System.Windows.Forms.Padding(0);
            this.cbShowPass.MouseLocation = new System.Drawing.Point(-1, -1);
            this.cbShowPass.MouseState = MaterialSkin.MouseState.HOVER;
            this.cbShowPass.Name = "cbShowPass";
            this.cbShowPass.Ripple = true;
            this.cbShowPass.Size = new System.Drawing.Size(157, 37);
            this.cbShowPass.TabIndex = 24;
            this.cbShowPass.Text = "Show Passwords";
            this.cbShowPass.UseVisualStyleBackColor = true;
            this.cbShowPass.CheckedChanged += new System.EventHandler(this.CbRemember_CheckedChanged);
            // 
            // txtLastName
            // 
            this.txtLastName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLastName.Depth = 0;
            this.txtLastName.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtLastName.Hint = "Last Name";
            this.txtLastName.LeadingIcon = null;
            this.txtLastName.Location = new System.Drawing.Point(40, 151);
            this.txtLastName.MaxLength = 50;
            this.txtLastName.MouseState = MaterialSkin.MouseState.OUT;
            this.txtLastName.Multiline = false;
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(304, 50);
            this.txtLastName.TabIndex = 1;
            this.txtLastName.Text = "";
            this.txtLastName.TrailingIcon = null;
            // 
            // txtEmail
            // 
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEmail.Depth = 0;
            this.txtEmail.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtEmail.Hint = "Email";
            this.txtEmail.LeadingIcon = null;
            this.txtEmail.Location = new System.Drawing.Point(40, 214);
            this.txtEmail.MaxLength = 50;
            this.txtEmail.MouseState = MaterialSkin.MouseState.OUT;
            this.txtEmail.Multiline = false;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(304, 50);
            this.txtEmail.TabIndex = 2;
            this.txtEmail.Text = "";
            this.txtEmail.TrailingIcon = null;
            // 
            // txtMasterPassword
            // 
            this.txtMasterPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMasterPassword.Depth = 0;
            this.txtMasterPassword.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtMasterPassword.Hint = "Master Password";
            this.txtMasterPassword.LeadingIcon = null;
            this.txtMasterPassword.Location = new System.Drawing.Point(40, 340);
            this.txtMasterPassword.MaxLength = 50;
            this.txtMasterPassword.MouseState = MaterialSkin.MouseState.OUT;
            this.txtMasterPassword.Multiline = false;
            this.txtMasterPassword.Name = "txtMasterPassword";
            this.txtMasterPassword.Password = true;
            this.txtMasterPassword.Size = new System.Drawing.Size(304, 50);
            this.txtMasterPassword.TabIndex = 4;
            this.txtMasterPassword.Text = "";
            this.txtMasterPassword.TrailingIcon = null;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::KeyBit_ID.Properties.Resources.website_96px;
            this.pictureBox1.Location = new System.Drawing.Point(294, 17);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::KeyBit_ID.Properties.Resources._282;
            this.pictureBox2.Location = new System.Drawing.Point(309, 438);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(35, 35);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 26;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            // 
            // CreateAccountForm
            // 
            this.AcceptButton = this.btnCreateAccount;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(380, 496);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.cbShowPass);
            this.Controls.Add(this.txtMasterPassword);
            this.Controls.Add(this.btnCreateAccount);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.linklblLogin);
            this.Controls.Add(this.lblHaveAccount);
            this.Controls.Add(this.lblCreate);
            this.Controls.Add(this.txtLastName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CreateAccountForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "createAccountForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.LinkLabel linklblLogin;
        private System.Windows.Forms.Label lblHaveAccount;
        private System.Windows.Forms.Label lblCreate;
        private MaterialSkin.Controls.MaterialButton btnCreateAccount;
        private MaterialSkin.Controls.MaterialTextBox txtPassword;
        private MaterialSkin.Controls.MaterialTextBox txtFirstName;
        private MaterialSkin.Controls.MaterialCheckbox cbShowPass;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MaterialSkin.Controls.MaterialTextBox txtLastName;
        private MaterialSkin.Controls.MaterialTextBox txtEmail;
        private MaterialSkin.Controls.MaterialTextBox txtMasterPassword;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}