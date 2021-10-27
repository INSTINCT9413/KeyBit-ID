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
// The CreateAccountForm is the form that contains the controls and logic
// to create a users account
//
#endregion
using KeyBit_ID.Classes;
using KeyBit_ID.Properties;
using MaterialSkin.Controls;
using System;
using System.Linq;
using System.Windows.Forms;

namespace KeyBit_ID.Forms
{
    public partial class CreateAccountForm : Form
    {
        // variables
        private int id;
        private string firstname;
        private string lastname;
        private string email;
        private string password;
        private string masterpassword;
        private readonly Random generateID = new Random();

        // instantiate a UserIDReadWrite()
        readonly UserIDReadWrite userIDReadWrite = new UserIDReadWrite();


        public CreateAccountForm()
        {
            InitializeComponent();

        }

        private void LinklblLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // create a variable login and assign it to an open form
            var login = Application.OpenForms.OfType<Login>().Single();
            // now show that form
            login.ShowLoginDialog();
        }

        private void BtnCreateAccount_Click(object sender, System.EventArgs e)
        {
            // call ValidateData() method
            ValidateData();



        }
        // method to initialize user data
        void InitializeUser()
        {
            // set UserID properites to the variables
            UserID.ID = id;
            UserID.FirstName = firstname;
            UserID.LastName = lastname;
            UserID.Email = email;
            UserID.Password = password;
            UserID.MasterPassword = masterpassword;



            // try catch
            try
            {
                // close this form
                this.Close();
                // create a variable and assign it to an ope form
                var create = Application.OpenForms.OfType<Login>().Single();
                // close the open form
                create.Close();
            }
            catch
            {

            }
        }
        // Method to validate user data
        void ValidateData()
        {
            pictureBox2.Visible = true;
            // call IsValidEmail method and pass the email textbox text
            // so if it is a valid email
            if (VerifyEmail.IsValidEmail(txtEmail.Text))
            {
                // assign the varables with each of the controls text
                id = generateID.Next();
                firstname = txtFirstName.Text;
                lastname = txtLastName.Text;
                email = txtEmail.Text;
                password = txtPassword.Text;
                masterpassword = txtMasterPassword.Text;
                // call method InitializeUser()
                InitializeUser();
                // call method WriteAccount()
                userIDReadWrite.WriteAccount();
                // set a setting for succes login to true
                Settings.Default.SuccessfulLogin = true;
                // save the settings
                Settings.Default.Save();
            }
            else
            {
                // show message box saying that the email entered is invalid
                MaterialMessageBox.Show("Some of your data you entered is incorrect.\nPlease verify that you entered a valid email!", "Error: Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Warning, false);
            }
        }

        private void CbRemember_CheckedChanged(object sender, EventArgs e)
        {
            // if the check box is true
            if (cbShowPass.Checked == true)
            {
                // change the password property of the textbox to false
                // allowing you to see the character entered
                txtPassword.Password = false;
                txtMasterPassword.Password = false;
                // redraw the controls
                txtPassword.Refresh();
                txtMasterPassword.Refresh();
            }
            else
            {
                // else hide the characters
                txtPassword.Password = true;
                txtMasterPassword.Password = true;
                // redraw the controls
                txtPassword.Refresh();
                txtMasterPassword.Refresh();
            }
        }
    }
}
