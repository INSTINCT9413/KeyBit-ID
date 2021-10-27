
namespace KeyBit_ID.Forms
{
    partial class LoginForm
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
            this.lblLogin = new System.Windows.Forms.Label();
            this.lblMakeAccount = new System.Windows.Forms.Label();
            this.linklblCreateAccount = new System.Windows.Forms.LinkLabel();
            this.lblemail = new System.Windows.Forms.Label();
            this.lblPass = new System.Windows.Forms.Label();
            this.linklblForgotPass = new System.Windows.Forms.LinkLabel();
            this.txtEmail = new MaterialSkin.Controls.MaterialTextBox();
            this.txtPass = new MaterialSkin.Controls.MaterialTextBox();
            this.cbShowPass = new MaterialSkin.Controls.MaterialCheckbox();
            this.btnLogin = new MaterialSkin.Controls.MaterialButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogin.ForeColor = System.Drawing.Color.White;
            this.lblLogin.Location = new System.Drawing.Point(12, 68);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(84, 37);
            this.lblLogin.TabIndex = 0;
            this.lblLogin.Text = "Login";
            // 
            // lblMakeAccount
            // 
            this.lblMakeAccount.AutoSize = true;
            this.lblMakeAccount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMakeAccount.ForeColor = System.Drawing.Color.White;
            this.lblMakeAccount.Location = new System.Drawing.Point(15, 105);
            this.lblMakeAccount.Name = "lblMakeAccount";
            this.lblMakeAccount.Size = new System.Drawing.Size(193, 21);
            this.lblMakeAccount.TabIndex = 1;
            this.lblMakeAccount.Text = "Need to make an account?";
            // 
            // linklblCreateAccount
            // 
            this.linklblCreateAccount.AutoSize = true;
            this.linklblCreateAccount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linklblCreateAccount.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linklblCreateAccount.LinkColor = System.Drawing.Color.DodgerBlue;
            this.linklblCreateAccount.Location = new System.Drawing.Point(204, 105);
            this.linklblCreateAccount.Name = "linklblCreateAccount";
            this.linklblCreateAccount.Size = new System.Drawing.Size(115, 21);
            this.linklblCreateAccount.TabIndex = 3;
            this.linklblCreateAccount.TabStop = true;
            this.linklblCreateAccount.Text = "Create Account";
            this.linklblCreateAccount.VisitedLinkColor = System.Drawing.Color.DodgerBlue;
            this.linklblCreateAccount.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinklblCreateAccount_LinkClicked);
            // 
            // lblemail
            // 
            this.lblemail.AutoSize = true;
            this.lblemail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblemail.ForeColor = System.Drawing.Color.White;
            this.lblemail.Location = new System.Drawing.Point(36, 171);
            this.lblemail.Name = "lblemail";
            this.lblemail.Size = new System.Drawing.Size(51, 21);
            this.lblemail.TabIndex = 7;
            this.lblemail.Text = "Email:";
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPass.ForeColor = System.Drawing.Color.White;
            this.lblPass.Location = new System.Drawing.Point(36, 248);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(79, 21);
            this.lblPass.TabIndex = 8;
            this.lblPass.Text = "Password:";
            // 
            // linklblForgotPass
            // 
            this.linklblForgotPass.AutoSize = true;
            this.linklblForgotPass.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linklblForgotPass.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linklblForgotPass.LinkColor = System.Drawing.Color.DodgerBlue;
            this.linklblForgotPass.Location = new System.Drawing.Point(211, 248);
            this.linklblForgotPass.Name = "linklblForgotPass";
            this.linklblForgotPass.Size = new System.Drawing.Size(133, 21);
            this.linklblForgotPass.TabIndex = 9;
            this.linklblForgotPass.TabStop = true;
            this.linklblForgotPass.Text = "Forgot Password?";
            this.linklblForgotPass.VisitedLinkColor = System.Drawing.Color.DodgerBlue;
            // 
            // txtEmail
            // 
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEmail.Depth = 0;
            this.txtEmail.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtEmail.LeadingIcon = null;
            this.txtEmail.Location = new System.Drawing.Point(40, 195);
            this.txtEmail.MaxLength = 50;
            this.txtEmail.MouseState = MaterialSkin.MouseState.OUT;
            this.txtEmail.Multiline = false;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(304, 50);
            this.txtEmail.TabIndex = 1;
            this.txtEmail.Text = "";
            this.txtEmail.TrailingIcon = null;
            // 
            // txtPass
            // 
            this.txtPass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPass.Depth = 0;
            this.txtPass.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtPass.LeadingIcon = null;
            this.txtPass.Location = new System.Drawing.Point(40, 272);
            this.txtPass.MaxLength = 50;
            this.txtPass.MouseState = MaterialSkin.MouseState.OUT;
            this.txtPass.Multiline = false;
            this.txtPass.Name = "txtPass";
            this.txtPass.Password = true;
            this.txtPass.Size = new System.Drawing.Size(304, 50);
            this.txtPass.TabIndex = 2;
            this.txtPass.Text = "";
            this.txtPass.TrailingIcon = null;
            // 
            // cbShowPass
            // 
            this.cbShowPass.AutoSize = true;
            this.cbShowPass.Depth = 0;
            this.cbShowPass.ForeColor = System.Drawing.Color.White;
            this.cbShowPass.Location = new System.Drawing.Point(40, 325);
            this.cbShowPass.Margin = new System.Windows.Forms.Padding(0);
            this.cbShowPass.MouseLocation = new System.Drawing.Point(-1, -1);
            this.cbShowPass.MouseState = MaterialSkin.MouseState.HOVER;
            this.cbShowPass.Name = "cbShowPass";
            this.cbShowPass.Ripple = true;
            this.cbShowPass.Size = new System.Drawing.Size(149, 37);
            this.cbShowPass.TabIndex = 4;
            this.cbShowPass.Text = "Show Password";
            this.cbShowPass.UseVisualStyleBackColor = true;
            this.cbShowPass.CheckedChanged += new System.EventHandler(this.CbRemember_CheckedChanged);
            // 
            // btnLogin
            // 
            this.btnLogin.AutoSize = false;
            this.btnLogin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnLogin.Depth = 0;
            this.btnLogin.HighEmphasis = true;
            this.btnLogin.Icon = null;
            this.btnLogin.Location = new System.Drawing.Point(97, 386);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnLogin.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(187, 45);
            this.btnLogin.TabIndex = 13;
            this.btnLogin.Text = "Login";
            this.btnLogin.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnLogin.UseAccentColor = false;
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::KeyBit_ID.Properties.Resources._282;
            this.pictureBox1.Location = new System.Drawing.Point(173, 440);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 35);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // LoginForm
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(380, 496);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.cbShowPass);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.linklblForgotPass);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.lblemail);
            this.Controls.Add(this.linklblCreateAccount);
            this.Controls.Add(this.lblMakeAccount);
            this.Controls.Add(this.lblLogin);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Label lblMakeAccount;
        private System.Windows.Forms.LinkLabel linklblCreateAccount;
        private System.Windows.Forms.Label lblemail;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.LinkLabel linklblForgotPass;
        private MaterialSkin.Controls.MaterialButton btnLogin;
        private MaterialSkin.Controls.MaterialTextBox txtEmail;
        private MaterialSkin.Controls.MaterialTextBox txtPass;
        private MaterialSkin.Controls.MaterialCheckbox cbShowPass;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}