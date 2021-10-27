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
//  This form is a container form that holds the LoginForm and the CreateAccountForm
//
#endregion
using KeyBit_ID.Forms;
using KeyBit_ID.Structs;
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace KeyBit_ID
{
    public partial class Login : MaterialForm
    {
        // create string and set it to data location.... may be redundent
        private static readonly string DataLocation = Application.StartupPath + @"\data\accounts\";

        // instantiate a new FileSystem()
        readonly FileSystem fileSystem = new FileSystem();
        public Login()
        {
            InitializeComponent();

        }

        private void Login_Load(object sender, EventArgs e)
        {
            // call method of showing the Login form
            ShowLoginDialog();
            // if director is empty, meaning no account then show create account
            if (fileSystem.IsDirectoryEmpty(DataLocation))
            {
                // call method of showing the create account form
                ShowCreateAccountDialog();
            }
            else
            {
                // if directory contains an account file then continue
                // by calling the method to show login
                ShowLoginDialog();
            }

        }
        // Method to show login
        public void ShowLoginDialog()
        {
            // instantiate a new LoginForm()
            LoginForm LF = new LoginForm
            {
                // change toplevel to false to allow embedding of control
                TopLevel = false
            };
            // clear previous controls if any
            panLogin.Controls.Clear();
            // add LoginForm to control
            panLogin.Controls.Add(LF);
            // set dockstyle to fill the control
            LF.Dock = DockStyle.Fill;
            // show the form
            LF.Show();
        }
        // Method to show account creation
        public void ShowCreateAccountDialog()
        {
            // instantiate a new CreateAccountForm()
            CreateAccountForm CA = new CreateAccountForm
            {
                // change toplevel to false to allow embedding of control
                TopLevel = false
            };
            // clear previous controls if any
            panLogin.Controls.Clear();
            // add CreateAccountForm to control
            panLogin.Controls.Add(CA);
            // set dockstyle to fill the control
            CA.Dock = DockStyle.Fill;
            // show the form
            CA.Show();
        }
    }
}
