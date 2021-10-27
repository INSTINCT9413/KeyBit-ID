#region Header Block
//  About this Program
//  
//  Programmer:     Jacob Brookhouse
//  Class:          CITP 280 - 70591
//  Application:    KeyBit ID - Password Manager
//  Description:    KeyBit ID is a password manager that allows a user to save sensitive
//                  information, such as passwords and account information.
//
#endregion
#region About this file
//
// This form is the LoginForm which allows the user to enter their account
// login data to login to the program
//
#endregion
using KeyBit_ID.Classes;
using KeyBit_ID.Properties;
using KeyBit_ID.Structs;
using MaterialSkin.Controls;
using System;
using System.Linq;
using System.Windows.Forms;

namespace KeyBit_ID.Forms
{

    public partial class LoginForm : Form
    {
        // create string and set the data location... possibly redundent
        private static readonly string DataLocation = Application.StartupPath + @"\data\accounts\";

        // instantiate a new FileSystem()
        readonly FileSystem checkPath = new FileSystem();

        // instantiate a new UserIDEncrypt() and UserIDReadWrite() classes
        readonly UserIDEncrypt userIDEncrypt = new UserIDEncrypt();
        readonly UserIDReadWrite userIDReadWrite = new UserIDReadWrite();
        readonly Wait wait = new Wait();


        public LoginForm()
        {
            InitializeComponent();

        }

        private void LinklblCreateAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // call method IsDirectorEmpty and check the DataLocation
            // if it is empty then show create account
            if (checkPath.IsDirectoryEmpty(DataLocation))
            {
                var create = Application.OpenForms.OfType<Login>().Single();
                create.ShowCreateAccountDialog();
            }
            else
            {
                // show message box explaining that only one account is supported
                MessageBox.Show(Application.ProductName + " only supports a single account at this time!\nPleae sign into your current account to continue." +
                    "\nTo create a new account, please delete your previous account.",
                    "Account Detected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            // try catch
            try
            {
                // call ValidateCredintials()
                ValidateCredintials();

            }
            catch { }
        }
        // method to check if the entered data is the data of the account file
        private void ValidateCredintials()
        {
            pictureBox1.Visible = true;
            wait.Time(1);
            // call GetHWID method
            userIDEncrypt.GetHWID();
            // call ReadAccount method to read the account
            userIDReadWrite.ReadAccount();
            // try catch
            try
            {
                // if the controls text fields equal the UserID matching fields 
                if (txtEmail.Text == UserID.Email & txtPass.Text == UserID.Password)
                {
                    // set the setting for successful login to true
                    Settings.Default.SuccessfulLogin = true;
                    // save settings
                    Settings.Default.Save();
                    // close this form
                    this.Close();
                    var create = Application.OpenForms.OfType<Login>().Single();
                    create.Close();
                    MaterialMessageBox.Show("You successfully logged in!", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.None, false);
                }
                else
                {

                    // show message box saying that email and or password is wrong
                    MaterialMessageBox.Show(new Form() { TopMost = true, StartPosition = FormStartPosition.CenterScreen },
                        "The entered email or password are incorrect!", "Email or password mismatch", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
            }
            catch
            {

            }
        }

        private void CbRemember_CheckedChanged(object sender, EventArgs e)
        {
            // if checkbox checked
            if (cbShowPass.Checked == true)
            {
                // change password property of textbox to false
                // allowing you to see the characters
                txtPass.Password = false;
                // redraw the control
                txtPass.Refresh();
            }
            else
            {
                // change it back to true to hide the characters
                txtPass.Password = true;
                // redraw control
                txtPass.Refresh();
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            /* under construction
            if (Settings.Default .RememberCredentials == true)
            {
                this.btnLogin.PerformClick();
            }
            */
        }
    }
}
